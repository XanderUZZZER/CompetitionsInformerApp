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
        private List<IAdvisor> advisors { get; set; }

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
            XDocument xdoc = new XDocument(); 
            // создаем корневой элемент
            XElement students = new XElement("students");
            
            // создаем первый элемент
            XElement student = new XElement("student");
            // создаем атрибут
            XAttribute studentNameAttr = new XAttribute("name", Name);            
            student.Add(studentNameAttr);

            foreach (var s in Skills)
            {
                XElement skillElem = new XElement("skill");
                XAttribute skillSubjectAttr = new XAttribute("subject", s.Subject.ToString());
                XElement subjectElem = new XElement("subject", s.Subject.ToString());
                XElement levelElem = new XElement("level", s.Level);
                skillElem.Add(skillSubjectAttr);
                skillElem.Add(subjectElem);
                skillElem.Add(levelElem);
                student.Add(skillElem);
            }
            students.Add(student);
            xdoc.Add(students);
            xdoc.Save("students.xml");
        }

        public void SaveXML1()
        {
            XDocument xdoc;
            XElement student = new XElement("student");
            XAttribute studentNameAttr = new XAttribute("name", Name);
            student.Add(studentNameAttr);
            XElement students;

            if (File.Exists("students1.xml"))
            {
                xdoc = XDocument.Load("students1.xml");
                students = xdoc.Element("students");
            }
            else
            {
                xdoc = new XDocument();
                students = new XElement("students");
                //XAttribute studentNameAttr = new XAttribute("name", Name);                
            }

            foreach (var s in Skills)
            {
                XElement skillElem = new XElement("skill");
                XAttribute skillSubjectAttr = new XAttribute("subject", s.Subject.ToString());
                XElement subjectElem = new XElement("subject", s.Subject.ToString());
                XElement levelElem = new XElement("level", s.Level);
                skillElem.Add(skillSubjectAttr);
                skillElem.Add(subjectElem);
                skillElem.Add(levelElem);
                student.Add(skillElem);
                students.Add(student);
            }

            xdoc.Save("students1.xml");
        }

        public static List<Student> LoadXML()
        {
            XDocument xdoc = XDocument.Load("students.xml");
            List<Student> students = new List<Student>();
            Student temp;

            foreach (XElement el in xdoc.Element("students").Elements("student"))
            {
                temp = ( new Student( el.Attribute("name").Value.ToString() ) );

                foreach (XElement elem in el.Elements("skill"))
                {
                    Subject subject = (Subject) Enum.Parse(typeof(Subject), elem.Element("subject").Value.ToString());                    
                    int level = int.Parse(elem.Element("level").Value.ToString());
                    temp.AddSkill(subject, level);
                }
                students.Add(temp);
            }
            return students;
        }
    }
}
