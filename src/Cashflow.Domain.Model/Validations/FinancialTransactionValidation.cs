using Cashflow.Domain.Model.Entities;
using FluentValidation;
using System;

namespace Cashflow.Domain.Model.Validations
{
    public class FinancialTransactionValidation : AbstractValidator<FinancialTransaction>
    {
        public FinancialTransactionValidation()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .Length(0, 80)
                .WithMessage("Desctiption: maximum length must be 80 chars");

            RuleFor(c => c.Value)
                .NotEqual(decimal.Zero)
                .WithMessage("Value must be different than zero");

            RuleFor(c => c.FinancialTransactionType)
                .Must(x => x == Enums.FinancialTransactionTypeEnum.Debit || x == Enums.FinancialTransactionTypeEnum.Credit)
                .WithMessage("Financial transaction type invalid");
        }
    }
}
