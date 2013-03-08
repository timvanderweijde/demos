using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exercise_6.Service;
using Region = Exercise_6.Service.Region;

namespace Exercise_6
{
    public partial class Form1 : Form
    {
        private IFinancialService financialService;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            financialService = new FinancialService();

            comboBox1.DataSource = Enum.GetNames(typeof (Region));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedRegion = (Region) Enum.Parse(typeof (Region), comboBox1.SelectedValue.ToString());

            decimal revenue = financialService.GetRevenue(selectedRegion);

            resultLabel.Text = revenue.ToString("c");
        }
    }
}
