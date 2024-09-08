namespace VendingMachineApp.Server.Data
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
