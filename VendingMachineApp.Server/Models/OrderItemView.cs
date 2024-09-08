namespace VendingMachineApp.Server.Models
{
    public class OrderItemView
    {
        public int Id { get; set; }
        public int DrinkId { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}
