using FinFlow.Application.DTOs.Requests.InvestmentRecords;
using FinFlow.Application.DTOs.Responses.InvestmentRecords;
using FinFlow.Application.Interfaces;
using FinFlow.Application.Interfaces.InvestmentRecords;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Services.InvestmentRecords
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IFinancialAccountRepository _accountRepository;
        private readonly IInvestmentTransactionRepository _investmentTransactionRepository;

        public InvestmentService(
            IFinancialAccountRepository accountRepository,
            IInvestmentTransactionRepository investmentTransactionRepository)
        {
            _accountRepository = accountRepository;
            _investmentTransactionRepository = investmentTransactionRepository;
        }

        public async Task AddInvestmentAsync(AddInvestmentRequest request)
        {
            var account = await _accountRepository.GetFinancialAccountByIdAsync(request.FinancialAccountId)
                           ?? throw new KeyNotFoundException("Account not found");

            var transaction = new InvestmentTransaction
            {
                Id = Guid.NewGuid(),
                FinancialAccountId = account.Id,
                Amount = request.Amount,
                InvestmentDate = request.InvestmentDate
            };

            account.ValueInvested += request.Amount;

            await _investmentTransactionRepository.AddAsync(transaction);
            await _accountRepository.SaveChangesAsync();
        }
    }
}