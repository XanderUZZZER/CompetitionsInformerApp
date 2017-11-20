using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public class Professor : Person, IAdvisor
    {
        public Subject Subject { get; }

        public Professor(string name, Subject subject) : base(name)
        {
            Subject = subject;
        }        
    }
}
