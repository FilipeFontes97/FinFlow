using FinFlow.Application.Interfaces.Debts;
using FinFlow.Domain.Models;
using FinFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Infrastructure.Repositories.Debts
{
    public class DebtRepository : IDebtRepository
    {
        private readonly FinFlowDbContext _context;

        public DebtRepository(FinFlowDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Debt>> GetAllDebtsAsync()
        {
            return await _context.Debts.Include(d => d.Payments).ToListAsync();
        }

        public async Task<Debt?> GetDebtByIdAsync(Guid id)
        {
            return await _context.Debts.Include(d => d.Payments).FirstOrDefaultAsync(d => d.Id == id);
        }

        public Task UpdateAsync(Debt debt)
        {
            _context.Debts.Update(debt);
            return Task.CompletedTask;
        }

        public async Task AddDebtAsync(Debt debt)
        {
            await _context.Debts.AddAsync(debt);
        }

        public async Task AddPaymentAsync(DebtPayment debtPayment)
        {
            await _context.DebtPayments.AddAsync(debtPayment);
        }

        public Task DeleteAsync(Debt debt)
        {
            _context.Debts.Remove(debt);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}