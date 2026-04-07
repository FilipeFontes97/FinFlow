using FinFlow.Application.DTOs.Responses.InvestmentRecords;
using FinFlow.Application.Interfaces;
using FinFlow.Application.Interfaces.InvestmentRecords;
using FinFlow.Domain.Enums;

namespace FinFlow.Application.Services.InvestmentRecords
{
    public class InvestmentReportService : IInvestmentReportService
    {
        private readonly IFinancialAccountRepository _financialAccountRepository;

        public InvestmentReportService(IFinancialAccountRepository financialAccountRepository)
        {
            _financialAccountRepository = financialAccountRepository;
        }
        public async Task<InvestmentSummaryResponse> GetAllInvestmentsByYearAsync()
        {
           var accounts = await _financialAccountRepository.GetAllFinancialAccountAsync();

            var investmentsByYear = accounts
                .Where(i => i.Type == FinancialAccountType.ETF || i.Type == FinancialAccountType.Stocks || i.Type == FinancialAccountType.Crypto)
                .GroupBy(i => i.DateCreated.Year)
                .Select(g => new InvestmentByYearResponse
                {
                    Year = g.Key,
                    TotalInvested = g.Sum(i => i.ValueInvested)
                })
                .ToList();


            return new InvestmentSummaryResponse
            {
                InvestmentsByYear = investmentsByYear,
                TotalInvested = investmentsByYear.Sum(i => i.TotalInvested)
            };
        }
    }
}