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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public OrderItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem item)
        {
            throw new NotImplementedException();
        }

        public void CreateRange(IEnumerable<OrderItem> items)
        {
            db.OrderItems.AddRange(items);
        }
    }
}
