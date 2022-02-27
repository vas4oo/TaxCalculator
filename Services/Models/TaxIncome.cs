using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class TaxIncome
    {
        public TaxIncome(decimal grossValue, decimal charityValue)
        {
            this.CharitySpent = charityValue;
            this.GrossIncome = grossValue;
        }
        public decimal GrossIncome { get; set; }

        public decimal CharitySpent { get; set; }
    }
}
