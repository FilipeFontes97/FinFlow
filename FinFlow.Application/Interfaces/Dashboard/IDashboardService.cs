using FinFlow.Application.DTOs.Responses.Dashboard;

namespace FinFlow.Application.Interfaces.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardResponse> GetOverviewAsync();
    }
}