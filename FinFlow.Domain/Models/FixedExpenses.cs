namespace FinFlow.Domain.Models
{
    public class FixedExpenses
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Notes { get; set; }
    }
}