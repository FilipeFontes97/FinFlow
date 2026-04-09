namespace FinFlow.Application.DTOs.Responses.Settings
{
    public class UserSettingsResponse
    {
        public decimal Income { get; set; } = 0m;
        public decimal FixedExpensesThresholdPercent { get; set; } = 33;
        public decimal EmergencyFundTarget { get; set; } = 0m;
        public string Name { get; set; } = string.Empty;
    }
}