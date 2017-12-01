using CompetitionsInformer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompetitionsInformerApp
{
    public partial class AddParticipantForm : Form
    {
        private Informer informer;
        private Competition competition;
        private List<IParticipant<Person>> participants;
        private string currParticipantName => dgvParticipants.CurrentRow.Cells[0].Value.ToString();

        public AddParticipantForm(Informer informer, string competitionName)
        {
            InitializeComponent();
            this.informer = informer;
            competition = informer.Competitions.Where(n => n.Name == competitionName).First();
            participants = informer.Participants.Where(p => (p.GetSkills().Select(s => s.Subject).Contains(competition.Subject)) &&
                                                            !(competition.Participants.Contains(p))).ToList();
            TableRefresh();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            competition.RegisterParticipant(participants.Where(p => ((Person)p).Name == currParticipantName).First());
            this.Close();

        }

        private void TableRefresh()
        {
            dgvParticipants.Rows.Clear();
            if (participants.Count > 0)
            {
                foreach (var p in participants)
                {
                    dgvParticipants.Rows.Add(((Person)p).Name, p.GetSkillLevel(competition.Subject), p.GetAdvisors().Count);
                }
                btAdd.Enabled = true;
            }
            else
            {
                btAdd.Enabled = false;
            }            
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            TableRefresh();
        }
    }
}
