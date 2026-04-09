using FinFlow.Application.DTOs.Responses.InvestmentRecords;

namespace FinFlow.Application.DTOs.Responses.Dashboard
{
    public class DashboardResponse
    {
        public decimal Assets { get; set; }
        public decimal Debts { get; set; }
        public decimal MonthlyFixedExpenses { get; set; }
        public decimal AllTimeInvested { get; set; }
        public decimal NetPosition { get; set; }
        public decimal Income { get; set; }
        public decimal MonthlyFixedExpensesPercentage { get; set; }
        public List<AssetAllocationResponse> AssetAllocation { get; set; } = new();
        public List<InvestmentByYearResponse> InvestmentsByYear { get; set; } = new();
        public List<DashboardSignalResponse> Signals { get; set; } = new();
    }
}