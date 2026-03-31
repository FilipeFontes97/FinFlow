using FinFlow.Application.DTOs.Requests;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Interfaces
{
    public interface IFinancialAccountService
    {
        Task<IEnumerable<FinancialAccount>> GetAllFinancialAccountAsync();
        Task<FinancialAccount?> GetFinancialAccountByIdAsync(Guid id);
        Task<FinancialAccount> CreateFinancialAccountAsync(FinancialAccount account);
        Task<FinancialAccount?> UpdateAsync(Guid id, UpdateFinancialAccountRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
