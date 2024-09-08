using AutoMapper;
using OfficeOpenXml;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.DTO;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Services
{
    public class HomeService
    {
        private readonly IUnitOfWork db;
        private readonly IMapper mapper;
        public HomeService(IUnitOfWork _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public void ImportExcelFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                new ArgumentException();

            using var stream = new MemoryStream();
            file.CopyTo(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets[0];

            var drinks = new List<Drink>();
            var brands = new List<Brand>();

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var drinkName = worksheet.Cells[row, 1].Value.ToString();
                var price = int.Parse(worksheet.Cells[row, 2].Value.ToString());
                var brandName = worksheet.Cells[row, 3].Value.ToString();
                var imgPath = worksheet.Cells[row, 4].Value.ToString();

                var brand = brands.FirstOrDefault(b => b.Name == brandName);
                if (brand == null)
                {
                    brand = new Brand { Name = brandName };
                    brands.Add(brand);
                }

                drinks.Add(new Drink { Name = drinkName, Price = price, Brand = brand, ImagePath = imgPath });
            }

            db.Brands.CreateRange(brands);
            db.Drinks.CreateRange(drinks);
            db.Save();
        }

        public IEnumerable<DrinkDTO> GetAllDrinksDTO()
        {
            var drinks = db.Drinks.GetAll();
            var drinkDTOs = mapper.Map<List<DrinkDTO>>(drinks);
            return drinkDTOs;
        }
        
        public IEnumerable<DrinkDTO> GetAllDrinksWithCurrentBrand(string brandName)
        {
            var drinks = db.Drinks.Find(d => d.Brand.Name == brandName);
            var drinkDTOs = mapper.Map<List<DrinkDTO>>(drinks);
            return drinkDTOs;
        }
    }
}
