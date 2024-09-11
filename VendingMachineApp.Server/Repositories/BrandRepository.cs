using Microsoft.EntityFrameworkCore;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.EF;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly VendingMachineContext db;
        public BrandRepository(VendingMachineContext _db)
        {
            db = _db;
        }

        public void Create(Brand item)
        {
            db.Brands.Add(item);
        }

        public void Delete(int id)
        {
            Brand brand = db.Brands.Find(id);
            if (brand != null)
                db.Brands.Remove(brand);
        }

        public IEnumerable<Brand> Find(Func<Brand, bool> predicate)
        {
            return db.Brands.Where(predicate).ToList();
        }

        public Brand Get(int id)
        {
            return db.Brands.Find(id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return db.Brands;
        }

        public void Update(Brand item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void CreateRange(IEnumerable<Brand> items)
        {
            db.Brands.AddRange(items);
        }
    }
}
