using Services.Interfaces;
using Services.Models;

namespace Services.TaxRules
{
    public abstract class TaxRuleBase : ITaxCalculatorRule
    {
        //TODO apply order
        public abstract bool ShouldRun(TaxIncome taxPayer);
        public abstract TaxationResult Evaluate(TaxIncome taxPayer);
    }
}
