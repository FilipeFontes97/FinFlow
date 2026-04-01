using FinFlow.Application.DTOs.Requests.Debt;
using FinFlow.Application.DTOs.Responses.Debt;

namespace FinFlow.Application.Interfaces.Debts
{
    public interface IDebtService
    {
        Task<IEnumerable<DebtResponse>> GetAllDebtAsync();
        Task<DebtResponse?> GetDebtByIdAsync(Guid id);
        Task<DebtResponse> AddPaymentAsync(Guid debtId, decimal amount);
        Task<DebtResponse?> UpdateAsync(Guid id, UpdateDebtRequest request);
        Task<DebtResponse> CreateDebtAsync(CreateDebtRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}