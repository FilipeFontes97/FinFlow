using FinFlow.Domain.Models;

namespace FinFlow.Application.Interfaces.Debts
{
    public interface IDebtRepository
    {
        Task<IEnumerable<Debt>> GetAllDebtsAsync();
        Task<Debt?> GetDebtByIdAsync(Guid id);
        Task AddDebtAsync(Debt debt);
        Task AddPaymentAsync(DebtPayment debtPayment);
        Task UpdateAsync(Debt debt);
        Task DeleteAsync(Debt debt);
        Task SaveChangesAsync();
    }
}