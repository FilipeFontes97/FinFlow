using FinFlow.Application.DTOs.Responses.Dashboard;
using FinFlow.Application.DTOs.Responses.InvestmentRecords;
using FinFlow.Application.Interfaces.Dashboard;
using FinFlow.Application.Interfaces.Debts;
using FinFlow.Application.Interfaces.FinancialAccounts;
using FinFlow.Application.Interfaces.FixedExpenses;
using FinFlow.Application.Interfaces.InvestmentRecords;
using FinFlow.Application.Interfaces.Settings;
using FinFlow.Domain.Enums;

namespace FinFlow.Application.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IFinancialAccountRepository _financialAccountRepository;
        private readonly IDebtRepository _debtRepository;
        private readonly IFixedExpensesRepository _fixedExpensesRepository;
        private readonly IInvestmentTransactionRepository _investmentsTransactionRepository;
        private readonly IUserSettingsService _userSettingsService;

        public DashboardService(IFinancialAccountRepository financialAccountRepository, IDebtRepository debtRepository, IFixedExpensesRepository fixedExpensesRepository, IInvestmentTransactionRepository investmentsTransactionRepository, IUserSettingsService userSettingsService)
        {
            _financialAccountRepository = financialAccountRepository;
            _debtRepository = debtRepository;
            _fixedExpensesRepository = fixedExpensesRepository;
            _investmentsTransactionRepository = investmentsTransactionRepository;
            _userSettingsService = userSettingsService;
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

            var settings = await _userSettingsService.GetUserSettingsAsync();
            var income = settings.Income;
            var threshold = settings.FixedExpensesThresholdPercent;

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
                }).OrderBy(i => i.Year)
                 .ToList();

            var signals = new List<DashboardSignalResponse>();


            var investmentTypes = new[]
            {
                FinancialAccountType.ETF.ToString(),
                FinancialAccountType.Stocks.ToString(),
                FinancialAccountType.Crypto.ToString()
            };

            var investmentPercentage = allocation
                .Where(a => investmentTypes.Contains(a.AccountType))
                .Sum(a => a.Percentage);

            string message;
            SignalLevel level;

            if (investmentPercentage < 10)
            {
                level = SignalLevel.Danger;
                message =
                    $"Only {investmentPercentage:F2}% of your assets are invested. " +
                    $"This is very low and may limit long-term growth.";
            }
            else if (investmentPercentage < 25)
            {
                level = SignalLevel.Warning;
                message =
                    $"Your investment allocation is {investmentPercentage:F2}%. " +
                    $"Consider increasing it if your goal is long-term growth.";
            }
            else
            {
                level = SignalLevel.Info;
                message =
                    $"Your investment allocation is {investmentPercentage:F2}%, " +
                    $"which is within a healthy range. 📈";
            }

            signals.Add(new DashboardSignalResponse
            {
                Code = "INVESTMENT_ALLOCATION",
                Message = message,
                Level = level
            });


            if (totalDebts == 0)
            {
                signals.Add(new DashboardSignalResponse
                {
                    Code = "NO_ACTIVE_DEBTS",
                    Message = "You currently have no active debts. 🎉",
                    Level = SignalLevel.Info
                });
            }
            else
            {
                var annualIncome = income * 12;

                if (annualIncome > 0)
                {
                    var debtRatio = totalDebts / annualIncome * 100;

                    if (debtRatio > 50)
                    {
                        signals.Add(new DashboardSignalResponse
                        {
                            Code = "DEBT_TO_INCOME",
                            Message = $"Your active debts equal {debtRatio:F1}% of your annual income. Consider prioritizing debt repayment.",
                            Level = SignalLevel.Warning
                        });
                    }
                    else if (totalDebts > 0 || debtRatio < 50)
                    {
                        signals.Add(new DashboardSignalResponse
                        {
                            Code = "DEBT_TO_INCOME",
                            Message = $"\"Great job! You have no outstanding debts. Your active debts represent {debtRatio:F1}% of your annual income.",
                            Level = debtRatio > 50 ? SignalLevel.Warning : SignalLevel.Info
                        });
                    }
                }
            }

            if (monthlyFixedExpenses > 0)
            {
                var percent = income > 0 ? Math.Round(monthlyFixedExpenses / income * 100m, 2) : 0m;
                if (percent > threshold)
                {
                    signals.Add(new DashboardSignalResponse
                    {
                        Code = "FIXED_EXPENSES_RATIO",
                        Message = $"Your monthly fixed expenses are {percent:F2}% of income ({income:C}), which exceeds your threshold of {threshold}%. Consider reducing fixed expenses.",
                        Level = SignalLevel.Warning
                    });
                }
                else
                {
                    signals.Add(new DashboardSignalResponse
                    {
                        Code = "FIXED_EXPENSES_RATIO",
                        Message = $"Monthly fixed expenses total {monthlyFixedExpenses:C} ({percent:F2}% of income).",
                        Level = SignalLevel.Info
                    });
                }
            }

            return new DashboardResponse
            {
                Assets = assets,
                Debts = totalDebts,
                MonthlyFixedExpenses= monthlyFixedExpenses,
                AllTimeInvested= allTimeInvested,
                NetPosition= netPosition,
                Income = income,
                MonthlyFixedExpensesPercentage = income > 0 ? (monthlyFixedExpenses / income * 100m) : 0m,
                AssetAllocation = allocation,
                InvestmentsByYear = investmentsByYear,
                Signals = signals
            };
        }
    }
}