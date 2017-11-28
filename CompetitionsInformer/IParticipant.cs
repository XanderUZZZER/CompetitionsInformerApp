using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public interface IParticipant<T> where T : Person
    {
        bool HasSkill(Subject subject);
        void AddSkill(Subject subject);
        void AddSkill(Subject subject, int level);
        void AlterSkillLevel(Subject subject, int level);
        int GetSkillLevel(Subject subject);
        void RemoveSkill(Subject subject);
        List<Skill> GetSkills();        
        void AddAdvisor(IAdvisor<T> advisor);
        List<IAdvisor<T>> GetAdvisors();
        void AddWin(Subject subject);
        void SaveXML();
    }
}
