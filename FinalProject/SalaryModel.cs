using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class SalaryModel
    {
        public string name { get; set; }
        public decimal hourlyRate { get; set; }
        public decimal hoursWorked { get; set; }
        public decimal grossPay { get; set; }
        public decimal netPay { get; set; }
        public decimal ssWitheld { get; set; }
        public decimal medicareWitheld { get; set; }
        public decimal stateTaxWitheld { get; set; }
        public decimal fedTaxWithheld { get; set; }

        public SalaryModel (string name, decimal hourlyRate, decimal hoursWorked)
        {
            this.name = name;
            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
            CalcGrossPay();
            CalcMedicare();
            CalcSocialSecurity();
            CalcTaxes();
            calcNetPay();
        }

        private void CalcGrossPay()
        {
            this.grossPay = hoursWorked * hourlyRate;
        }

        private void CalcMedicare()
        {
            this.medicareWitheld = this.grossPay * .0145m;
        }
        
        private void CalcSocialSecurity()
        {
            this.ssWitheld = this.grossPay * .062m;
        }

        private void CalcTaxes()
        {
            switch (grossPay)
            {
                case var n when n < 500:
                    stateTaxWitheld = grossPay * .02m;
                    fedTaxWithheld = grossPay * .05m;
                    break;
                case var n when n >= 500 && n < 1000:
                    stateTaxWitheld = grossPay * .04m;
                    fedTaxWithheld = grossPay * .1m;
                    break;
                case var n when n >= 100 && n < 1500:
                    stateTaxWitheld = grossPay * .06m;
                    fedTaxWithheld = grossPay * .15m;
                    break;
                case var n when n >= 1500 && n < 2000:
                    stateTaxWitheld = grossPay * .06m;
                    fedTaxWithheld = grossPay * .2m;
                    break;
                case var n when n >= 2000 && n < 3000:
                    stateTaxWitheld = grossPay * .06m;
                    fedTaxWithheld = grossPay * .25m;
                    break;
                default:
                    stateTaxWitheld = grossPay * .06m;
                    fedTaxWithheld = grossPay * .3m;
                    break;
            }
        }

        private void calcNetPay()
        {
            this.netPay = grossPay - stateTaxWitheld - fedTaxWithheld - medicareWitheld - ssWitheld;
        }
    }
}

