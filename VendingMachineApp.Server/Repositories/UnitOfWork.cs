using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IIncludeableRepository<Order> Orders { get; private set; }
        public IRepository<Drink> Drinks { get; private set; }
        public IRepository<Brand> Brands { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        private readonly VendingMachineContext db;
        public UnitOfWork(
            VendingMachineContext _db,
            IIncludeableRepository<Order> _orderContext,
            IRepository<Drink> _drinkContext,
            IRepository<Brand> _brandContext,
            IRepository<OrderItem> _orderItems)
        {
            db = _db;
            Orders = _orderContext;
            Drinks = _drinkContext;
            Brands = _brandContext;
            OrderItems = _orderItems;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
