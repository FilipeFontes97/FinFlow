using FinFlow.Application.Interfaces.InvestmentRecords;
using FinFlow.Domain.Models;
using FinFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.Infrastructure.Repositories.InvestmentRecords
{

    public class InvestmentTransactionRepository : IInvestmentTransactionRepository
    {
        private readonly FinFlowDbContext _context;

        public InvestmentTransactionRepository(FinFlowDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InvestmentTransaction transaction)
        {
            await _context.InvestmentTransactions.AddAsync(transaction);
        }

        public async Task<IEnumerable<InvestmentTransaction>> GetAllAsync()
        {
            return await _context.InvestmentTransactions.ToListAsync();
        }
    }
}