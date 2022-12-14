using Cashflow.Crosscutting.DataTransferObjects;
using Cashflow.Domain.Model.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cashflow.Services.Contracts
{
    public interface IFinancialTransactionService
    {
        Task<ValidationResult> Add(FinancialTransactionDTO financialTransaction);
        IEnumerable<FinancialTransactionDTO> GetAllByDate(DateTime date);
        CashflowDTO GetCashflow(DateTime date);

    }
}
