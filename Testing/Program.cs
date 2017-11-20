using CompetitionsInformer;
using System;

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
            ci.RegisterParticipant(s1);
            ci.RegisterParticipant(s2);
            ci.RegisterParticipant(s3);
            ci.RegisterParticipant(s4);
            ci.RegisterParticipant(s5);
            ci.RegisterParticipant(s6);
            ci.RegisterParticipant(s7);
            ci.RegisterParticipant(s8);
            ci.RegisterParticipant(s9);
            ci.RegisterParticipant(s10);
            ci.RegisterParticipant(s11);

            ci.GetWinners();
            ci.CreateXML1();
            //ci.CreateXML2();
            
            Console.WriteLine("ending");

            Console.ReadLine();
        }
    }
}
