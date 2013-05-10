using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exercise_8.Service;

namespace Exercise_8
{
    public partial class Form1 : Form
    {
        private IEnumerable<Division> divisions;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var financialService = new FinancialService();

            Task.Factory.StartNew(() =>
                {
                    // First get the divisions, because the region combo depends on this
                    divisions = financialService.GetDivisions();

                    return financialService.GetRegions();
                })
                .ContinueWith(x => { regionCombo.DataSource = x.Result; },
                              TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void regionCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            divisionCombo.DataSource = divisions.Where(d => d.Region == (Region) regionCombo.SelectedValue).ToList();
        }
    }
}