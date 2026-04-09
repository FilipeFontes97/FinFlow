using FinFlow.Application.DTOs.Requests.Settings;
using FinFlow.Application.Interfaces.Settings;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingsController : ControllerBase
    {
        private readonly IUserSettingsService _settingsService;

        public SettingsController(IUserSettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            var settings = await _settingsService.GetUserSettingsAsync();
            return Ok(settings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSettings([FromBody] UpdateUserSettingsRequest request)
        {
            await _settingsService.SaveUserSettingsAsync(request);
            return NoContent();
        }
    }
}