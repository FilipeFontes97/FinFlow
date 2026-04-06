using FinFlow.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinFlow.Domain.Models
{
    public class FixedExpense
    {
        public Guid Id { get; set; }
        public FixedExpensesCategory Category { get; set; }
        public string? Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        [Range(1, 31, ErrorMessage = "Payment date must be between 1 and 31.")]
        public int? PaymentDay { get; set; }
        public string? Notes { get; set; }
    }
}