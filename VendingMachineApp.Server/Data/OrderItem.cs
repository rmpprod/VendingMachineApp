namespace VendingMachineApp.Server.Data
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int DrinkId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}
