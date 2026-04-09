namespace FinFlow.Application.DTOs.Responses.FinancialAccounts
{
    public class FinancialAccountListResponse
    {
        public List<FinancialAccountResponse> FinancialAccountList { get; set; }
        public decimal TotalCurrentValue { get; set; }
    }
}
