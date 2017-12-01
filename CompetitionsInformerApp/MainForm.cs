using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompetitionsInformer;

namespace CompetitionsInformerApp
{
    public partial class MainForm : Form
    {
        public Informer informer { get; private set; }
        private AddCompetitionForm addCompetitionForm;
        private AddParticipantForm addParticipantForm;
        private string currName => CompetitionsDGV.CurrentRow.Cells[0].Value.ToString();

        public MainForm()
        {
            InitializeComponent();
            informer = new Informer();
            TableRefresh();
        }        

        private void AddCompetitionBtn_Click(object sender, EventArgs e)
        {
            addCompetitionForm = new AddCompetitionForm(informer);
            addCompetitionForm.FormClosing += AddCompetitionForm_FormClosing;
            addCompetitionForm.ShowDialog();
        }
        private void AddCompetitionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TableRefresh();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (!informer.Competitions.Where(n => n.Name == currName).First().WasHold)
                informer.Competitions.Where(n => n.Name == currName).First().GetWinners();
            TableRefresh();

        }

        private void TableRefresh()
        {            
            CompetitionsDGV.Rows.Clear();
            foreach (var c in informer.Competitions)
            {
                CompetitionsDGV.Rows.Add(c.Name,
                                         c.Subject.ToString(),
                                         c.Place,
                                         c.Date.ToShortDateString(),
                                         c.RegionLevel.ToString(),
                                         c.Participants.Count,
                                         c.WasHold);
                c.SaveXML();
            }
        }

        private void btAddParticipant_Click(object sender, EventArgs e)
        { 
            addParticipantForm = new AddParticipantForm(informer, currName);
            addParticipantForm.FormClosing += AddParticipantForm_FormClosing;
            addParticipantForm.ShowDialog();
        }

        private void AddParticipantForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TableRefresh();
        }
    }
}