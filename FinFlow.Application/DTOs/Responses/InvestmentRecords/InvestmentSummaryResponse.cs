namespace FinFlow.Application.DTOs.Responses.InvestmentRecords
{
    public class InvestmentSummaryResponse
    {
        public IEnumerable<InvestmentByYearResponse> InvestmentsByYear { get; set; } = [];
        public decimal TotalInvested { get; set; }
    }
}