using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public class Skill
    {
        private static Random luck = new Random();
        private Dictionary<Subject, int> skills = new Dictionary<Subject, int>();

        public int this[Subject subject]
        {
            get
            {
                return skills[subject];
            }
            private set
            {
                skills[subject] = value;
            }
        }

        public Skill()
        {
        }

        public Skill(Subject subject)
        {
            Add(subject);
        }

        public void Add(Subject subject)
        {
            if (!skills.ContainsKey(subject))
            {
                Thread.Sleep(100);
                skills[subject] = luck.Next(1000 , 100000) / 1000;
            }
        }

        public bool Contains(Subject subject)
        {
            return skills.ContainsKey(subject);
        }

        public void Remove(Subject subject)
        {
            if (skills.ContainsKey(subject))
            {
                skills.Remove(subject);
            }
        }
    }
}