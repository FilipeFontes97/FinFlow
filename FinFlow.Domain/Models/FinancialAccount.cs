using FinFlow.Domain.Enums;

namespace FinFlow.Domain.Models
{
    public class FinancialAccount
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public FinancialAccountType Type { get; set; }
        public decimal ValueInvested { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal Profit => CurrentValue - ValueInvested;
        public string? Notes { get; set; }
        public ICollection<InvestmentTransaction> InvestmentTransactions { get; set; } = new List<InvestmentTransaction>();
    }
}