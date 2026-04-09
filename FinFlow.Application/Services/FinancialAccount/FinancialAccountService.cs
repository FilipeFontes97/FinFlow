using FinFlow.Application.DTOs.Requests.FinancialAccounts;
using FinFlow.Application.DTOs.Responses.FinancialAccounts;
using FinFlow.Application.Interfaces;
using FinFlow.Application.Mappers.FinancialAccounts;

namespace FinFlow.Application.Services.FinancialAccount
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

        public async Task<FinancialAccountResponse?> GetFinancialAccountByIdAsync(Guid id)
        {
            var entity = await _repository.GetFinancialAccountByIdAsync(id);
            if (entity == null) return null;
            return FinancialAccountMapper.ToResponse(entity);
        }

        public async Task<FinancialAccountResponse> CreateFinancialAccountAsync(CreateFinancialAccountRequest request)
        {
            var entity = FinancialAccountMapper.FromCreateRequest(request);
            await _repository.AddFinancialAccountAsync(entity);
            await _repository.SaveChangesAsync();
            return FinancialAccountMapper.ToResponse(entity);
        }

        public async Task<FinancialAccountResponse?> UpdateAsync(Guid id, UpdateFinancialAccountRequest request)
        {
            var financialAccount = await _repository.GetFinancialAccountByIdAsync(id);
            if (financialAccount == null)
            {
                return null;
            }

            FinancialAccountMapper.ApplyUpdate(financialAccount, request);

            await _repository.UpdateAsync(financialAccount);
            await _repository.SaveChangesAsync();

            return FinancialAccountMapper.ToResponse(financialAccount);
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
