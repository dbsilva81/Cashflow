using Cashflow.Domain.Model.Entities;
using Cashflow.Domain.Model.Enums;
using System;
using System.Collections.Generic;

namespace Cashflow.Domain.Contracts.Repositories
{
    public interface IFinancialTransactionRepository
    {
        IEnumerable<FinancialTransaction> GetAllByDate(DateTime date);
        decimal SumAllByDateAndType(DateTime date, FinancialTransactionTypeEnum financialTransactionType);
        void Add(FinancialTransaction financialTransaction);
    }
}
