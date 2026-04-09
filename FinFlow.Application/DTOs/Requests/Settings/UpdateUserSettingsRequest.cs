namespace FinFlow.Application.DTOs.Requests.Settings
{
    public class UpdateUserSettingsRequest
    {
        public decimal Income { get; set; }

        /// <summary>
        /// Percentage (0-100) that defines when fixed expenses trigger a warning
        /// </summary>
        public decimal FixedExpensesThresholdPercent { get; set; }

        public string Name { get; set; } = string.Empty;
        public decimal EmergencyFundTarget { get; set; }

    }
}