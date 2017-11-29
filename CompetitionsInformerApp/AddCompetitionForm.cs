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


        public AddCompetitionForm(Informer informer)
        {
            InitializeComponent();
            cbSubject.DataSource = Enum.GetValues(typeof(Subject));
            cbRegion.DataSource = Enum.GetValues(typeof(RegionLevel));
            this.informer = informer;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (informer.AddCompetition(tbName.Text,
                                        (Subject)cbSubject.SelectedItem,
                                        tbPlace.Text,
                                        dtpDate.Value,
                                        (RegionLevel)cbRegion.SelectedItem))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("The competitions has been alredy added");
            }
        }
    }
}
