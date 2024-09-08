using System.Linq.Expressions;

namespace VendingMachineApp.Server.Interfaces
{
    public interface IIncludeableRepository<T> : IRepository<T> where T : class
    {
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
    }
}