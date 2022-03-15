using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Services.Models
{
    public class TaxLimit
    {
        public TaxLimit(decimal value, decimal minLimit, decimal? maxLimit)
        {
            if (minLimit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minLimit));
            }
            if (maxLimit.HasValue && maxLimit.Value < decimal.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLimit));
            }
            if (maxLimit.HasValue && maxLimit.Value < minLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLimit), $"Value:'{maxLimit.Value}' has to be greater than {nameof(minLimit)}:'{minLimit}'.");
            }
            if (value < decimal.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            this.MinLimit = minLimit;
            this.MaxLimit = maxLimit;
            this.Value = value;
        }

        public decimal MinLimit { get; set; }
        public decimal? MaxLimit { get; set; }
        public decimal Value { get; set; }
    }
}
