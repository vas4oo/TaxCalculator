using Services.Enums;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TaxRules
{
    public class IncomeRule : TaxRuleBase
    {
        public override TaxationResult Evaluate(TaxIncome taxIncome)
        {
            if (!ShouldRun(taxIncome))
            {
                return new TaxationResult(0, taxIncome, TaxRuleTypes.Income);
            }

            var taxableValue = taxIncome.GrossIncome - TaxationSettings.TaxationOnlyAbove;
            var taxValue = taxableValue * TaxationSettings.IncomeTaxPercentage;

            return new TaxationResult(taxValue, taxIncome, TaxRuleTypes.Income);
        }

        public override bool ShouldRun(TaxIncome taxIncome)
        {
            return taxIncome.GrossIncome > TaxationSettings.NonTaxableMinimum;
        }
    }
}
