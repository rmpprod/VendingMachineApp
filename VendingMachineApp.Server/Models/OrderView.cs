using VendingMachineApp.Server.Data;

namespace VendingMachineApp.Server.Models
{
    public class OrderView
    {
        public int Id { get; set; }
        public int Sum { get; set; }

        public List<Drink> Drinks { get; set; }

        public DateTime Date { get; set; }
    }
}
