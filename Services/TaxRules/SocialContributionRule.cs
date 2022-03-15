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
    public class SocialContributionRule : TaxRuleBase
    {
        public SocialContributionRule(int order, TaxLimit taxLimit) : base(order, taxLimit) 
        {
            if (taxLimit.MaxLimit.GetValueOrDefault() <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(taxLimit.MaxLimit), "Must have value and to be greather than 0.");
            }
        }

        public override TaxationResult Evaluate(TaxIncome taxIncome)
        {
            if (!ShouldRun(taxIncome))
            {
                return new TaxationResult(0, taxIncome, TaxRuleTypes.Social);
            }

            var taxableValue = Math.Min(taxIncome.GrossIncome, this.TaxLimit.MaxLimit.Value) - this.TaxLimit.MinLimit;
            var taxValue = taxableValue * this.TaxLimit.Value / 100; // Have to divide by 100 because it's percents

            return new TaxationResult(taxValue, taxIncome, TaxRuleTypes.Social);
        }

        public override bool ShouldRun(TaxIncome taxIncome)
        {
            return taxIncome.GrossIncome > this.TaxLimit.MinLimit;
        }
    }
}
