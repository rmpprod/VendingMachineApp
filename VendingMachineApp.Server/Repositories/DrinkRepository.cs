using Microsoft.EntityFrameworkCore;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Repositories
{
    public class DrinkRepository : IRepository<Drink>
    {
        private readonly VendingMachineContext db;
        public DrinkRepository(VendingMachineContext _db)
        {
            db = _db;
        }

        public void Create(Drink item)
        {
            db.Drinks.Add(item);
        }

        public void Delete(int id)
        {
            Drink drink = db.Drinks.Find(id);
            if (drink != null)
                db.Drinks.Remove(drink);
        }

        public IEnumerable<Drink> Find(Func<Drink, bool> predicate)
        {
            return db.Drinks.Where(predicate).ToList();
        }

        public Drink Get(int id)
        {
            return db.Drinks.Find(id);
        }

        public IEnumerable<Drink> GetAll()
        {
            return db.Drinks;
        }

        public void Update(Drink item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void CreateRange(IEnumerable<Drink> items)
        {
            db.Drinks.AddRange(items);
        }
    }
}
