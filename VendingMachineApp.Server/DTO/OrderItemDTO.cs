namespace VendingMachineApp.Server.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int DrinkId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}
