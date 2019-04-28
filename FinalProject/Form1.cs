using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        private List<SalaryModel> _SalarayModel;
        

        public Form1()
        {
            InitializeComponent();
            _SalarayModel = new List<SalaryModel>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LvwIndividual.View = View.Details;
            LvwIndividual.GridLines = true;
            LvwIndividual.FullRowSelect = true;
            LvwIndividual.Columns.Add("Key", 0);
            LvwIndividual.Columns.Add("name", 100);
            LvwIndividual.Columns.Add("grossPay", 100);
            LvwIndividual.Columns.Add("netPay", 100);
            LvwIndividual.Columns.Add("ssWithheld", 100);
            LvwIndividual.Columns.Add("medicareWitheld", 100);
            LvwIndividual.Columns.Add("stateIncomeTaxWitheld", 100);
            LvwIndividual.Columns.Add("federalIncomeTaxWithheld", 100);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SalaryModel model = new SalaryModel(NameTxtBox.Text, Convert.ToDecimal(HourlyRateTxtBox.Text), Convert.ToDecimal(HoursWorkedTxtBox.Text));
            _SalarayModel.Add(model);

            LvwIndividual.Items.Clear();
            NameTxtBox.Clear();
            HourlyRateTxtBox.Clear();
            HoursWorkedTxtBox.Clear();

            decimal totalGrossPay = 0;
            decimal totalNetPay = 0;
            decimal totalSsWitheld = 0;
            decimal totalMedicareWitheld = 0;
            decimal totalStateTaxWitheld = 0;
            decimal totalFederalTaxWitheld = 0;

            foreach (SalaryModel s in _SalarayModel)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(s.name);
                lvi.SubItems.Add(s.grossPay.ToString("#.##"));
                lvi.SubItems.Add(s.netPay.ToString("#.##"));
                lvi.SubItems.Add(s.ssWitheld.ToString("#.##"));
                lvi.SubItems.Add(s.medicareWitheld.ToString("#.##"));
                lvi.SubItems.Add(s.stateTaxWitheld.ToString("#.##"));
                lvi.SubItems.Add(s.fedTaxWithheld.ToString("#.##"));              

                LvwIndividual.Items.Add(lvi);

                totalGrossPay += s.grossPay;
                totalNetPay += s.netPay;
                totalSsWitheld += s.ssWitheld;
                totalMedicareWitheld+= s.medicareWitheld;
                totalStateTaxWitheld += s.stateTaxWitheld;
                totalFederalTaxWitheld += s.fedTaxWithheld;
            }

            TotalGrossLbl.Text = totalGrossPay.ToString("#.##");
            TotalNetLbl.Text = totalNetPay.ToString("#.##");
            TotalSsLbl.Text = totalSsWitheld.ToString("#.##");
            TotalMedicareLbl.Text = totalMedicareWitheld.ToString("#.##");
            TotalStateLbl.Text = totalStateTaxWitheld.ToString("#.##");
            TotalFedLbl.Text = totalFederalTaxWitheld.ToString("#.##");
        }
    }
}
