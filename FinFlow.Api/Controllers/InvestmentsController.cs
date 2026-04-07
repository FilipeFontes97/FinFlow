using FinFlow.Application.Interfaces.InvestmentRecords;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly IInvestmentReportService _investmentReportService;
        public InvestmentsController(IInvestmentReportService investmentReportService)
        {
            _investmentReportService = investmentReportService;
        }
        [HttpGet("investments/byYear")]
        public async Task<IActionResult> GetInvestmentSummary()
        {
            var result = await _investmentReportService.GetAllInvestmentsByYearAsync();
            return Ok(result);
        }
    }
}