using FinFlow.Application.Interfaces.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{

    [ApiController]
    [Route("api/dashboard")]

    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetOverview()
        {
            var overview = await _dashboardService.GetOverviewAsync();
            return Ok(overview);
        }
    }
}