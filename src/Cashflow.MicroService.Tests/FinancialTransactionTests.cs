using Cashflow.Domain.Model.Entities;
using Cashflow.Domain.Model.Enums;
using Xunit;

namespace Cashflow.MicroService.Tests
{
    public class FinancialTransactionTests
    {

        [Fact]
        public void Is_Financial_Transaction_Valid()
        {
            FinancialTransaction financialTransaction = new("Transação de entrada 01", 100, FinancialTransactionTypeEnum.Credit);
            Assert.True(financialTransaction.IsValid());
        }

        [Fact]
        public void Is_Financial_Transaction_Invalid()
        {
            FinancialTransaction financialTransaction = new("Descrição grande demaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiiiiiiiiiiiiiiissssssssssssss", 0, (FinancialTransactionTypeEnum)2);
            financialTransaction.IsValid();
            Assert.True(financialTransaction.ValidationResult.Errors.Count == 3);
        }

        [Fact]
        public void Is_Debit_Transaction_Valid()
        {
            FinancialTransaction financialTransaction = new("Transação de débito", 100, FinancialTransactionTypeEnum.Debit);
            Assert.True(financialTransaction.IsValid() 
                && financialTransaction.FinancialTransactionType == FinancialTransactionTypeEnum.Debit 
                && financialTransaction.Value < 0);
        }

        [Fact]
        public void Is_Credit_Transaction_Valid()
        {
            FinancialTransaction financialTransaction = new("Transação de crédito", 100, FinancialTransactionTypeEnum.Credit);
            Assert.True(financialTransaction.IsValid() && financialTransaction.FinancialTransactionType == FinancialTransactionTypeEnum.Credit);
        }

        [Fact]
        public void Validate_Financial_Transaction_Description_Empty()
        {
            FinancialTransaction financialTransaction = new("", 100, FinancialTransactionTypeEnum.Credit);
            Assert.False(financialTransaction.IsValid());
        }

        [Fact]
        public void Validate_Financial_Transaction_Description_Maxlenth()
        {
            FinancialTransaction financialTransaction = new("Descrição grande demaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiiiiiiiiiiiiiiissssssssssssss", 100, FinancialTransactionTypeEnum.Credit);
            Assert.False(financialTransaction.IsValid());
        }

        [Fact]
        public void Validate_Financial_transaction_Zero_Value()
        {
            FinancialTransaction financialTransaction = new("Transação de crédito", 0, FinancialTransactionTypeEnum.Credit);
            Assert.False(financialTransaction.IsValid());
        }

        [Fact]
        public void Validate_Financial_Transaction_Type_Invalid()
        {
            FinancialTransaction financialTransaction = new("Transação de crédito", 100, (FinancialTransactionTypeEnum)2);
            Assert.False(financialTransaction.IsValid());
        }
    }
}
