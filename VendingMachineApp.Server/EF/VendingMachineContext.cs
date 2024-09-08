using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VendingMachineApp.Server.Data;

namespace VendingMachineApp.Server.EF
{
    public class VendingMachineContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public VendingMachineContext(DbContextOptions<VendingMachineContext> contextOptions) : base(contextOptions)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
