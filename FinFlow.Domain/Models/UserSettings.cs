namespace FinFlow.Domain.Models
{
    public class UserSettings
    {
        public Guid Id { get; set; }
        public decimal Income { get; set; }
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Percentage (0-100) that triggers warning for fixed expenses
        /// </summary>
        public decimal FixedExpensesThresholdPercent { get; set; }

        public decimal EmergencyFundTarget { get; set; }
    }
}