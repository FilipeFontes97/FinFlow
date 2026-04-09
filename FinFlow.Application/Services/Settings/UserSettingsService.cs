using FinFlow.Application.DTOs.Requests.Settings;
using FinFlow.Application.DTOs.Responses.Settings;
using FinFlow.Application.Interfaces.Settings;
using FinFlow.Application.Mappers.Settings;

namespace FinFlow.Application.Services.Settings
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly IUserSettingsRepository _userSettingsRepository;

        public UserSettingsService(IUserSettingsRepository userSettingsRepository)
        {
            _userSettingsRepository = userSettingsRepository;
        }

        public async Task<UserSettingsResponse> GetUserSettingsAsync()
        {
            var userSettings = await _userSettingsRepository.GetUserSettingsAsync();

            return UserSettingsMapper.ToResponse(userSettings);
        }

        public async Task SaveUserSettingsAsync(UpdateUserSettingsRequest request)
        {
            var userSettings = await _userSettingsRepository.GetUserSettingsAsync();

            userSettings.Income = request.Income;
            userSettings.FixedExpensesThresholdPercent = request.FixedExpensesThresholdPercent;
            userSettings.EmergencyFundTarget = request.EmergencyFundTarget;
            userSettings.Name = request.Name;

            await _userSettingsRepository.SaveAsync(userSettings);
        }
    }
}