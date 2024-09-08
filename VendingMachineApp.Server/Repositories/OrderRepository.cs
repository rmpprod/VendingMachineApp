using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Repositories
{
    public class OrderRepository : IIncludeableRepository<Order>
    {
        private readonly VendingMachineContext db;
        public OrderRepository(VendingMachineContext _db)
        {
            db = _db;
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = db.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
                db.Orders.Remove(order);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(o => predicate(o)).ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void CreateRange(IEnumerable<Order> items)
        {
            db.Orders.AddRange(items);
        }

        public IEnumerable<Order> GetWithInclude(params Expression<Func<Order, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Order> GetWithInclude(Func<Order, bool> predicate,
            params Expression<Func<Order, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<Order> Include(params Expression<Func<Order, object>>[] includeProperties)
        {
            IQueryable<Order> query = db.Orders.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
