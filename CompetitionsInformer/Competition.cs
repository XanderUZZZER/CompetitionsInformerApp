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
                (participant.ContainsSkill(Subject)))
            {
                Participants.Add(participant);
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

        public void CreateXML1()
        {
            XDocument xdoc = new XDocument();
            // создаем корневой элемент
            XElement tour = new XElement("tour");
            xdoc.Add(tour);
            foreach (KeyValuePair<Tour, List<IParticipant>> kvp in Winners)
            {
                XElement currTour = new XElement(kvp.Key.ToString());
                foreach (var p in kvp.Value)
                {
                    XElement winner = new XElement("winner");
                    winner.Add(new XElement("name", ((Person)p).Name));
                    winner.Add(new XElement("points", null));
                    winner.Add(new XElement("skill", p.GetSkillLevel(Subject)));
                    currTour.Add(winner);
                }
                tour.Add(currTour);
            }

            //сохраняем документ
            xdoc.Save($"{Name} - competition.xml");
        }
        public void CreateXML2()
        {
            //XmlSerializer xs = new XmlSerializer(typeof(Competition));
            //using (Stream s = File.Create("test.xml"))
            //    xs.Serialize(s, this);
        }

    }
}
