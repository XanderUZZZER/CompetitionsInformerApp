﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public List<IParticipant<Person>> Participants { get; private set; }
        public Dictionary<Tour, List<IParticipant<Person>>> Winners { get; private set; }
        public bool WasHold { get; private set; } = false;

        public Competition(string name, Subject subject, string place, DateTime date, RegionLevel regionLevel, bool wasHold = false)
        {
            Name = name;
            Subject = subject;
            Place = place;
            Date = date;
            RegionLevel = regionLevel;
            Participants = new List<IParticipant<Person>>();
            Winners = new Dictionary<Tour, List<IParticipant<Person>>>();
            WasHold = wasHold;
        }

        public void RegisterParticipant(IParticipant<Person> participant)
        {
            if ((!Participants.Contains(participant)) &&
                (participant.HasSkill(Subject)))
            {
                Participants.Add(participant);
            }
        }

        public void RegisterParticipant(List<IParticipant<Person>> participants)
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
            foreach (var winner in Winners[Tour.Finals].Take(3))
            {
                winner.AddWin(Subject);
            }
            WasHold = true;
        }

        private void HoldCompetitionTour(Tour tour)
        {
            Winners[tour] = Participants.OrderByDescending(s => s.GetSkillLevel(Subject)).Take((int)tour).ToList();
        }

        public static List<Competition> LoadXML()
        {
            List<Competition> competitions = new List<Competition>();
            try
            {
                XDocument xdoc = XDocument.Load("competitions.xml");
                foreach (XElement el in xdoc.Element("competitions").Elements("competition"))
                {
                    string name = el.Attribute("name").Value.ToString();
                    Subject subject = (Subject)Enum.Parse(typeof(Subject), el.Element("subject").Value.ToString());
                    string place = el.Element("place").Value.ToString();
                    DateTime date = DateTime.ParseExact(el.Element("date").Value.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    RegionLevel region = (RegionLevel)Enum.Parse(typeof(RegionLevel), el.Element("region").Value.ToString()); 
                    bool wasHold = Convert.ToBoolean(el.Element("hold").Value);
                    competitions.Add(new Competition(name, subject, place, date, region, wasHold));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("File is corrupted");
            }
            return competitions;
        }

        public void SaveXML()
        {
            List<Competition> tempCompetitions = LoadXML();
            if (!tempCompetitions.Select(n => n.Name).Contains(this.Name))
            {
                tempCompetitions.Add(this);
            }
            XDocument xDoc = new XDocument();
            XElement root = new XElement("competitions");
            XElement competitionElement;
            XAttribute competitionAttrName;
            XElement subjectElement;
            XElement placeElement;
            XElement dateElement;
            XElement reginLevelElement;
            XElement holdElement;

            foreach (var competition in tempCompetitions)
            {
                competitionElement = new XElement("competition");
                competitionAttrName = new XAttribute("name", competition.Name);
                subjectElement = new XElement("subject", competition.Subject.ToString());
                placeElement = new XElement("place", competition.Place); ;
                dateElement = new XElement("date", competition.Date.ToShortDateString()); ;
                reginLevelElement = new XElement("region", competition.RegionLevel.ToString());
                holdElement = new XElement("hold", competition.WasHold);
                competitionElement.Add(competitionAttrName);
                competitionElement.Add(subjectElement);
                competitionElement.Add(placeElement);
                competitionElement.Add(dateElement);
                competitionElement.Add(reginLevelElement);
                competitionElement.Add(holdElement);
                root.Add(competitionElement);
            }
            xDoc.Add(root);
            xDoc.Save("competitions.xml");
        }
    }
}
