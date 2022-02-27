using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaxationSettings
    {
        public const decimal NonTaxableMinimum = 1000;
        public const decimal IncomeTaxPercentage = 0.1m; // 10 / 100 = 0.1
        public const decimal TaxationOnlyAbove = 1000;
        public const decimal SocialContributionsPercentage = 0.15m; // 15 / 100 = 0.15
        public const decimal SocialContributionsMaximumAmount = 3000;
        public const decimal MaxCharitySpentPercentage = 0.1m; // 10 / 100 = 0.1
    }
}
