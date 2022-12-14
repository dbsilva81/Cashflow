using Cashflow.Crosscutting.DataTransferObjects;
using Cashflow.Domain.Contracts.Repositories;
using Cashflow.Domain.Contracts.UnitOfWork;
using Cashflow.Services.Contracts;
using Cashflow.Services.Implementations.Extensions;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashflow.Services.Implementations
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IFinancialTransactionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FinancialTransactionService(IFinancialTransactionRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Add(FinancialTransactionDTO financialTransactionDTO)
        {
            var financialTransaction = financialTransactionDTO.ConvertToEntity();
            if (financialTransaction.IsValid())
            {
                _repository.Add(financialTransaction);
                await _unitOfWork.SaveChangesAsync();
            }

            return financialTransaction.ValidationResult;
        }

        public IEnumerable<FinancialTransactionDTO> GetAllByDate(DateTime date)
        {
            return _repository.GetAllByDate(date).Select(x => x.ConvertToDTO());
        }

        public CashflowDTO GetCashflow(DateTime date)
        {
            decimal debitFinancialTransactions = _repository.SumAllByDateAndType(date, Domain.Model.Enums.FinancialTransactionTypeEnum.Debit);
            decimal creditFinancialTransactions = _repository.SumAllByDateAndType(date, Domain.Model.Enums.FinancialTransactionTypeEnum.Credit);
            return new CashflowDTO
            {
                DebitFinancialTransactions = debitFinancialTransactions,
                CreditFinancialTransactions = creditFinancialTransactions,
                Balance = creditFinancialTransactions + debitFinancialTransactions
            };
        }
    }
}
