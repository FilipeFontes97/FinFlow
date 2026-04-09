namespace FinFlow.Application.DTOs.Responses.Settings
{
    public class UserSettingsResponse
    {
        public decimal Income { get; set; } = 0m;
        public decimal FixedExpensesThresholdPercent { get; set; } = 33;
    }
}