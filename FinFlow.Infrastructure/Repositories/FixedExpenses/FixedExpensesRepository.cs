using FinFlow.Application.Interfaces.FixedExpenses;
using FinFlow.Domain.Models;
using FinFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Infrastructure.Repositories.FixedExpenses
{
    public class FixedExpensesRepository : IFixedExpensesRepository
    {

        private readonly FinFlowDbContext _context;

        public FixedExpensesRepository(FinFlowDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FixedExpense>> GetAllFixedExpensesAsync()
        {
           return await _context.FixedExpenses.ToListAsync();
        }

        public Task<FixedExpense?> GetFixedExpenseByIdAsync(Guid id)
        {
            return _context.FixedExpenses.FirstOrDefaultAsync(fe => fe.Id == id);
        }

        public async Task AddFixedExpenseAsync(FixedExpense fixedExpense)
        {
            await _context.FixedExpenses.AddAsync(fixedExpense);
        }

        public Task UpdateAsync(FixedExpense fixedExpense)
        {
            _context.FixedExpenses.Update(fixedExpense);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(FixedExpense fixedExpense)
        {
            _context.FixedExpenses.Remove(fixedExpense);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
