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
        private Informer informer;
        public MainForm()
        {
            InitializeComponent();
            informer = new Informer();
            informer.AddCompetition("Test competition", Subject.ComputerScience, "KNURE", DateTime.Parse("2017-11-12"), RegionLevel.Local);            
        }

        private void AddCompetitionBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
