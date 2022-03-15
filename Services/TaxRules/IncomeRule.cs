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
    public class IncomeRule : TaxRuleBase
    {
        public IncomeRule(int order, TaxLimit taxLimit) : base(order, taxLimit) { }

        public override TaxationResult Evaluate(TaxIncome taxIncome)
        {
            if (!ShouldRun(taxIncome))
            {
                return new TaxationResult(0, taxIncome, TaxRuleTypes.Income);
            }

            var taxableValue = taxIncome.GrossIncome - this.TaxLimit.MinLimit;
            var taxValue = taxableValue * this.TaxLimit.Value / 100 ; // Have to divide by 100 because it's percents

            return new TaxationResult(taxValue, taxIncome, TaxRuleTypes.Income);
        }

        public override bool ShouldRun(TaxIncome taxIncome)
        {
            return taxIncome.GrossIncome > this.TaxLimit.MinLimit;
        }
    }
}
