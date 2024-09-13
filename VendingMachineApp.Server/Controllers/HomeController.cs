using Microsoft.AspNetCore.Mvc;
using VendingMachineApp.Server.Services;

namespace VendingMachineApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly HomeService homeService;
        public HomeController(HomeService _homeService)
        {
            homeService = _homeService;
        }

        [HttpGet]
        public IResult GetDrinksCatalog()
        {
            var result = homeService.GetAllDrinksDTO();
            if (result != null)
                return Results.Ok(result);
            return Results.NotFound("Что-то пошло не так");
        }

        [HttpPost]
        public IResult ImportExcel(IFormFile file)
        {
            homeService.ImportExcelFile(file);
            var uri = Url.Action("GetDrinksCatalog");
            return Results.CreatedAtRoute(uri);
        }
    }
}
