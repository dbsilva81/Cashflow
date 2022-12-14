using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashflow.Crosscutting.DataTransferObjects
{
    public class CashflowDTO
    {
        public decimal DebitFinancialTransactions { get; set; }
        public decimal CreditFinancialTransactions { get; set; }
        public decimal Balance { get; set; }
    }
}
