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
    [Serializable]
    public class Competition
    {
        public string Name { get; }
        public Subject Subject { get; }
        public string Place { get; }
        public DateTime Date { get; }
        public Region RegionLevel { get; }
        public List<Person> Participants { get; }
        public Dictionary<Tour, List<Person>> Winners { get; private set; } = new Dictionary<Tour, List<Person>>();

        public Competition()
        {
            Name = "Name";
            Subject = Subject.Biology;
            Place = "Place";
            Date = new DateTime(2017, 11, 12);
            RegionLevel = Region.Country;
            Participants = new List<Person>();
            Winners = new Dictionary<Tour, List<Person>>();
        }

        public Competition(string name, Subject subject, string place, DateTime date, Region regionLevel)
        {
            Name = name;
            Subject = subject;
            Place = place;
            Date = date;
            RegionLevel = regionLevel;
            Participants = new List<Person>();
        }

        public void RegisterParticipant(Person person)
        {
            if (!Participants.Contains(person))
            {
                Participants.Add(person);
            }
        }

        public void GetWinners()
        {
            for (int i = 1; i <= 3; i++)
            {
                HoldCompetitionTour((Tour)i);
            }
        }

        private void HoldCompetitionTour(Tour tour)
        {
            if (tour == Tour.QuarterFinals)
            {
                var temp = Participants.OrderBy(s => s.Skill).Take(10).ToList();
                //Winners[tour] = Participants.OrderBy(s => s.Skill).Take(10).ToList();
                Winners[tour] = temp;
            }
            if (tour == Tour.SemiFinals)
            {
                Winners[tour] = Winners[Tour.QuarterFinals].OrderBy(s => s.Skill).Take(5).ToList();
            }
            if (tour == Tour.Finals)
            {
                Winners[tour] = Winners[Tour.SemiFinals].OrderBy(s => s.Skill).Take(3).ToList();
            }
        }

        public void CreateXML()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create("books.xml", settings);
        }

        public void CreateXML1()
        {
            GetWinners();
            XDocument xdoc = new XDocument();
            // создаем корневой элемент
            XElement tour = new XElement("tour");
            xdoc.Add(tour);
            foreach (KeyValuePair<Tour, List<Person>> kvp in Winners)
            {
                XElement currTour = new XElement(kvp.Key.ToString());               
                foreach (var p in kvp.Value)
                {
                    XElement winner = new XElement("winner");
                    winner.Add(new XElement("name", p.Name));
                    winner.Add(new XElement("points", null));
                    winner.Add(new XElement("skill", p.Skill));
                    currTour.Add(winner);
                }
                tour.Add(currTour);
            }

            //// создаем первый элемент
            //XElement tour = new XElement("QuarterFinals");
            //// создаем атрибут
            ////XAttribute tourAttr = new XAttribute("name", "quarterFinalsAttr");
            //XElement person = new XElement("person", "Person name");
            //XElement skill = new XElement("skill", "Person skill");
            //// добавляем атрибут и элементы в первый элемент
            ////tour.Add(tourAttr);
            //tour.Add(person);
            //tour.Add(skill);
            //// создаем корневой элемент
            //XElement tours = new XElement("tours");
            //// добавляем в корневой элемент
            //tours.Add(tour);
            //// добавляем корневой элемент в документ
            //xdoc.Add(tours);

            //// создаем первый элемент
            //XElement iphone6 = new XElement("phone");
            //// создаем атрибут
            //XAttribute iphoneNameAttr = new XAttribute("name", "iPhone 6");
            //XElement iphoneCompanyElem = new XElement("company", "Apple");
            //XElement iphonePriceElem = new XElement("price", "40000");
            //// добавляем атрибут и элементы в первый элемент
            //iphone6.Add(iphoneNameAttr);
            //iphone6.Add(iphoneCompanyElem);
            //iphone6.Add(iphonePriceElem);

            //// создаем второй элемент
            //XElement galaxys5 = new XElement("phone");
            //XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            //XElement galaxysCompanyElem = new XElement("company", "Samsung");
            //XElement galaxysPriceElem = new XElement("price", "33000");
            //galaxys5.Add(galaxysNameAttr);
            //galaxys5.Add(galaxysCompanyElem);
            //galaxys5.Add(galaxysPriceElem);

            //// создаем корневой элемент
            //XElement phones = new XElement("phones");
            //// добавляем в корневой элемент
            //phones.Add(iphone6);
            //phones.Add(galaxys5);

            //// добавляем корневой элемент в документ
            //xdoc.Add(phones);

            //сохраняем документ
            xdoc.Save("phones.xml");
        }

    }
}
