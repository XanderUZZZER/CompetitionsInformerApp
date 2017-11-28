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
            Professor p1 = new Professor("Prof1", Subject.History);
            Professor p2 = new Professor("Prof2", Subject.English);
            Professor p3 = new Professor("Prof3", Subject.Chemistry);
            Professor p4 = new Professor("Prof4", Subject.Physics);
            Professor p5 = new Professor("Prof5", Subject.Chemistry);
            Professor p6 = new Professor("Prof6", Subject.Maths);
            Professor p7 = new Professor("Prof7", Subject.History);
            Professor p8 = new Professor("Prof8", Subject.ComputerScience);
            Competition ci = new Competition("Inform open", Subject.ComputerScience, "KNURE", DateTime.Parse("2017/12/25"), RegionLevel.Local);
            s1.AddSkill(Subject.ComputerScience);
            s1.AddSkill(Subject.Biology);
            s2.AddSkill(Subject.ComputerScience);
            s3.AddSkill(Subject.ComputerScience);
            s4.AddSkill(Subject.ComputerScience);
            s4.AddSkill(Subject.Physics, 44);
            s4.AddAdvisor(p4);
            s5.AddSkill(Subject.ComputerScience);
            s6.AddSkill(Subject.ComputerScience, 91);
            s6.AddAdvisor(p8);
            s7.AddSkill(Subject.ComputerScience);
            s8.AddSkill(Subject.ComputerScience);
            s9.AddSkill(Subject.ComputerScience);
            s10.AddSkill(Subject.ComputerScience);
            s11.AddSkill(Subject.ComputerScience);
            List<IParticipant<Person>> Participants = Student.LoadXML();
            //Participants.Add(s1);
            //Participants.Add(s2);
            //Participants.Add(s3);
            //Participants.Add(s4);
            //Participants.Add(s5);
            //Participants.Add(s6);
            //Participants.Add(s7);
            //Participants.Add(s8);
            //Participants.Add(s9);
            //Participants.Add(s10);
            //Participants.Add(s11);
            ci.RegisterParticipant(Participants);
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

            ci.GetWinners();
            foreach(var p in Participants)
            {
                p.SaveXML();
            }
            List<IParticipant<Person>> s = new List<IParticipant<Person>>();
            s = Student.LoadXML();

            foreach (var ss in s)
            {
                Console.WriteLine(((Person)ss).Name);
                Console.WriteLine("------------------------");
                foreach (var sss in ss.GetSkills())
                {
                    
                    Console.WriteLine($"subject: {sss.Subject}");
                    Console.WriteLine($"level: {sss.Level}");
                    foreach (var ad in ss.GetAdvisors())
                    {
                        if (ad.Subject == sss.Subject)
                        {
                            Console.WriteLine($"advisor: {((Person)ad).Name}");
                        }
                    }
                    Console.WriteLine("________________________");
                }
                Console.WriteLine("\n");
            }


            s3.AddSkill(Subject.History, 89);
            s3.AddAdvisor(p1);
            s3.AddAdvisor(p7);
            s3.SaveXML();
            s1.SaveXML();
            s10.SaveXML();
            s11.SaveXML();
            s5.SaveXML();
            foreach (var stud in Participants)
            {
                stud.SaveXML();
            }
            Console.WriteLine("--------->>>>>>>>>>>>>>>>>>");
            Console.WriteLine("ending");

            Console.ReadLine();
        }        
    }
}
