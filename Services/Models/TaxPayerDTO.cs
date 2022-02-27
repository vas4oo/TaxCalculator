using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class TaxPayerDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)+$", ErrorMessage = "Fullname must be at least two words separated by space. Allowed symbols letters and spaces only.")]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(@"^\d{5,10}$", ErrorMessage = "SSN must be a valid 5 to 10 digits number.")]
        public string SSN { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal GrossIncome { get; set; }
        [Range(0, int.MaxValue)]
        public decimal? CharitySpent { get; set; }
    }
}
