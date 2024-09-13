using AutoMapper;
using VendingMachineApp.Server.DTO;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Services
{
    public class AdminService
    {
        private readonly IUnitOfWork db;
        private readonly IMapper mapper;
        public AdminService(IUnitOfWork _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public DrinkDTO GetDrink(int id)
        {
            var drink = db.Drinks.Get(id);
            var drinkDTO = mapper.Map<DrinkDTO>(drink);
            return drinkDTO;
        }

        public CoinDTO GetCoin(int id)
        {
            var coin = db.Coins.Get(id);
            var coinDTO = mapper.Map<CoinDTO>(coin);
            return coinDTO;
        }

        public CoinDTO UpdateCoin(int id, int quantity)
        {
            var coin = db.Coins.Get(id);
            if (coin != null)
            {
                coin.Quantity += quantity;
                db.Save();
                var coinDTO = mapper.Map<CoinDTO>(coin);
                return coinDTO;
            }
            throw new KeyNotFoundException("Монета не найдена");
        }

        public DrinkDTO UpdateDrinkQuantity(int id, int quantity)
        {
            var drink = db.Drinks.Get(id);
            if (drink != null)
            {
                drink.Quantity += quantity;
                db.Save();
                var drinkDTO = mapper.Map<DrinkDTO>(drink);
                return drinkDTO;
            }
            throw new KeyNotFoundException("Напиток не найден");
        }

        public DrinkDTO UpdateDrinkPrice(int id, int price)
        {
            var drink = db.Drinks.Get(id);
            if (drink != null)
            {
                drink.Price = price;
                db.Save();
                var drinkDTO = mapper.Map<DrinkDTO>(drink);
                return drinkDTO;
            }
            throw new KeyNotFoundException("Напиток не найден");
        }

        public DrinkDTO UpdateDrinkImagePath(int id, string imagePath)
        {
            var drink = db.Drinks.Get(id);
            if (drink != null)
            {
                drink.ImagePath = imagePath;
                db.Save();
                var drinkDTO = mapper.Map<DrinkDTO>(drink);
                return drinkDTO;
            }
            throw new KeyNotFoundException("Напиток не найден");
        }

        public DrinkDTO UpdateDrinkName(int id, string name)
        {
            var drink = db.Drinks.Get(id);
            if (drink != null)
            {
                drink.Name = name;
                db.Save();
                var drinkDTO = mapper.Map<DrinkDTO>(drink);
                return drinkDTO;
            }
            throw new KeyNotFoundException("Напиток не найден");
        }
    }
}
