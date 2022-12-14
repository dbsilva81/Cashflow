using Cashflow.Domain.Contracts.UnitOfWork;
using Cashflow.Infra.Implementations.DataContext;
using System.Threading.Tasks;

namespace Cashflow.Infra.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private CashflowDataContext _context;

        public UnitOfWork(CashflowDataContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
