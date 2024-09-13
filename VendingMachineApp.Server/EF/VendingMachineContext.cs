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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Coin coinWithNominal_1 = new Coin { Id = 1, Nominal = 1, Quantity = 0};
            Coin coinWithNominal_2 = new Coin { Id = 2, Nominal = 2, Quantity = 0 };
            Coin coinWithNominal_5 = new Coin { Id = 3, Nominal = 5, Quantity = 0};
            Coin coinWithNominal_10 = new Coin { Id = 4, Nominal = 10, Quantity = 0};

            modelBuilder.Entity<Coin>().HasData(coinWithNominal_1, coinWithNominal_2, coinWithNominal_5, coinWithNominal_10);
        }
    }
}
