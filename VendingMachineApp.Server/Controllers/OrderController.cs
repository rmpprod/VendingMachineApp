using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VendingMachineApp.Server.DTO;
using VendingMachineApp.Server.Models;
using VendingMachineApp.Server.Services;

namespace VendingMachineApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderService orderService;
        public OrderController(OrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet("{id}")]
        public IResult GetOrder(int id)
        {
            var order = orderService.Get(id);
            if (order != null)
                return Results.Ok(order);
            return Results.NotFound();
        }

        [HttpPost]
        public IResult MakeOrder([FromBody] IEnumerable<OrderItemView> orderItems)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderItemView, OrderItemDTO>()).CreateMapper();
            var items = mapper.Map<IEnumerable<OrderItemView>, List<OrderItemDTO>>(orderItems);
            var orderDTO = orderService.Make(items);
            var uri = Url.Action("GetOrder", new { id = orderDTO.Id });
            return Results.CreatedAtRoute(uri, orderDTO);
        }
    }
}
