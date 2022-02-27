using Services.Enums;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TaxRules
{
    public class CharityRule : TaxRuleBase
    {
        public override TaxationResult Evaluate(TaxIncome taxIncome)
        {
            if (!ShouldRun(taxIncome))
            {
                return new TaxationResult(0, taxIncome, TaxRuleTypes.Charity);
            }

            decimal maxAllowedCharity = taxIncome.GrossIncome * TaxationSettings.MaxCharitySpentPercentage;
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
