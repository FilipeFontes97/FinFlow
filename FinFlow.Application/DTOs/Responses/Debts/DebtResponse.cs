using FinFlow.Domain.Enums;
using FinFlow.Domain.Models;

namespace FinFlow.Application.DTOs.Responses.Debt
{
    public class DebtResponse
    {
        public Guid Id { get; set; }
        public string? ItemName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public string PaymentPortions { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public DebtStatus DebtStatus { get; set; }
        public List<DebtPayment> Payments { get; set; } = new();
    }
}
