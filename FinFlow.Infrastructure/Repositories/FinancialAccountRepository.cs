using FinFlow.Application.Interfaces.FinancialAccounts;
using FinFlow.Domain.Models;
using FinFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Infrastructure.Repositories
{
    public class FinancialAccountRepository : IFinancialAccountRepository
    {
        private readonly FinFlowDbContext _context;

        public FinancialAccountRepository(FinFlowDbContext context)
        { 
            _context = context;
        }

        public async Task<IEnumerable<FinancialAccount>> GetAllFinancialAccountAsync()
        {
            return await _context.FinancialAccounts.AsNoTracking().ToListAsync();
        }

        public async Task<FinancialAccount?> GetFinancialAccountByIdAsync(Guid id)
        {
            return await _context.FinancialAccounts.FindAsync(id);
        }

        public async Task AddFinancialAccountAsync(FinancialAccount account)
        {
            await _context.FinancialAccounts.AddAsync(account);
        }

        public Task UpdateAsync(FinancialAccount account)
        {
            _context.FinancialAccounts.Update(account);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(FinancialAccount account)
        {
           _context.FinancialAccounts.Remove(account);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
