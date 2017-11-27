using CompetitionsInformer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student s1 = new Student("Student1", 155);
            //Student s2 = new Student("Student2", 145);
            //Student s3 = new Student("Student3", 15);
            //Student s4 = new Student("Student4", 55);
            //Student s5 = new Student("Student5", 45);
            //Student s6 = new Student("Student6", 65);
            //Student s7 = new Student("Student7", 166);
            //Student s8 = new Student("Student8", 102);
            //Student s9 = new Student("Student9", 1);
            //Student s10 = new Student("Student10", 10);
            //Student s11 = new Student("Student11", 138);
            Student s1 = new Student("Student1");
            Student s2 = new Student("Student2");
            Student s3 = new Student("Student3");
            Student s4 = new Student("Student4");
            Student s5 = new Student("Student5");
            Student s6 = new Student("Student6");
            Student s7 = new Student("Student7");
            Student s8 = new Student("Student8");
            Student s9 = new Student("Student9");
            Student s10 = new Student("Student10");
            Student s11 = new Student("Student11");
            Competition ci = new Competition("Inform open", Subject.ComputerScience, "KNURE", DateTime.Parse("2017/12/25"), RegionLevel.Local);
            s1.AddSkill(Subject.ComputerScience);
            s1.AddSkill(Subject.Biology);
            s2.AddSkill(Subject.ComputerScience);
            s3.AddSkill(Subject.ComputerScience);
            s4.AddSkill(Subject.ComputerScience);
            s5.AddSkill(Subject.ComputerScience);
            s6.AddSkill(Subject.ComputerScience);
            s7.AddSkill(Subject.ComputerScience);
            s8.AddSkill(Subject.ComputerScience);
            s9.AddSkill(Subject.ComputerScience);
            s10.AddSkill(Subject.ComputerScience);
            s11.AddSkill(Subject.ComputerScience);
            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);
            students.Add(s6);
            students.Add(s7);
            students.Add(s8);
            students.Add(s9);
            students.Add(s10);
            students.Add(s11);
            //ci.RegisterParticipant((IParticipant)students);
            //ci.RegisterParticipant(s1);
            //ci.RegisterParticipant(s2);
            //ci.RegisterParticipant(s3);
            //ci.RegisterParticipant(s4);
            //ci.RegisterParticipant(s5);
            //ci.RegisterParticipant(s6);
            //ci.RegisterParticipant(s7);
            //ci.RegisterParticipant(s8);
            //ci.RegisterParticipant(s9);
            //ci.RegisterParticipant(s10);
            //ci.RegisterParticipant(s11);

            //ci.GetWinners();

            List<Student> s = new List<Student>();
            s = Student.LoadXML();

            foreach (var ss in s)
            {
                Console.WriteLine(ss.Name);
                foreach (var sss in ss.Skills)
                {                    
                    Console.WriteLine($"subject: {sss.Subject}");
                    Console.WriteLine($"level: {sss.Level}");
                }
                Console.WriteLine("________________________");
            }
            s1.SaveXML();
            s10.SaveXML();
            s11.SaveXML();           
            s3.AddSkill(Subject.History, 89);
            s3.SaveXML();
            s5.SaveXML();
            Console.WriteLine("--------->>>>>>>>>>>>>>>>>>");
            Console.WriteLine("ending");

            Console.ReadLine();
        }        
    }
}
