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
    public partial class AddCompetitionForm : Form
    {
        private Competition competition;
        public AddCompetitionForm()
        {
            InitializeComponent();
            cbSubject.DataSource = Enum.GetValues(typeof(Subject));
            cbRegion.DataSource = Enum.GetValues(typeof(RegionLevel));
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            competition = new Competition(tbName)
        }
    }
}
