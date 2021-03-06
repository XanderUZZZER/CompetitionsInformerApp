﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public class Informer
    {
        public List<Competition> Competitions { get; private set; } = new List<Competition>();
        public List<IParticipant<Person>> Participants { get; private set; } = new List<IParticipant<Person>>();
        public List<IAdvisor<Person>> Advisors { get; private set; } = new List<IAdvisor<Person>>();

        public Informer()
        {
            AddParticipants(Student.LoadXML());
            AddCompetitions(Competition.LoadXML());
        }

        public bool AddCompetition(string name, Subject subject, string place, DateTime date, RegionLevel regionLevel)
        {
            if (!Competitions.Select(n => n.Name).Contains(name))
            {
                Competitions.Add(new Competition(name, subject, place, date, regionLevel));
                return true;
            }
            return false;
        }

        public void AddParticipant(IParticipant<Person> participant)
        {
            Participants.Add(participant);
        }

        public void AddParticipants(List<IParticipant<Person>> participants)
        {
            Participants.AddRange(participants);
        }

        public void RemoveParticipant(IParticipant<Person> participant)
        {
            Participants.Remove(participant);
        }

        public void AddAdvisor(IAdvisor<Person> advisor)
        {
            Advisors.Add(advisor);
        }

        public void AddAdvisors(List<IAdvisor<Person>> advisors)
        {
            Advisors.AddRange(advisors);
        }

        public void AddCompetitions(List<Competition> competitions)
        {
            Competitions.AddRange(competitions);
        }

        public void LoadXML()
        {

        }
    }
}
