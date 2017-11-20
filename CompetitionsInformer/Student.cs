using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionsInformer
{
    public class Student : Person, IParticipant
    {
        private Skill skills { get; set; } = new Skill();
        private List<IAdvisor> advisors { get; set; } = new List<IAdvisor>();

        public Student(string name) : base(name)
        {
        }

        public void AddSkill(Subject subject)
        {
            skills.Add(subject);
        }

        public bool ContainsSkill(Subject subject)
        {
            return skills.Contains(subject);
        }

        public int GetSkillLevel(Subject subject)
        {
            if (skills.Contains(subject))
            {
                double bonus = 1;
                foreach (var advisor in advisors)
                {
                    if (advisor.Subject == subject)
                    {
                        bonus += 0.1;
                    }
                }
                return (int)(skills[subject] * bonus);
            }
            return -1;
        }

        public void RemoveSkill(Subject subject)
        {
            skills.Remove(subject);
        }

        public void AddAdviser(IAdvisor advisor)
        {
            if (!advisors.Contains(advisor))
            {
                advisors.Add(advisor);
            }
        }

        public List<IAdvisor> GetAdvisors()
        {
            return advisors;
        }

        public void RemoveAdviser(IAdvisor advisor)
        {
            if (advisors.Contains(advisor))
            {
                advisors.Remove(advisor);
            }
        }
    }
}
