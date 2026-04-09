using FinFlow.Application.Interfaces.FinancialAccounts;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    [ApiController]
    [Route("api/projection")]
    public class ProjectionController : Controller
    {
        private readonly IFinancialProjectionService _service;

        public ProjectionController(IFinancialProjectionService service)
        {
            _service = service;
        }

        [HttpGet("emergency-fund")]
        public async Task<IActionResult> GetEmergencyFundCoverage()
        {
            var result = await _service.GetEmergencyFundPorjectionAsync();
            return Ok(result);
        }
    }
}
