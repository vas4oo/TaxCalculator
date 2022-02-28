using Services.Models;
using Services.TaxRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaxCalculator.Tests
{
    public class IncomeRuleTest
    {
        [Theory]
        [InlineData(200, 3000)]
        [InlineData(0, 1000)]
        [InlineData(900, 10000)]
        [InlineData(20, 1200)]
        public void CalculateIncome(decimal expectedResult, decimal grossIncome)
        {
            var rule = new IncomeRule(0);
            var result = rule.Evaluate(new TaxIncome(grossIncome, 0));
            Assert.Equal(expectedResult, result.TaxValue);
            
            Assert.Equal(grossIncome, result.TaxIncome.GrossIncome);
        }
    }
}
