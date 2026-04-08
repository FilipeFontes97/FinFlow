using FinFlow.Application.DTOs.Requests.Dashboard;
using FinFlow.Application.DTOs.Responses.InvestmentRecords;
using FinFlow.Application.Interfaces;
using FinFlow.Application.Interfaces.Dashboard;
using FinFlow.Application.Interfaces.Debts;
using FinFlow.Application.Interfaces.FixedExpenses;
using FinFlow.Application.Interfaces.InvestmentRecords;

namespace FinFlow.Application.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IFinancialAccountRepository _financialAccountRepository;
        private readonly IDebtRepository _debtRepository;
        private readonly IFixedExpensesRepository _fixedExpensesRepository;
        private readonly IInvestmentTransactionRepository _investmentsTransactionRepository;

        public DashboardService(IFinancialAccountRepository financialAccountRepository, IDebtRepository debtRepository, IFixedExpensesRepository fixedExpensesRepository, IInvestmentTransactionRepository investmentsTransactionRepository)
        {
            _financialAccountRepository = financialAccountRepository;
            _debtRepository = debtRepository;
            _fixedExpensesRepository = fixedExpensesRepository;
            _investmentsTransactionRepository = investmentsTransactionRepository;
        }

        public async Task<DashboardResponse> GetOverviewAsync()
        {
            var accounts = await _financialAccountRepository.GetAllFinancialAccountAsync();
            var debts = await _debtRepository.GetAllDebtsAsync();
            var fixedExpenses = await _fixedExpensesRepository.GetAllFixedExpensesAsync();
            var investments = await _investmentsTransactionRepository.GetAllAsync();

            var assets = accounts.Sum(a => a.CurrentValue);
            var totalDebts = debts.Where(d => d.DebtStatus == Domain.Enums.DebtStatus.InDebt).Sum(d => d.RemainingAmount);
            var monthlyFixedExpenses = fixedExpenses.Sum(f => f.MonthlyAmount);
            var allTimeInvested = investments.Sum(i => i.Amount);
            var netPosition = assets - totalDebts;



            var allocation = accounts.GroupBy(a => a.Type)
                .Select(g => new AssetAllocationResponse
                {
                    AccountType = g.Key.ToString(),
                    Amount = g.Sum(a => a.CurrentValue),
                    Percentage = assets > 0 ? (g.Sum(a => a.CurrentValue) / assets * 100) : 0
                }).OrderByDescending(a => a.Amount)
                 .ToList();

            var investmentsByYear = investments.GroupBy(i => i.InvestmentDate.Year)
                .Select(g => new InvestmentByYearResponse
                {
                    Year = g.Key,
                    TotalInvested = g.Sum(i => i.Amount)
                }).OrderByDescending(i => i.Year)
                 .ToList();

            return new DashboardResponse
            {
                Assets = assets,
                Debts = totalDebts,
                MonthlyFixedExpenses= monthlyFixedExpenses,
                AllTimeInvested= allTimeInvested,
                NetPosition= netPosition,
                AssetAllocation = allocation,
                InvestmentsByYear = investmentsByYear
            };
        }
    }
}