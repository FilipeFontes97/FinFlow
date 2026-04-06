using FinFlow.Domain.Enums;

namespace FinFlow.Application.DTOs.Responses.FixedExpenses
{
    public class FixedExpensesResponse
    {
        public Guid Id { get; set; }
        public FixedExpensesCategory Category { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        public int? PaymentDay { get; set; }
        public string? Notes { get; set; }
    }
}