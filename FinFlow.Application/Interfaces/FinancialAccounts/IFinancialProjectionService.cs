
using FinFlow.Application.DTOs.Responses.FinancialAccounts;

namespace FinFlow.Application.Interfaces.FinancialAccounts
{
    public interface IFinancialProjectionService
    {
            Task<EmergencyFundPorjectionResponse> GetEmergencyFundPorjectionAsync();
    }
}
