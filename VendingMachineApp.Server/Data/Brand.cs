namespace VendingMachineApp.Server.Data
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Drink>? Drinks { get; set; }
    }
}
