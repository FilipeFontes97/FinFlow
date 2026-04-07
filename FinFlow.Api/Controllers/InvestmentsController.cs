using FinFlow.Application.DTOs.Requests.InvestmentRecords;
using FinFlow.Application.Interfaces.InvestmentRecords;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : Controller
    {
        private readonly IInvestmentService _investmentReportService;
        private readonly IInvestmentReportService _investmentSummaryService;
        public InvestmentsController(IInvestmentService investmentReportService, IInvestmentReportService investmentSummaryService)
        {
            _investmentReportService = investmentReportService;
            _investmentSummaryService = investmentSummaryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvestment([FromBody] AddInvestmentRequest request)
        {
            await _investmentReportService.AddInvestmentAsync(request);
            return NoContent();
        }

        [HttpGet("byYear")]
        public async Task<IActionResult> GetInvestmentSummary()
        {
            var summary = await _investmentSummaryService.GetAllInvestmentsByYearAsync();
            return Ok(summary);

        }
    }
}