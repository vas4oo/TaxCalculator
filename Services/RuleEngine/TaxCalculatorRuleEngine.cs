using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RuleEngine
{
    public class TaxCalculatorRuleEngine
    {
        private readonly IEnumerable<ITaxCalculatorRule> _rules;
        public TaxCalculatorRuleEngine(IEnumerable<ITaxCalculatorRule> rules)
        {
            _rules = rules;
        }
        public List<TaxationResult> CalculateTax(TaxIncome taxIncome)
        {
            var result = new List<TaxationResult>();
            foreach (var rule in _rules)
            {
                //Has to check here as well, because each rule could change input for the next one.
                if (!rule.ShouldRun(taxIncome)) continue;

                var taxationResult = rule.Evaluate(taxIncome);
                taxIncome = taxationResult.TaxIncome;
                result.Add(taxationResult);
            }
            return result;
        }
    }
}
