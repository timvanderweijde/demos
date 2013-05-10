using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exercise_8.Service;

namespace Exercise_8
{
    public partial class Form1 : Form
    {
        private readonly FinancialService financialService = new FinancialService();
        private CancellationTokenSource cts;
        private IEnumerable<Division> divisions;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void calculateRevenueButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            cts = new CancellationTokenSource();
            revenueTextBox.Text = "Calculating";

            Task.Factory.StartNew(x => financialService.GetRevenue((Region) x, cts.Token), regionCombo.SelectedValue,
                                  cts.Token)
                .ContinueWith(x =>
                    {
                        if (x.Exception != null)
                        {
                            x.Exception.Flatten().Handle(ex =>
                                {
                                    if (ex is InvalidOperationException)
                                    {
                                        MessageBox.Show(ex.Message);
                                        revenueTextBox.Text = string.Empty;
                                        return true;
                                    }
                                    return false;
                                });
                        }
                        else
                        {
                            revenueTextBox.Text = x.Result.ToString(CultureInfo.InvariantCulture);
                            cancelButton.Enabled = false;
                        }
                    }, new CancellationToken(), TaskContinuationOptions.NotOnCanceled,
                              TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(x =>
                    {
                        revenueTextBox.Text = string.Empty;
                        cancelButton.Enabled = false;
                    }, new CancellationToken(), TaskContinuationOptions.OnlyOnCanceled,
                              TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(x => { cancelButton.Enabled = false; }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}