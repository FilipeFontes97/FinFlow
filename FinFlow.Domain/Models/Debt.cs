using FinFlow.Domain.Enums;

namespace FinFlow.Domain.Models
{
    public class Debt
    {
        public Guid Id { get; set; }
        public string? ItemName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount => TotalAmount - AmountPaid;
        public DateTime? LastPaymentDate { get; set; }
        public PaymentPortions PaymentPortions { get; set; }
        public string? Notes { get; set; }
        public DebtStatus DebtStatus { get; set; }
        public List<DebtPayment> Payments { get; set; } = new();
    }
}