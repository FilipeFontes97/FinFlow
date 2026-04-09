namespace FinFlow.Domain.Models
{
    public class UserSettings
    {
        public Guid Id { get; set; }
        public decimal Income { get; set; }

        /// <summary>
        /// Percentage (0-100) that triggers warning for fixed expenses
        /// </summary>
        public decimal FixedExpensesThresholdPercent { get; set; }
    }
}