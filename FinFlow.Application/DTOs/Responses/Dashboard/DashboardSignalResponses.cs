using FinFlow.Domain.Enums;

namespace FinFlow.Application.DTOs.Responses.Dashboard
{  public class DashboardSignalResponse
    {
        public string Code { get; set; } = null!; // ex: "ETF_CONCENTRATION"
        public string Message { get; set; } = null!;
        public SignalLevel Level { get; set; }
    }
}