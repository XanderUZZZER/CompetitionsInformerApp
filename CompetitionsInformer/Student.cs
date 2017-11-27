using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompetitionsInformer
{
    public class Student : Person, IParticipant
    {
        public List<Skill> Skills { get; private set; }
        private List<IAdvisor> advisors;

        public Student(string name) : base(name)
        {
            Skills = new List<Skill>();
            advisors = new List<IAdvisor>();
        }

        public bool HasSkill(Subject subject)
        {
            return Skills.Any(s => s.Subject == subject);
        }

        public void AddSkill(Subject subject)
        {
            if (!HasSkill(subject))
                Skills.Add(new Skill(subject));
        }

        public void AddSkill(Subject subject, int level)
        {
            if (!HasSkill(subject))
            {
                Skills.Add(new Skill(subject, level));
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

        public int GetSkillLevel(Subject subject)
        {
            if (HasSkill(subject))
            {
                double bonus = 1;
                foreach (var advisor in advisors)
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

        public void AddAdvisor(IAdvisor advisor)
        {
            if (!advisors.Contains(advisor))
            {
                advisors.Add(advisor);
            }
        }

        public List<IAdvisor> GetAdvisors()
        {
            return advisors;
        }

        public void RemoveAdvisor(IAdvisor advisor)
        {
            if (advisors.Contains(advisor))
            {
                advisors.Remove(advisor);
            }
        }        

        public static List<Student> LoadXML()
        {
            List<Student> students = new List<Student>();
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
                        currentStudent.AddSkill(subject, level);
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
            List<Student> tempList = LoadXML();
            if (tempList.Select(student => student.Name).Contains(this.Name))
            {
                Student currentStudent = tempList.First(student => student.Name == this.Name);
                foreach (var skill in Skills)
                {
                    if (!tempList.First(student => student.Name == this.Name).Skills.Select(s => s.Subject).Contains(skill.Subject))
                    {
                        tempList.First(student => student.Name == this.Name).AddSkill(skill.Subject, skill.Level);
                    }
                    else if (!tempList.First(student => student.Name == this.Name).Skills.Select(s => s.Level).Contains(skill.Level))
                    {
                        tempList.First(student => student.Name == this.Name).AlterSkillLevel(skill.Subject, skill.Level);
                    }
                }
            }
            else
            {
                tempList.Add(this);
            }

            XDocument xDoc = new XDocument();
            XElement root = new XElement("students");
            XElement studentElement;
            XAttribute studentAttrName;
            XElement skillElement;
            XElement subjectElement;
            XElement levelElement;

            foreach (var student in tempList)
            {
                studentElement = new XElement("student");
                studentAttrName = new XAttribute("name", student.Name);
                foreach (var skill in student.Skills)
                {
                    skillElement = new XElement("skill");
                    subjectElement = new XElement("subject", skill.Subject.ToString());
                    levelElement = new XElement("level", skill.Level);
                    skillElement.Add(subjectElement);
                    skillElement.Add(levelElement);
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
