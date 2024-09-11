using Microsoft.EntityFrameworkCore;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Repositories
{
    public class OrderItemsRepository : IRepository<OrderItem>
    {
        private readonly VendingMachineContext db;
        public OrderItemsRepository(VendingMachineContext _db)
        {
            db = _db;
        }

        public void Create(OrderItem item)
        {
            db.OrderItems.Add(item);
        }

        public void Delete(int id)
        {
            OrderItem item = db.OrderItems.Find(id);
            if (item != null)
                db.OrderItems.Remove(item);
        }

        public IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate)
        {
            return db.OrderItems.Where(predicate).ToList();
        }

        public OrderItem Get(int id)
        {
            return db.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return db.OrderItems;
        }

        public void Update(OrderItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void CreateRange(IEnumerable<OrderItem> items)
        {
            db.OrderItems.AddRange(items);
        }
    }
}
