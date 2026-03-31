using FinFlow.Application.DTOs.Requests;
using FinFlow.Application.DTOs.Responses;
using FinFlow.Application.Interfaces;
using FinFlow.Application.Mappers;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Services
{
    public class FinancialAccountService : IFinancialAccountService
    {

        private readonly IFinancialAccountRepository _repository;

        public FinancialAccountService(IFinancialAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<FinancialAccountListResponse> GetAllFinancialAccountAsync()
        {
            var accounts = await _repository.GetAllFinancialAccountAsync();

            var responseItems = accounts.Select(FinancialAccountMapper.ToResponse).ToList();

            var total = responseItems.Sum(a => a.CurrentValue);

            return new FinancialAccountListResponse
            {
                FinancialAccountList = responseItems,
                TotalCurrentValue = total
            };
        }

        public async Task<FinancialAccount?> GetFinancialAccountByIdAsync(Guid id)
        {
            return await _repository.GetFinancialAccountByIdAsync(id);  
        }

        public async Task<FinancialAccount> CreateFinancialAccountAsync(FinancialAccount account)
        {
            await _repository.AddFinancialAccountAsync(account);
            await _repository.SaveChangesAsync();
            return account;
        }

        public async Task<FinancialAccount?> UpdateAsync(Guid id, UpdateFinancialAccountRequest request)
        {
            var financialAccount = await _repository.GetFinancialAccountByIdAsync(id);
            if (financialAccount == null)
            {
                return null;
            }

            FinancialAccountMapper.ApplyUpdate(financialAccount, request);

            await _repository.UpdateAsync(financialAccount);
            await _repository.SaveChangesAsync();

            return financialAccount;
        }
                

        public async Task<bool> DeleteAsync(Guid id)
        {
            var financialAccount = await _repository.GetFinancialAccountByIdAsync(id);
            if (financialAccount == null)
            {
                return false;
            }

            await _repository.DeleteAsync(financialAccount);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
