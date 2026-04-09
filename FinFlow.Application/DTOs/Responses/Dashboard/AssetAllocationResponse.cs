namespace FinFlow.Application.DTOs.Responses.Dashboard
{
    public class AssetAllocationResponse
    {
        public string AccountType { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }
}