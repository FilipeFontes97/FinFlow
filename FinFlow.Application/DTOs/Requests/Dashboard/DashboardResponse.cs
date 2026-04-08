using FinFlow.Application.DTOs.Responses.InvestmentRecords;

namespace FinFlow.Application.DTOs.Requests.Dashboard
{
    public class DashboardResponse
    {
        public decimal Assets { get; set; }
        public decimal Debts { get; set; }
        public decimal MonthlyFixedExpenses { get; set; }
        public decimal AllTimeInvested { get; set; }
        public decimal NetPosition { get; set; }

        public IEnumerable<AssetAllocationResponse> AssetAllocation { get; set; } = [];
        public IEnumerable<InvestmentByYearResponse> InvestmentsByYear { get; set; } = [];

    }
}
