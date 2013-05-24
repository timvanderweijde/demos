using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            // First get the divisions, because the region combo depends on this
            divisions = await financialService.GetDivisionsAsync();

            regionCombo.DataSource = await financialService.GetRegionsAsync();
        }

        private void regionCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            divisionCombo.DataSource = divisions.Where(d => d.Region == (Region) regionCombo.SelectedValue).ToList();
        }

        private async void calculateRevenueButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            cts = new CancellationTokenSource();
            revenueTextBox.Text = "Calculating";

            try
            {
                decimal revenue = await financialService.GetRevenueAsync((Region) regionCombo.SelectedValue, cts.Token);

                revenueTextBox.Text = revenue.ToString(CultureInfo.InvariantCulture);
                cancelButton.Enabled = false;
            }
            catch (OperationCanceledException)
            {
                revenueTextBox.Text = string.Empty;
            }
            catch (InvalidOperationException ex)
            {
                revenueTextBox.Text = string.Empty;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cancelButton.Enabled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}