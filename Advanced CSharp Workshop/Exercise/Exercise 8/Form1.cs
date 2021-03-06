﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Exercise_8.Service;

namespace Exercise_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IEnumerable<Division> divisions;
        FinancialService financialService = new FinancialService();

        private void Form1_Load(object sender, EventArgs e)
        {
            // First get the divisions, because the region combo depends on this
            divisions = financialService.GetDivisions();

            regionCombo.DataSource =  financialService.GetRegions();
        }

        private void regionCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            divisionCombo.DataSource = divisions.Where(d => d.Region == (Region)regionCombo.SelectedValue).ToList();
        }

        private void calculateRevenueButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;

            decimal revenue = financialService.GetRevenue((Region) regionCombo.SelectedValue);

            revenueTextBox.Text = revenue.ToString(CultureInfo.InvariantCulture);

            cancelButton.Enabled = false;
        }
    }
}