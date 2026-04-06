using FinFlow.Domain.Enums;

namespace FinFlow.Application.DTOs.Requests.FixedExpenses
{
    public class UpdateFixeExpenseRequest
    {
        public FixedExpensesCategory Category { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        public int? PaymentDay { get; set; }
        public string? Notes { get; set; }
    }
}
