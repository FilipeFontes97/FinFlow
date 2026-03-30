using FinFlow.Domain.Enums;

namespace FinFlow.Domain.Models
{
    public class Debt
    {
        public Guid Id { get; set; }
        public string? ItemName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPayed { get; set; }
        public decimal RemainingAmount => TotalAmount - AmountPayed;
        public DateTime? LastPaymentDate { get; set; }
        public string? Notes { get; set; }
        public DebtStatus DebtStatus { get; set; }
    }
}
