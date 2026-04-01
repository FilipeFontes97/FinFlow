using FinFlow.Application.DTOs.Requests.Debt;
using FinFlow.Application.DTOs.Responses.Debt;
using FinFlow.Application.Interfaces.Debts;
using FinFlow.Application.Mappers.Debts;
using FinFlow.Domain.Enums;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Services.Debts
{
    public class DebtService : IDebtService
    {
        private readonly IDebtRepository _debtRepository;

        public DebtService(IDebtRepository debtRepository)
        {
            _debtRepository = debtRepository;
        }

        public async Task<IEnumerable<DebtResponse>> GetAllDebtAsync()
        {
            var debts = await _debtRepository.GetAllDebtsAsync();
            return debts.Select(DebtMapper.ToResponse);
        }

        public async Task<DebtResponse?> GetDebtByIdAsync(Guid id)
        {
            var debt = await _debtRepository.GetDebtByIdAsync(id)
                                   ?? throw new KeyNotFoundException("Debt not found");

            return DebtMapper.ToResponse(debt);
        }

        public async Task<DebtResponse> AddPaymentAsync(Guid debtId, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Payment must be greater than zero");

            var debt = await _debtRepository.GetDebtByIdAsync(debtId)
                       ?? throw new KeyNotFoundException("Debt not found");

            // Register payment
            var payment = new DebtPayment
            {
                Id = Guid.NewGuid(),
                DebtId = debt.Id,
                Amount = amount,
                Date = DateTime.UtcNow
            };

            debt.Payments.Add(payment);

            // Recalculate amounts
            debt.AmountPaid = debt.Payments.Sum(p => p.Amount);
            debt.LastPaymentDate = payment.Date;

            // Update debt status
            debt.DebtStatus = debt.AmountPaid >= debt.TotalAmount
                ? DebtStatus.PaidOff
                : DebtStatus.InDebt;

            await _debtRepository.AddPaymentAsync(payment);
            await _debtRepository.UpdateAsync(debt);
            await _debtRepository.SaveChangesAsync();

            return DebtMapper.ToResponse(debt);
        }

        public async Task<DebtResponse?> UpdateAsync(Guid id, UpdateDebtRequest request)
        {

            var debt = await _debtRepository.GetDebtByIdAsync(id)
                                   ?? throw new KeyNotFoundException("Debt not found");

            debt.ItemName = request.ItemName;
            debt.PaymentPortions = request.paymentPortions;
            debt.Notes = request.Notes;
            debt.TotalAmount = request.TotalAmount;

            await _debtRepository.UpdateAsync(debt);
            await _debtRepository.SaveChangesAsync();

            return DebtMapper.ToResponse(debt);
        }
        
        public async Task<DebtResponse> CreateDebtAsync(CreateDebtRequest request)
        {
            var debt = new Debt
            {
                Id = Guid.NewGuid(),
                ItemName = request.ItemName,
                TotalAmount = request.TotalAmount,
                AmountPaid = 0,
                PaymentPortions = request.paymentPortions,
                Notes = request.Notes,
                DebtStatus = DebtStatus.InDebt
            };

            await _debtRepository.AddDebtAsync(debt);
            await _debtRepository.SaveChangesAsync();

            return DebtMapper.ToResponse(debt);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            var debt = await _debtRepository.GetDebtByIdAsync(id);

            if(debt == null)   
                return false; 

            await _debtRepository.DeleteAsync(debt);
            await _debtRepository.SaveChangesAsync();

            return true;
        }
    }
}