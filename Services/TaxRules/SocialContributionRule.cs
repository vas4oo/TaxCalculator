using Services.Enums;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TaxRules
{
    public class SocialContributionRule : TaxRuleBase
    {
        public override TaxationResult Evaluate(TaxIncome taxIncome)
        {
            if (!ShouldRun(taxIncome))
            {
                return new TaxationResult(0, taxIncome, TaxRuleTypes.Social);
            }

            var taxableValue = Math.Min(taxIncome.GrossIncome, TaxationSettings.SocialContributionsMaximumAmount) - TaxationSettings.TaxationOnlyAbove;
            var taxValue = taxableValue * TaxationSettings.SocialContributionsPercentage;

            return new TaxationResult(taxValue, taxIncome, TaxRuleTypes.Social);
        }

        public override bool ShouldRun(TaxIncome taxIncome)
        {
            return taxIncome.GrossIncome > TaxationSettings.NonTaxableMinimum;
        }
    }
}
