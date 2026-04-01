using FinFlow.Domain.Enums;

namespace FinFlow.Application.DTOs.Requests.Debt
{
    public class CreateDebtRequest
    {
        public string ItemName { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public PaymentPortions paymentPortions { get; set; }
        public string? Notes { get; set; }
    }
}