using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public abstract class Person
    {
        public string Name { get; }
        public int Skill { get; }

        public Person(string name, int skill)
        {
            Name = name;
            Skill = skill;
        }
    }
}
