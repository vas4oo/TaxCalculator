using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Services.Models;

namespace Services.RuleEngine
{
    public class TaxCalculatorRuleEngine
    {
        private readonly IEnumerable<ITaxCalculatorRule<TaxLimit>> rules;
        public TaxCalculatorRuleEngine(IEnumerable<ITaxCalculatorRule<TaxLimit>> rules)
        {
            this.rules = rules;
        }
        public IEnumerable<TaxationResult> CalculateTax(TaxIncome taxIncome)
        {
            var result = new List<TaxationResult>();
            var orderedRules = GetTaxRulesByOrder();
            foreach (var rule in orderedRules)
            {
                //Has to check here as well, because each rule could change input for the next one.
                if (!rule.ShouldRun(taxIncome)) continue;

                var taxationResult = rule.Evaluate(taxIncome);
                taxIncome = taxationResult.TaxIncome;
                result.Add(taxationResult);
            }
            return result;
        }
        private IEnumerable<ITaxCalculatorRule<TaxLimit>> GetTaxRulesByOrder()
        {
            return this.rules.OrderBy(r => r.Order);
        }
    }
}
