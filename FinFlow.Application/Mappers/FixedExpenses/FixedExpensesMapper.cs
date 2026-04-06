using FinFlow.Application.DTOs.Responses.FixedExpenses;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Mappers.FixedExpenses
{
    public static class FixedExpensesMapper
    {
        public static FixedExpensesResponse ToResponse(FixedExpense entity)
        {
            return new FixedExpensesResponse
            {
               Id = entity.Id,
               Category = entity.Category,
               Description = entity.Description,
               MonthlyAmount = entity.MonthlyAmount,
               PaymentDay = entity.PaymentDay,
               Notes = entity.Notes,
            };
        }
    }
}
