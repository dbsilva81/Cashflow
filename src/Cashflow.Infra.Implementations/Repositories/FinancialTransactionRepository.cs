using Cashflow.Domain.Contracts.Repositories;
using Cashflow.Domain.Model.Entities;
using Cashflow.Domain.Model.Enums;
using Cashflow.Infra.Implementations.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cashflow.Infra.Implementations.Repositories
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly CashflowDataContext _context;

        public FinancialTransactionRepository(CashflowDataContext context)
        {
            _context = context;
        }

        public void Add(FinancialTransaction financialTransaction)
        {
            _context.FinancialTransaction.Add(financialTransaction);
        }

        public IEnumerable<FinancialTransaction> GetAllByDate(DateTime date)
        {
            var startDate = date.Date;
            var endDate = date.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            return _context.FinancialTransaction.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate);
        }

        public decimal SumAllByDateAndType(DateTime date, FinancialTransactionTypeEnum financialTransactionType)
        {
            var startDate = date.Date;
            var endDate = date.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            return _context.FinancialTransaction.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate && x.FinancialTransactionType == financialTransactionType)
                .Sum(x => x.Value);
        }
    }
}
