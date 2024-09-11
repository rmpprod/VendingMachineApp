using Microsoft.EntityFrameworkCore;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Repositories
{
    public class CoinRepository : IRepository<Coin>
    {
        private readonly VendingMachineContext db;
        public CoinRepository(VendingMachineContext _db)
        {
            db = _db;
        }

        public void Create(Coin item)
        {
            db.Coins.Add(item);
        }

        public void Delete(int id)
        {
            Coin coin = db.Coins.Find(id);
            if (coin != null)
                db.Coins.Remove(coin);
        }

        public IEnumerable<Coin> Find(Func<Coin, bool> predicate)
        {
            return db.Coins.Where(predicate).ToList();
        }

        public Coin Get(int id)
        {
            return db.Coins.Find(id);
        }

        public IEnumerable<Coin> GetAll()
        {
            return db.Coins;
        }

        public void Update(Coin item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void CreateRange(IEnumerable<Coin> items)
        {
            db.Coins.AddRange(items);
        }
    }
}
