using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public class Informer
    {
        public List<Competition> Competitions { get; private set; } = new List<Competition>();
        public List<IParticipant<Person>> Students { get; private set; } = new List<IParticipant<Person>>();
        public List<IAdvisor<Person>> Professors { get; private set; } = new List<IAdvisor<Person>>();

        public void AddCompetition(string name, Subject subject, string place, DateTime date, RegionLevel regionLevel)
        {
            Competitions.Add(new Competition(name, subject, place, date, regionLevel));
        }

        public void AddStudent(string name)
        {
            Students.Add(new Student(name));
        }

        public void AddProfessor(string name, Subject subject)
        {
            Professors.Add(new Professor(name, subject));
        }

        public void LoadXML()
        {

        }
    }
}
