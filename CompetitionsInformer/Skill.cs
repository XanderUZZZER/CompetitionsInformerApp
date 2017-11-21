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
        
        public Subject Subject { get; private set; }
        public int Level { get; private set; }

        public Skill(Subject subject)
        {
            Subject = subject;
            Level = luck.Next(1000, 100000) / 1000;
        }

        public Skill(Subject subject, int level)
        {
            Subject = subject;
            Level = level;
        }
    }
}