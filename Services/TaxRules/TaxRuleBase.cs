using Services.Interfaces;
using Services.Models;
using TaxCalculator.Services.Models;

namespace Services.TaxRules
{
    public abstract class TaxRuleBase : ITaxCalculatorRule<TaxLimit>
    {
        public int Order { get; }
        public TaxLimit TaxLimit { get; }

        // Protected because we want to access it in derived classes too
        protected TaxRuleBase(int order, TaxLimit taxLimit)
        {
            Order = order;
            TaxLimit = taxLimit;
        }
        public abstract bool ShouldRun(TaxIncome taxPayer);
        public abstract TaxationResult Evaluate(TaxIncome taxPayer);
    }
}
