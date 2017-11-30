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
        private Informer informer;
        private string name => tbName.Text;
        private Subject subject => (Subject)cbSubject.SelectedItem;
        private string place => tbPlace.Text;
        private DateTime date => dtpDate.Value;
        private RegionLevel region => (RegionLevel)cbRegion.SelectedItem;

        public AddCompetitionForm(Informer informer)
        {
            InitializeComponent();
            cbSubject.DataSource = Enum.GetValues(typeof(Subject));
            cbRegion.DataSource = Enum.GetValues(typeof(RegionLevel));
            this.informer = informer;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (informer.AddCompetition(name, subject, place, date, region))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("The competition has been alredy added");
            }
        }
    }
}
