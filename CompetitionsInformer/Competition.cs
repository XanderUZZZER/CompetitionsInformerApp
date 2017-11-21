using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CompetitionsInformer
{
    public class Competition
    {
        public string Name { get; }
        public Subject Subject { get; }
        public string Place { get; }
        public DateTime Date { get; }
        public RegionLevel RegionLevel { get; }
        public List<IParticipant> Participants { get; private set; }
        public Dictionary<Tour, List<IParticipant>> Winners { get; private set; } = new Dictionary<Tour, List<IParticipant>>();

        public Competition()
        {
            Name = "Name";
            Subject = Subject.Biology;
            Place = "Place";
            Date = new DateTime(2017, 11, 12);
            RegionLevel = RegionLevel.Country;
            Participants = new List<IParticipant>();
            Winners = new Dictionary<Tour, List<IParticipant>>();
        }

        public Competition(string name, Subject subject, string place, DateTime date, RegionLevel regionLevel)
        {
            Name = name;
            Subject = subject;
            Place = place;
            Date = date;
            RegionLevel = regionLevel;
            Participants = new List<IParticipant>();
        }

        public void RegisterParticipant(IParticipant participant)
        {
            if ((!Participants.Contains(participant)) &&
                (participant.HasSkill(Subject)))
            {
                Participants.Add(participant);
            }
        }

        public void RegisterParticipant(List<IParticipant> participants)
        {
            foreach (var participant in participants)
            {
                RegisterParticipant(participant);
            }
        }

        public void GetWinners()
        {
            HoldCompetitionTour(Tour.QuarterFinals);
            HoldCompetitionTour(Tour.SemiFinals);
            HoldCompetitionTour(Tour.Finals);
        }

        private void HoldCompetitionTour(Tour tour)
        {
            Winners[tour] = Participants.OrderByDescending(s => s.GetSkillLevel(Subject)).Take((int)tour).ToList();
        }
    }
}
