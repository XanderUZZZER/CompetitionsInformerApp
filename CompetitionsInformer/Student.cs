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

        public void AddSkill(Subject subject)
        {
            Skills.Add(new Skill(subject));
        }

        public void AddSkill(Subject subject, int level)
        {
            Skills.Add(new Skill(subject, level));
        }

        public bool HasSkill(Subject subject)
        {
            return Skills.Any(s => s.Subject == subject);
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

        public void RemoveSkill(Subject subject)
        {
            Skills.Remove(Skills.Where(s => s.Subject == subject).First());
        }

        public void AddAdviser(IAdvisor advisor)
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

        public void RemoveAdviser(IAdvisor advisor)
        {
            if (advisors.Contains(advisor))
            {
                advisors.Remove(advisor);
            }
        }

        public void SaveXML()
        {
            XDocument xDoc;
            XElement root;
            XElement studentElement = new XElement("student");
            XAttribute studentAttrName = new XAttribute("name", this.Name);
            XElement skillElement;
            XElement subjectElement;
            XElement levelElement;
            try
            {
                xDoc = XDocument.Load("students.xml");
                root = xDoc.Root;
                Console.WriteLine("students.xml loaded well");
                //if (!(root.Elements("student").Attributes("name").Contains(this.Name)))
                studentElement.Add(studentAttrName);
                foreach (var skill in Skills)
                {
                    skillElement = new XElement("skill");
                    subjectElement = new XElement("subject", skill.Subject.ToString());
                    levelElement = new XElement("level", skill.Level);
                    skillElement.Add(subjectElement);
                    skillElement.Add(levelElement);
                    studentElement.Add(skillElement);
                }
                xDoc.Element("students").Add(studentElement);
            }
            catch
            {
                Console.WriteLine("Error, file students.xml not found or corrupted");
                xDoc = new XDocument();
                root = new XElement("students");
                studentElement = new XElement("student");
                studentAttrName = new XAttribute("name", this.Name);
                studentElement.Add(studentAttrName);
                foreach(var skill in Skills)
                {
                    skillElement = new XElement("skill");
                    subjectElement = new XElement("subject", skill.Subject.ToString());
                    levelElement = new XElement("level", skill.Level);
                    skillElement.Add(subjectElement);
                    skillElement.Add(levelElement);
                    studentElement.Add(skillElement);
                }
                xDoc.Add(root);
            }

            xDoc.Save("students.xml");
            Console.WriteLine("+++++++++++");
        }

        public static List<Student> LoadXML()
        {
            XDocument xdoc = XDocument.Load("students.xml");
            List<Student> students = new List<Student>();
            Student temp;

            foreach (XElement el in xdoc.Element("students").Elements("student"))
            {
                temp = (new Student(el.Attribute("name").Value.ToString()));

                foreach (XElement elem in el.Elements("skill"))
                {
                    Subject subject = (Subject)Enum.Parse(typeof(Subject), elem.Element("subject").Value.ToString());
                    int level = int.Parse(elem.Element("level").Value.ToString());
                    temp.AddSkill(subject, level);
                }
                students.Add(temp);
            }
            return students;
        }
    }
}
