using Services.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models
{
    public class TaxationResult
    {
        public TaxationResult(decimal taxValue, TaxIncome taxIncome, TaxRuleTypes taxType)
        {
            this.TaxIncome = taxIncome;
            this.TaxValue = taxValue;
            this.TaxType = taxType;
        }
        public decimal TaxValue { get; private set; }
        public TaxIncome TaxIncome { get; private set; }

        public TaxRuleTypes TaxType { get; set; }
    }

    public static class TaxationResultExtensions
    {
        public static decimal FindTaxation(this IEnumerable<TaxationResult> taxationResults, TaxRuleTypes taxRuleType)
        {
            var r = taxationResults.FirstOrDefault(r => r.TaxType.Equals(taxRuleType));
            if (r == null)
                return 0;
            return r.TaxValue;
        }
    }
}
