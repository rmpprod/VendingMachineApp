using AutoMapper;
using VendingMachineApp.Server.Data;
using VendingMachineApp.Server.DTO;
using VendingMachineApp.Server.Interfaces;

namespace VendingMachineApp.Server.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork db;
        private readonly IMapper mapper;
        public OrderService(IUnitOfWork _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public OrderDTO Get(int id)
        {
            var order = db.Orders.GetWithInclude(oi => oi.Items).FirstOrDefault(o => o.Id == id);
            var orderDTO = mapper.Map<OrderDTO>(order);
            return orderDTO;
        }
        public void Make(IEnumerable<OrderItemDTO> items)
        {
            var order = new Order { Date = DateTime.Now };
            db.Orders.Create(order);
            db.Save();

            var orderItems = new List<OrderItem>();
            foreach(var item in items)
            {
                orderItems.Add(new OrderItem { DrinkId = item.DrinkId, OrderId = order.Id, Quantity = item.Quantity, Subtotal = item.Subtotal });
            }

            db.OrderItems.CreateRange(orderItems);
            db.Save();
        }
    }
}
