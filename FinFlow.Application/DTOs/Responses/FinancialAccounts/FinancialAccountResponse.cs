namespace FinFlow.Application.DTOs.Responses.FinancialAccounts
{
    public class FinancialAccountResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal ValueInvested { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal Profit { get; set; }
        public string? Notes { get; set; }
    }
}