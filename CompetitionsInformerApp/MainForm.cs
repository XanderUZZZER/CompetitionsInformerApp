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
        private AddCompetitionForm addCompetitionForm;
        public MainForm()
        {
            InitializeComponent();
            informer = new Informer();
            informer.AddCompetition("Test competition", Subject.ComputerScience, "KNURE", DateTime.Parse("2017-11-12"), RegionLevel.Local);            
            foreach (var c in informer.Competitions)
            {                
                {
                    CompetitionsDGV.Rows.Add(c.Name, 
                                             c.Subject.ToString(), 
                                             c.Place,
                                             c.Date.ToShortDateString(),
                                             c.RegionLevel.ToString());
                }                
            }           
            
        }

        private void AddCompetitionBtn_Click(object sender, EventArgs e)
        {
            addCompetitionForm = new AddCompetitionForm();
            addCompetitionForm.ShowDialog();
            //foreach (var s in informer.Competitions)
            //    s.SaveXML();
            
            //foreach (var c in informer.Competitions)
            //{
            //    foreach(var x in c.LoadXML())
            //    {
            //        CompetitionsDGV.Rows.Add(x.Name,
            //                                 x.Subject.ToString(),
            //                                 x.Place,
            //                                 x.Date.ToShortDateString(),
            //                                 x.RegionLevel.ToString());
            //    }
            //}
        }
    }
}