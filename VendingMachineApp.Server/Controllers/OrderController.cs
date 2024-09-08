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
            return Results.Ok(order);
        }

        [HttpPost]
        public IResult MakeOrder([FromBody] IEnumerable<OrderItemView> orderItems)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderItemView, OrderItemDTO>()).CreateMapper();
            var items = mapper.Map<IEnumerable<OrderItemView>, List<OrderItemDTO>>(orderItems);
            orderService.Make(items);
            return Results.Ok();
        }
    }
}
