namespace FinFlow.Domain.Models
{
    public class InvestmentTransaction
    {
        public Guid Id { get; set; }
        public Guid FinancialAccountId { get; set; }
        public FinancialAccount FinancialAccount { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime InvestmentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}