using FinFlow.Application.DTOs.Requests.InvestmentRecords;

namespace FinFlow.Application.Interfaces.InvestmentRecords
{
    public interface IInvestmentService
    {
        Task AddInvestmentAsync(AddInvestmentRequest request);
    }
}
