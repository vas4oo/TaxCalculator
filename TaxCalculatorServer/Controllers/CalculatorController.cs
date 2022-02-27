using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using Services.Models;

namespace TaxCalculatorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly ITaxCalculatorService taxCalculatorService;
        private readonly IMemoryCache memoryCache;

        public CalculatorController(ITaxCalculatorService taxCalculatorService, IMemoryCache memoryCache)
        {
            this.taxCalculatorService = taxCalculatorService;
            this.memoryCache = memoryCache;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Calculate([FromBody] TaxPayerDTO taxPayer)
        {
            if (memoryCache.TryGetValue(taxPayer.SSN, out TaxesDTO cachedTaxes))
            {
                if(cachedTaxes.GrossIncome.Equals(taxPayer.GrossIncome) && cachedTaxes.CharitySpent.Equals(taxPayer.CharitySpent.GetValueOrDefault()))
                    return Ok(cachedTaxes);
            }
            var taxResult = taxCalculatorService.CalculateTaxes(taxPayer);
            memoryCache.Set(taxPayer.SSN, taxResult);
            return Ok(taxResult);
        }
    }
}
