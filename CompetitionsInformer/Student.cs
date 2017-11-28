using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompetitionsInformer
{
    public class Student : Person, IParticipant<Person>
    {
        public List<Skill> Skills { get; private set; }
        public List<IAdvisor<Person>> Advisors { get; private set; }
        public Dictionary<Subject, int> Wins { get; private set; }

        public Student(string name) : base(name)
        {
            Skills = new List<Skill>();
            Advisors = new List<IAdvisor<Person>>();
            Wins = new Dictionary<Subject, int>();
        }

        public bool HasSkill(Subject subject)
        {
            return Skills.Any(s => s.Subject == subject);
        }

        public void AddSkill(Subject subject)
        {
            if (!HasSkill(subject))
            {
                Skills.Add(new Skill(subject));
                Wins[subject] = 0;
            }
        }

        public void AddSkill(Subject subject, int level)
        {
            if (!HasSkill(subject))
            {
                Skills.Add(new Skill(subject, level));
                Wins[subject] = 0;
            }
        }

        public void AlterSkillLevel(Subject subject, int level)
        {
            if (HasSkill(subject))
            {
                RemoveSkill(subject);
                Skills.Add(new Skill(subject, level));
            }
        }

        public void RemoveSkill(Subject subject)
        {
            Skills.Remove(Skills.Where(s => s.Subject == subject).First());
        }

        public List<Skill> GetSkills()
        {
            return Skills;
        }

        public int GetSkillLevel(Subject subject)
        {
            if (HasSkill(subject))
            {
                double bonus = 1;
                foreach (var advisor in Advisors)
                {
                    if (advisor.Subject == subject)
                    {
                        bonus += 0.1;
                    }
                }
                return (int)(Skills.Where(s => s.Subject == subject).First().Level * bonus);
            }
            return -1;
        }

        public void AddAdvisor(IAdvisor<Person> advisor)
        {
            if (!Advisors.Contains(advisor) && Skills.Select(skill => skill.Subject).Contains(advisor.Subject))
            {
                Advisors.Add(advisor);
            }
        }

        public List<IAdvisor<Person>> GetAdvisors()
        {
            return Advisors;
        }

        public void RemoveAdvisor(IAdvisor<Person> advisor)
        {
            if (Advisors.Contains(advisor))
            {
                Advisors.Remove(advisor);
            }
        }

        public void AddWin(Subject subject)
        {
            Wins[subject]++;
        }

        public static List<IParticipant<Person>> LoadXML()
        {
            List<IParticipant<Person>> students = new List<IParticipant<Person>>();
            try
            {
                XDocument xdoc = XDocument.Load("students.xml");
                Student currentStudent;
                foreach (XElement el in xdoc.Element("students").Elements("student"))
                {
                    currentStudent = (new Student(el.Attribute("name").Value.ToString()));
                    foreach (XElement elem in el.Elements("skill"))
                    {
                        Subject subject = (Subject)Enum.Parse(typeof(Subject), elem.Element("subject").Value.ToString());
                        int level = int.Parse(elem.Element("level").Value.ToString());
                        int wins = int.Parse(elem.Element("wins").Value.ToString());
                        currentStudent.AddSkill(subject, level);
                        currentStudent.Wins[subject] = wins;
                        foreach (var advisorElement in elem.Elements("advisor"))
                        {
                            currentStudent.AddAdvisor(new Professor(advisorElement.Value, subject));
                        }
                    }
                    students.Add(currentStudent);
                }
            }
            catch
            {
                Console.WriteLine("File is empty or corrupted");
            }
            return students;
        }

        public void SaveXML()
        {
            List<IParticipant<Person>> tempStudents = LoadXML();
            if (tempStudents.Select(student => ((Person)student).Name).Contains(this.Name))
            {
                IParticipant<Person> currentStudent = tempStudents.First(student => ((Person)student).Name == this.Name);
                tempStudents.Remove(currentStudent);
                tempStudents.Add(this);
            }
            else
            {
                tempStudents.Add(this);
            }

            XDocument xDoc = new XDocument();
            XElement root = new XElement("students");
            XElement studentElement;
            XAttribute studentAttrName;
            XElement skillElement;
            XElement subjectElement;
            XElement levelElement;
            XElement winElement;
            XElement advisorElement;

            foreach (var student in tempStudents.OrderBy(s => ((Person)s).Name))
            {
                studentElement = new XElement("student");
                studentAttrName = new XAttribute("name", ((Person)student).Name);
                foreach (var skill in ((Student)student).Skills)
                {
                    skillElement = new XElement("skill");
                    subjectElement = new XElement("subject", skill.Subject.ToString());
                    levelElement = new XElement("level", skill.Level);
                    if (((Student)student).Wins.ContainsKey(skill.Subject))
                    {
                        winElement = new XElement("wins", ((Student)student).Wins[skill.Subject]);
                    }
                    else
                    {
                        winElement = new XElement("wins", 0);
                    }
                    skillElement.Add(subjectElement);
                    skillElement.Add(levelElement);
                    skillElement.Add(winElement);
                    foreach (var advisor in ((Student)student).Advisors)
                    {
                        if (advisor.Subject == skill.Subject)
                        {
                            advisorElement = new XElement("advisor", ((Person)advisor).Name);
                            skillElement.Add(advisorElement);
                        }
                    }
                    studentElement.Add(skillElement);
                }
                studentElement.Add(studentAttrName);
                root.Add(studentElement);
            }
            xDoc.Add(root);
            xDoc.Save("students.xml");
        }
    }
}
