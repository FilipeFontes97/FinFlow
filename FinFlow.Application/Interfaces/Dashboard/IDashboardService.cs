using FinFlow.Application.DTOs.Requests.Dashboard;

namespace FinFlow.Application.Interfaces.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardResponse> GetOverviewAsync();
    }
}