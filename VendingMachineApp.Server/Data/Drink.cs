namespace VendingMachineApp.Server.Data
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Quantity { get; set; }
        public string ImagePath { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
