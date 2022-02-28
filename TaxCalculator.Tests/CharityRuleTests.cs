using Services.Models;
using Services.TaxRules;
using System;
using Xunit;

namespace TaxCalculator.Tests
{
    public class CharityRuleTests
    {
        [Theory]
        [InlineData(150, 3000, 150)]
        [InlineData(100, 1000, 200)]
        [InlineData(10, 10000, 10)]
        [InlineData(0, 1000, 0)]
        public void CalculateCharity(decimal expectedResult, decimal grossIncome, decimal charitySpent)
        {
            var rule = new CharityRule(0);
            var result = rule.Evaluate(new TaxIncome(grossIncome, charitySpent));
            var expectedIncomeAfterCharity = grossIncome - result.TaxValue;
            Assert.Equal(expectedResult, result.TaxValue);
            Assert.Equal(expectedIncomeAfterCharity, result.TaxIncome.GrossIncome);
        }
    }
}
