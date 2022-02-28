﻿using Services.Enums;
using Services.Interfaces;
using Services.Models;
using Services.RuleEngine;
using Services.TaxRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaxCalculator.Tests
{
    public class TaxCalculatorRuleEngineTests
    {
        private static IEnumerable<ITaxCalculatorRule> GetRules()
        {
            List<ITaxCalculatorRule> rules = new List<ITaxCalculatorRule>()
            {
                new CharityRule(0),
                new IncomeRule(1),
                new SocialContributionRule(1)
            };

            return rules;
        }

        [Theory()]
        [InlineData("George", 980, 0, 0, 0, 0)]
        [InlineData("Irina", 3400, 0, 240, 300, 0)]
        [InlineData("Mick", 2500, 150, 135, 202.5, 150)]
        [InlineData("Bill", 3600, 520, 224, 300, 360)]
        public void ValidateExamples(string name, 
            decimal grossIncome, 
            decimal charitySpent, 
            decimal expectedIncomeTax, 
            decimal expectedSocialTax, 
            decimal expectedCharityReduce)
        {
            var rules = GetRules();
            TaxCalculatorRuleEngine ruleEngine = new TaxCalculatorRuleEngine(rules);
            var taxes = ruleEngine.CalculateTax(new TaxIncome(grossIncome, charitySpent)).ToList();

            var incomeTax = taxes.FindTaxation(TaxRuleTypes.Income);
            var socialTax = taxes.FindTaxation(TaxRuleTypes.Social);
            var charityReduce = taxes.FindTaxation(TaxRuleTypes.Charity);

            Assert.Equal(expectedIncomeTax, incomeTax);
            Assert.Equal(expectedSocialTax, socialTax); 
            Assert.Equal(expectedCharityReduce, charityReduce);
        }
    }
}
