using Services.Models;

namespace Services.Interfaces
{
    public interface ITaxCalculatorRule
    {
        TaxationResult Evaluate(TaxIncome taxPayer);
        bool ShouldRun(TaxIncome taxPayer);
    }
}
