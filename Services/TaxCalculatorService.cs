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
using TaxCalculator.Services.Models;

namespace Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public TaxesDTO CalculateTaxes(TaxPayerDTO taxPayer)
        {
            List<ITaxCalculatorRule<TaxLimit>> rules = new List<ITaxCalculatorRule<TaxLimit>>()
            {
                new CharityRule(0, new TaxLimit(10, 0, 0)),
                new IncomeRule(1, new TaxLimit(10, 1000, null)),
                new SocialContributionRule(1, new TaxLimit(15, 1000, 3000))
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
