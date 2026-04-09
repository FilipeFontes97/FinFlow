using FinFlow.Application.DTOs.Responses.Settings;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Mappers.Settings
{
    public class UserSettingsMapper
    {
        public static UserSettingsResponse ToResponse(UserSettings entity)
        {
            return new UserSettingsResponse
            {
                Income = entity.Income,
                FixedExpensesThresholdPercent = entity.FixedExpensesThresholdPercent,
                Name = entity.Name,
                EmergencyFundTarget = entity.EmergencyFundTarget,
            };
        }
    }
}