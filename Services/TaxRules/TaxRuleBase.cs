using Services.Interfaces;
using Services.Models;

namespace Services.TaxRules
{
    public abstract class TaxRuleBase : ITaxCalculatorRule
    {
        public int Order { get; }

        // Protected because we want to access it in derived classes too
        protected TaxRuleBase(int order)
        {
            Order = order;
        }
        public abstract bool ShouldRun(TaxIncome taxPayer);
        public abstract TaxationResult Evaluate(TaxIncome taxPayer);
    }
}
