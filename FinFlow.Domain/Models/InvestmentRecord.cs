namespace FinFlow.Domain.Models
{
    public class InvestmentRecord
    {
        public Guid Id { get; set; }
        public int FinancialAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
