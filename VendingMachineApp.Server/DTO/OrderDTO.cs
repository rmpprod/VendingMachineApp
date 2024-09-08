using VendingMachineApp.Server.Data;

namespace VendingMachineApp.Server.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }

        public List<OrderItemDTO> Items { get; set; }
    }
}
