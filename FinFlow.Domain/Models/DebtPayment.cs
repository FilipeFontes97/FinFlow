namespace FinFlow.Domain.Models
{
    public class DebtPayment
    {
        public Guid Id { get; set; }
        public int DebtId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
