using Services.Enums;
using Services.Interfaces;
using Services.Models;
using Services.RuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public TaxesDTO CalculateTaxes(TaxPayerDTO taxPayer)
        {
            var ruleType = typeof(ITaxCalculatorRule);
            IEnumerable<ITaxCalculatorRule> rules = this.GetType().Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
                .Select(r => Activator.CreateInstance(r) as ITaxCalculatorRule);

            var engine = new TaxCalculatorRuleEngine(rules);
            var taxationResults = engine.CalculateTax(new TaxIncome(taxPayer.GrossIncome, taxPayer.CharitySpent.GetValueOrDefault()));

            var incomeTax = FindTaxation(taxationResults, TaxRuleTypes.Income);
            var socialTax = FindTaxation(taxationResults, TaxRuleTypes.Social);

            var taxes = new TaxesDTO
            {
                CharitySpent = taxPayer.CharitySpent.GetValueOrDefault(),
                GrossIncome = taxPayer.GrossIncome,
                IncomeTax = incomeTax,
                SocialTax = socialTax
            };


            return taxes;
        }

        private static decimal FindTaxation(IEnumerable<TaxationResult> taxationResults, TaxRuleTypes taxRuleType)
        {
            var r = taxationResults.FirstOrDefault(r => r.TaxType.Equals(taxRuleType));
            if(r == null)
                return 0;
            return r.TaxValue;
        }
    }
}
