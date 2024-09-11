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
    }
}
