using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public interface IAdvisor<T> where T : Person
    {
        Subject Subject { get; }
    }
}
