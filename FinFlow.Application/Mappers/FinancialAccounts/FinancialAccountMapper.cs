using FinFlow.Application.DTOs.Requests.FinancialAccounts;
using FinFlow.Application.DTOs.Responses.FinancialAccounts;
using FinFlow.Domain.Enums;
using FinFlow.Domain.Models;

namespace FinFlow.Application.Mappers.FinancialAccounts
{
    public static class FinancialAccountMapper
    {
        public static FinancialAccountResponse ToResponse(FinancialAccount entity)
        {
            return new FinancialAccountResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type.ToString(),
                ValueInvested = entity.ValueInvested,
                CurrentValue = entity.CurrentValue,
                Profit = entity.Profit,
                Notes = entity.Notes
            };
        }

        public static FinancialAccount FromCreateRequest(CreateFinancialAccountRequest dto)
        {
            return new FinancialAccount
            {
                Name = dto.Name,
                Type = Enum.Parse<FinancialAccountType>(dto.Type),
                ValueInvested = dto.ValueInvested,
                CurrentValue = dto.CurrentValue,
                Notes = dto.Notes
            };
        }

        public static void ApplyUpdate(FinancialAccount entity, UpdateFinancialAccountRequest request)
        {
            entity.Name = request.Name;
            entity.Type = Enum.Parse<FinancialAccountType>(request.Type);
            entity.ValueInvested = request.ValueInvested;
            entity.CurrentValue = request.CurrentValue;
            entity.Notes = request.Notes;
        }

    }
}
