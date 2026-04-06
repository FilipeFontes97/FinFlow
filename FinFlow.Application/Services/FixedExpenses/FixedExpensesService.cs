using FinFlow.Application.DTOs.Requests.FixedExpenses;
using FinFlow.Application.DTOs.Responses.FixedExpenses;
using FinFlow.Application.Interfaces.FixedExpenses;
using FinFlow.Application.Mappers.FixedExpenses;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Services.FixedExpenses
{
    public class FixedExpensesService : IFixedExpensesService
    {
        private readonly IFixedExpensesRepository _fixedExpensesRepository;

        public FixedExpensesService(IFixedExpensesRepository fixedExpensesRepository)
        {
            _fixedExpensesRepository = fixedExpensesRepository;
        }


        public async Task<IEnumerable<FixedExpensesResponse>> GetAllFixedExpensesAsync()
        {
            var fixedExpenses = await _fixedExpensesRepository.GetAllFixedExpensesAsync();
            return fixedExpenses.Select(FixedExpensesMapper.ToResponse);
        }

        public async Task<FixedExpensesResponse?> GetFixedExpenseByIdAsync(Guid id)
        {
           var fixedExpense = await _fixedExpensesRepository.GetFixedExpenseByIdAsync(id) ?? throw new KeyNotFoundException("Fixed Expense not found");
            return FixedExpensesMapper.ToResponse(fixedExpense);
        }

        public async Task<FixedExpensesResponse> CreateDebtAsync(CreateFixedExpenseRequest request)
        {
            var fixedExpense = new FixedExpense
            {
                Id = Guid.NewGuid(),
                Category = request.Category,
                Description = request.Description,
                MonthlyAmount = request.MonthlyAmount,
                PaymentDate = request.PaymentDate,
                Notes = request.Notes
            };

            await _fixedExpensesRepository.AddFixedExpenseAsync(fixedExpense);
            await _fixedExpensesRepository.SaveChangesAsync();

            return FixedExpensesMapper.ToResponse(fixedExpense);
        }

        public async Task<FixedExpensesResponse?> UpdateAsync(Guid id, UpdateFixeExpenseRequest request)
        {
            var fixedExpense = await _fixedExpensesRepository.GetFixedExpenseByIdAsync(id) ?? throw new KeyNotFoundException("Fixed Expense not found");

            fixedExpense.Category = request.Category;
            fixedExpense.Description = request.Description;
            fixedExpense.MonthlyAmount = request.MonthlyAmount;
            fixedExpense.PaymentDate = request.PaymentDate;
            fixedExpense.Notes = request.Notes;

            await _fixedExpensesRepository.UpdateAsync(fixedExpense);
            await _fixedExpensesRepository.SaveChangesAsync();

            return FixedExpensesMapper.ToResponse(fixedExpense);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
           var fixedExpense = await _fixedExpensesRepository.GetFixedExpenseByIdAsync(id);

            if (fixedExpense == null)
                return false;

           await _fixedExpensesRepository.DeleteAsync(fixedExpense);
           await _fixedExpensesRepository.SaveChangesAsync();

           return true;
        }
    }
}