using System.Threading.Tasks;

namespace Cashflow.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
