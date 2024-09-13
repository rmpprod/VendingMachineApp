namespace VendingMachineApp.Server.DTO
{
    public class DrinkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}
