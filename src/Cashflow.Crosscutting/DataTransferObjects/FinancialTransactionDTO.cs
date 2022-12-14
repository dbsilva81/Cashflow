using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashflow.Crosscutting.DataTransferObjects
{
    public class FinancialTransactionDTO
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public int FinancialTransactionType { get; set; }
    }
}
