using FinFlow.Application.DTOs.Responses.FinancialAccounts;
using FinFlow.Application.Interfaces.FinancialAccounts;
using FinFlow.Application.Interfaces.FixedExpenses;
using FinFlow.Application.Interfaces.Settings;
using FinFlow.Domain.Enums;

namespace FinFlow.Application.Services.FinancialAccount
{
    public class FinancialProjectionService : IFinancialProjectionService
    {
        private readonly IFinancialAccountRepository _financialAccountRepository;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IFixedExpensesRepository _fixedExpensesRepository;

        public FinancialProjectionService(IFinancialAccountRepository financialAccountRepository, IUserSettingsService userSettingsService, IFixedExpensesRepository fixedExpensesRepository)
        {
            _financialAccountRepository = financialAccountRepository;
            _userSettingsService = userSettingsService;
            _fixedExpensesRepository = fixedExpensesRepository;
        }

        public async Task<EmergencyFundPorjectionResponse> GetEmergencyFundPorjectionAsync()
        {
            var accounts = await _financialAccountRepository.GetAllFinancialAccountAsync();
            var settings = await _userSettingsService.GetUserSettingsAsync();

            var emergencyFundAmount = accounts
                .Where(a => a.Type == FinancialAccountType.EmergencyFund)
                .Sum(a => a.CurrentValue);

            var monthlyEssentials = _fixedExpensesRepository.GetAllFixedExpensesAsync().Result
                .Sum(f => f.MonthlyAmount);

            var monthsCovered = monthlyEssentials > 0
                ? emergencyFundAmount / monthlyEssentials
                : 0;

            return new EmergencyFundPorjectionResponse
            {
                EmergencyFundAmount = emergencyFundAmount,
                MonthlyExpenses = monthlyEssentials,
                MonthsCovered = Math.Round(monthsCovered, 1)
            };
        }
    }
}