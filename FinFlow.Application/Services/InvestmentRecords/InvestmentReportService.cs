using FinFlow.Application.DTOs.Responses.InvestmentRecords;
using FinFlow.Application.Interfaces.InvestmentRecords;

namespace FinFlow.Application.Services.InvestmentRecords
{
    public class InvestmentReportService : IInvestmentReportService
    {
        private readonly IInvestmentTransactionRepository _investmentTransactionRepository;

        public InvestmentReportService(
            IInvestmentTransactionRepository investmentTransactionRepository)
        {
            _investmentTransactionRepository = investmentTransactionRepository;
        }

        public async Task<InvestmentSummaryResponse> GetAllInvestmentsByYearAsync()
        {
            var transactions = await _investmentTransactionRepository.GetAllAsync();

            var investmentsByYear = transactions
                .GroupBy(t => t.InvestmentDate.Year)
                .Select(g => new InvestmentByYearResponse
                {
                    Year = g.Key,
                    TotalInvested = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Year)
                .ToList();

            return new InvestmentSummaryResponse
            {
                InvestmentsByYear = investmentsByYear,
                TotalInvested = investmentsByYear.Sum(x => x.TotalInvested)
            };
        }
    }
}
