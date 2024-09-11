using VendingMachineApp.Server.Data;

namespace VendingMachineApp.Server.Interfaces
{
    public interface IUnitOfWork
    {
        IIncludeableRepository<Order> Orders { get; }
        IRepository<Drink> Drinks { get; }
        IRepository<Brand> Brands { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Coin> Coins { get; }
        void Save();
    }
}
