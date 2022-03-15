using Services.Models;
using TaxCalculator.Services.Models;

namespace Services.Interfaces
{
    public interface ITaxCalculatorRule<T> where T : TaxLimit
    {
        TaxationResult Evaluate(TaxIncome taxPayer);
        bool ShouldRun(TaxIncome taxPayer);
        int Order { get; }
    }
}
