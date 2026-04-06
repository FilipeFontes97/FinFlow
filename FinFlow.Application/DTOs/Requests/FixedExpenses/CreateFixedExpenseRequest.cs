using System.ComponentModel.DataAnnotations;
using FinFlow.Domain.Enums;

namespace FinFlow.Application.DTOs.Requests.FixedExpenses
{
    public class CreateFixedExpenseRequest
    {
        public FixedExpensesCategory Category { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }

        [Range(1, 31, ErrorMessage = "Payment day must be between 1 and 31.")]
        public int? PaymentDay { get; set; }
        public string? Notes { get; set; }
    }
}
