using FinFlow.Domain.Enums;

namespace FinFlow.Application.DTOs.Requests.FixedExpenses
{
    public class CreateFixedExpenseRequest
    {
        public FixedExpensesCategory Category { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Notes { get; set; }
    }
}
