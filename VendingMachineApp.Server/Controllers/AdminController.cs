using Microsoft.AspNetCore.Mvc;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.Models;
using VendingMachineApp.Server.Services;

namespace VendingMachineApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService;
        public AdminController(AdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpGet("drink/{id}")]
        public IResult GetDrink(int id)
        {
            var drink = adminService.GetDrink(id);
            if (drink != null)
                return Results.Ok(drink);
            return Results.NotFound("Такого напитка не существует");
        }

        [HttpGet("coin/{id}")]
        public IResult GetCoin(int id)
        {
            var coin = adminService.GetCoin(id);
            if(coin != null)
                return Results.Ok(coin);
            return Results.NotFound("Монеты такого номинала нет");
        }

        [HttpPatch("coin")]
        public IResult UpdateCoin([FromBody] CoinView coin)
        {
            var coinDTO = adminService.UpdateCoin(coin.Id, coin.Quantity);
            if (coinDTO != null)
                return Results.Ok(coinDTO);
            return Results.BadRequest("Не удалось обновить кол-во монет, возможно монеты такого номинала нет");
        }

        [HttpPatch("drink/name")]
        public IResult UpdateDrinkName([FromBody] DrinkView drink)
        {
            var drinkDTO = adminService.UpdateDrinkName(drink.Id, drink.Name);
            if (drinkDTO != null)
                return Results.Ok(drinkDTO);
            return Results.NotFound("Не удалось обновить имя напитка");
        }

        [HttpPatch("drink/quantity")]
        public IResult UpdateDrinkQuantity([FromBody] DrinkView drink)
        {
            var drinkDTO = adminService.UpdateDrinkQuantity(drink.Id, drink.Quantity);
            if (drinkDTO != null)
                return Results.Ok(drinkDTO);
            return Results.BadRequest("Не удалось обновить количество напитка");
        }

        [HttpPatch("drink/price")]
        public IResult UpdateDrinkPrice([FromBody] DrinkView drink)
        {
            var drinkDTO = adminService.UpdateDrinkPrice(drink.Id, drink.Price);
            if (drinkDTO != null)
                return Results.Ok(drinkDTO);
            return Results.BadRequest("Не удалось обновить цену напитка");
        }

        [HttpPatch("drink/imagepath")]
        public IResult UpdateDrinkImagePath([FromBody] DrinkView drink)
        {
            var drinkDTO = adminService.UpdateDrinkImagePath(drink.Id, drink.ImagePath);
            if (drinkDTO != null)
                return Results.Ok(drinkDTO);
            return Results.BadRequest("Не удалось обновить фото напитка");
        }
    }
}
