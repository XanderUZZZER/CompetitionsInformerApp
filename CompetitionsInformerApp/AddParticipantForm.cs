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
        private string name => tbName.Text;

        public AddParticipantForm(Informer informer, string competitionName)
        {
            InitializeComponent();
            cbSubject.DataSource = Enum.GetValues(typeof(Subject));
            this.informer = informer;
            competition = informer.Competitions.Where(n => n.Name == competitionName).First();
            participants = informer.Participants.Where(p => p.GetSkills().Select(s => s.Subject).Contains(competition.Subject)).ToList();
            TableRefresh();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            competition.Participants.Add(new Student(name));
            this.Close();
        }

        private void TableRefresh()
        {
            dgvParticipants.Rows.Clear();
            foreach (var p in participants)            
            {
                dgvParticipants.Rows.Add(((Person)p).Name, p.GetSkillLevel(competition.Subject), p.GetAdvisors().Count);                
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            TableRefresh();
        }
    }
}
