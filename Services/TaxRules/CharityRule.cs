using Services.Enums;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Services.Models;

namespace Services.TaxRules
{
    public class CharityRule : TaxRuleBase
    {
        public CharityRule(int order, TaxLimit taxLimit) : base(order, taxLimit) { }

        public override TaxationResult Evaluate(TaxIncome taxIncome)
        {
            if (!ShouldRun(taxIncome))
            {
                return new TaxationResult(0, taxIncome, TaxRuleTypes.Charity);
            }

            decimal maxAllowedCharity = taxIncome.GrossIncome * this.TaxLimit.Value / 100; // Have to divide by 100 because it's percents
            decimal charityAmount = Math.Min(maxAllowedCharity, taxIncome.CharitySpent);
            taxIncome.GrossIncome -= charityAmount; 
            var taxResult = new TaxationResult(charityAmount, taxIncome, TaxRuleTypes.Charity);
            return taxResult;
        }

        public override bool ShouldRun(TaxIncome taxIncome)
        {
            return taxIncome.CharitySpent > 0;
        }
    }
}
