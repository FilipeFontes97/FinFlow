using FinFlow.Domain.Enums;

namespace FinFlow.Domain.Models
{
    public class FixedExpense
    {
        public Guid Id { get; set; }
        public FixedExpensesCategory Category { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Notes { get; set; }
    }
}