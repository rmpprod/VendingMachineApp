using Microsoft.AspNetCore.Mvc;
using VendingMachineApp.Server.Data;
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
            return Results.BadRequest("Такого напитка не существует");
        }

        [HttpGet("coin/{id}")]
        public IResult GetCoin(int id)
        {
            var coin = adminService.GetCoin(id);
            if(coin != null)
                return Results.Ok(coin);
            return Results.BadRequest("Монеты такого номинала нет");
        }
    }
}
