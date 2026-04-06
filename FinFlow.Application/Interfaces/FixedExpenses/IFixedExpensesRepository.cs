using FinFlow.Domain.Models;

namespace FinFlow.Application.Interfaces.FixedExpenses
{
    public interface IFixedExpensesRepository
    {
        Task<IEnumerable<FixedExpense>> GetAllFixedExpensesAsync();
        Task<FixedExpense?> GetFixedExpenseByIdAsync(Guid id);
        Task AddFixedExpenseAsync(FixedExpense fixedExpense);
        Task UpdateAsync(FixedExpense fixedExpense);
        Task DeleteAsync(FixedExpense fixedExpense);
        Task SaveChangesAsync();
    }
}
