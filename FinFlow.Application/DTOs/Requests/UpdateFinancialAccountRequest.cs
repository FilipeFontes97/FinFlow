namespace FinFlow.Application.DTOs.Requests
{
    public class UpdateFinancialAccountRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal ValueInvested { get; set; }
        public decimal CurrentValue { get; set; }
        public string? Notes { get; set; }
    }

}
