using Services.Enums;
using Services.Interfaces;
using Services.Models;
using Services.RuleEngine;
using Services.TaxRules;
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
            List<ITaxCalculatorRule> rules = new List<ITaxCalculatorRule>()
            {
                new CharityRule(0),
                new IncomeRule(1),
                new SocialContributionRule(1)
            };

            var engine = new TaxCalculatorRuleEngine(rules);
            var taxationResults = engine.CalculateTax(new TaxIncome(taxPayer.GrossIncome, taxPayer.CharitySpent.GetValueOrDefault()));

            var incomeTax = taxationResults.FindTaxation(TaxRuleTypes.Income);
            var socialTax = taxationResults.FindTaxation(TaxRuleTypes.Social);

            var taxes = new TaxesDTO
            {
                CharitySpent = taxPayer.CharitySpent.GetValueOrDefault(),
                GrossIncome = taxPayer.GrossIncome,
                IncomeTax = incomeTax,
                SocialTax = socialTax
            };


            return taxes;
        }
    }
}
