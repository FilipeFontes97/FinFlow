using FinFlow.Application.DTOs.Requests.Settings;
using FinFlow.Application.DTOs.Responses.Settings;

namespace FinFlow.Application.Interfaces.Settings
{
    public interface IUserSettingsService
    {
        Task<UserSettingsResponse> GetUserSettingsAsync();
        Task SaveUserSettingsAsync(UpdateUserSettingsRequest request);
    }
}