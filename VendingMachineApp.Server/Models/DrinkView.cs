namespace VendingMachineApp.Server.Models
{
    public class DrinkView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string BrandName { get; set; }
        public string ImagePath { get; set; }
    }
}
