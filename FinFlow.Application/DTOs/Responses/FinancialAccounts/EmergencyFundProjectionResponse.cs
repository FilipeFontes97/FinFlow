namespace FinFlow.Application.DTOs.Responses.FinancialAccounts
{
    public class EmergencyFundPorjectionResponse
    {
        public decimal EmergencyFundAmount { get; set; }
        public decimal MonthlyExpenses { get; set; }
        public decimal MonthsCovered { get; set; }
    }
}