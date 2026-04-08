namespace FinFlow.Application.DTOs.Requests.Dashboard
{
    public class AssetAllocationResponse
    {
        public string AccountType { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }
}