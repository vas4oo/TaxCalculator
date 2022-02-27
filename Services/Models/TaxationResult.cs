using Services.Enums;

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
}
