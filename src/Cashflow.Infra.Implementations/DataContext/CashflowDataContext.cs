using Cashflow.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashflow.Infra.Implementations.DataContext
{
    public class CashflowDataContext : DbContext
    {

        public CashflowDataContext(DbContextOptions<CashflowDataContext> options) : base(options)
        {
        }


        public DbSet<FinancialTransaction> FinancialTransaction { get; set; }
    }
}
