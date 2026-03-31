using FinFlow.Domain.Models;

namespace FinFlow.Application.Interfaces
{
    public interface IFinancialAccountRepository
    {
        Task<IEnumerable<FinancialAccount>> GetAllFinancialAccountAsync();
        Task<FinancialAccount?> GetFinancialAccountByIdAsync(Guid id);
        Task AddFinancialAccountAsync(FinancialAccount account);
        Task UpdateAsync(FinancialAccount account);
        Task DeleteAsync(FinancialAccount account);
        Task SaveChangesAsync();
    }
}
