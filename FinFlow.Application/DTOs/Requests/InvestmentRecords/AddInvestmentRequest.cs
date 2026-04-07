namespace FinFlow.Application.DTOs.Requests.InvestmentRecords
{
    public class AddInvestmentRequest
    {
        public Guid FinancialAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvestmentDate { get; set; }
    }
}
