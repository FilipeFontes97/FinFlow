using FinFlow.Domain.Models;

namespace FinFlow.Application.Interfaces.InvestmentRecords
{
    public interface IInvestmentTransactionRepository
    {
        Task AddAsync(InvestmentTransaction transaction);
        Task<IEnumerable<InvestmentTransaction>> GetAllAsync();
    }
}
