using FinFlow.Application.DTOs.Responses.InvestmentRecords;

namespace FinFlow.Application.Interfaces.InvestmentRecords
{
    public interface IInvestmentReportService
    {
        Task<InvestmentSummaryResponse> GetAllInvestmentsByYearAsync();
    }
}