using FinFlow.Application.DTOs.Requests.FinancialAccounts;
using FinFlow.Application.DTOs.Responses.FinancialAccounts;

namespace FinFlow.Application.Interfaces
{
    public interface IFinancialAccountService
    {
        Task<FinancialAccountListResponse> GetAllFinancialAccountAsync();
        Task<FinancialAccountResponse?> GetFinancialAccountByIdAsync(Guid id);
        Task<FinancialAccountResponse> CreateFinancialAccountAsync(CreateFinancialAccountRequest request);
        Task<FinancialAccountResponse?> UpdateAsync(Guid id, UpdateFinancialAccountRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
