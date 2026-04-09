using FinFlow.Domain.Models;

namespace FinFlow.Application.Interfaces.Settings
{
    public interface IUserSettingsRepository
    {
        Task<UserSettings> GetUserSettingsAsync();
        Task SaveAsync(UserSettings settings);
    }
}