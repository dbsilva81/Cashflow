using Cashflow.Domain.Model.Enums;
using Cashflow.Domain.Model.Validations;
using System;

namespace Cashflow.Domain.Model.Entities
{
    public class FinancialTransaction : BaseEntity
    {
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public FinancialTransactionTypeEnum FinancialTransactionType { get; private set; }

        public FinancialTransaction(string description, decimal value, FinancialTransactionTypeEnum financialTransactionType)
        {
            Id = Guid.NewGuid();
            Description = description;
            Value = value;
            CreatedDate = DateTime.Now;
            UpdatFinancialTransactionType(financialTransactionType);
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateValue(decimal value)
        {
            Value = value;
        }

        public void UpdatFinancialTransactionType(FinancialTransactionTypeEnum financialTransactionType)
        {
            if (financialTransactionType == FinancialTransactionTypeEnum.Debit)
                Value *= -1;

            FinancialTransactionType = financialTransactionType;
        }

        public override bool IsValid()
        {
            ValidationResult = new FinancialTransactionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
