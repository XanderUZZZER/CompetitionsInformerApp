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

        public MainForm()
        {
            InitializeComponent();
            informer = new Informer();
            //informer.AddCompetition("Test competition", Subject.ComputerScience, "KNURE", DateTime.Parse("2017-11-12"), RegionLevel.Local);
            informer.Competitions.AddRange(Competition.LoadXML());
            TableRefresh();
        }

        private void AddCompetitionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TableRefresh();
        }

        private void AddCompetitionBtn_Click(object sender, EventArgs e)
        {
            addCompetitionForm = new AddCompetitionForm(informer);
            addCompetitionForm.FormClosing += AddCompetitionForm_FormClosing;
            addCompetitionForm.ShowDialog();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
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
                                             c.RegionLevel.ToString());
                c.SaveXML();
            }
        }
    }
}