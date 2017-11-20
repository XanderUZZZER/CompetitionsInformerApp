using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public interface IParticipant
    {
        void AddSkill(Subject subject);
        bool ContainsSkill(Subject subject);
        int GetSkillLevel(Subject subject);
        void RemoveSkill(Subject subject);
    }
}
