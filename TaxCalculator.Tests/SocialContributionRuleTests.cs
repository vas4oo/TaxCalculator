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
    public class TaxCalculatorTests
    {
        [Theory]
        [InlineData(300, 4000)]
        [InlineData(0, 1000)]
        [InlineData(30, 1200)]
        public void CalculateSocialContribution(decimal expectedResult, decimal grossIncome)
        {
            var rule = new SocialContributionRule(0);
            var result = rule.Evaluate(new TaxIncome(grossIncome, 0));
            Assert.Equal(expectedResult, result.TaxValue);
            Assert.Equal(grossIncome, result.TaxIncome.GrossIncome);   
        }
    }
}
