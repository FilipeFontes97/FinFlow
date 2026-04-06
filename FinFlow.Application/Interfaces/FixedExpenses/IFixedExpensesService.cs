
using FinFlow.Application.DTOs.Requests.FixedExpenses;
using FinFlow.Application.DTOs.Responses.FixedExpenses;

namespace FinFlow.Application.Interfaces.FixedExpenses
{
    public interface IFixedExpensesService
    {
        Task<IEnumerable<FixedExpensesResponse>> GetAllFixedExpensesAsync();
        Task<FixedExpensesResponse?> GetFixedExpenseByIdAsync(Guid id);
        Task<FixedExpensesResponse> CreateDebtAsync(CreateFixedExpenseRequest request);
        Task<FixedExpensesResponse?> UpdateAsync(Guid id, UpdateFixeExpenseRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
