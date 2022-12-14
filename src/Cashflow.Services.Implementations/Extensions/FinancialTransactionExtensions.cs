using Cashflow.Crosscutting.DataTransferObjects;
using Cashflow.Domain.Model.Entities;

namespace Cashflow.Services.Implementations.Extensions
{
    public static class FinancialTransactionExtensions
    {
        public static FinancialTransactionDTO ConvertToDTO(this FinancialTransaction entity)
        {
            return new FinancialTransactionDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                Value = entity.Value,
                CreatedDate = entity.CreatedDate,
                FinancialTransactionType = (int)entity.FinancialTransactionType
            };
        }

        public static FinancialTransaction ConvertToEntity(this FinancialTransactionDTO dto)
        {
            return new FinancialTransaction(dto.Description, dto.Value, (Domain.Model.Enums.FinancialTransactionTypeEnum)dto.FinancialTransactionType);
        }
    }
}
