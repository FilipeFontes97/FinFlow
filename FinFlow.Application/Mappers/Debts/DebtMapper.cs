using FinFlow.Application.DTOs.Responses.Debt;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Mappers.Debts
{
    public static class DebtMapper
    {
        public static DebtResponse ToResponse(Debt entity)
        {
            return new DebtResponse
            {
                Id = entity.Id,
                ItemName = entity.ItemName,
                TotalAmount = entity.TotalAmount,
                AmountPaid = entity.AmountPaid,
                RemainingAmount = entity.TotalAmount - entity.AmountPaid,
                LastPaymentDate = entity.LastPaymentDate,
                PaymentPortions = entity.PaymentPortions.ToString(),
                Notes = entity.Notes,
                DebtStatus = entity.DebtStatus,
                Payments = entity.Payments.Select(p => new DebtPayment
                {
                    Id = p.Id,
                    Amount = p.Amount,
                    Date = p.Date
                }).ToList()
            };
        }
    }
}