namespace MASDA_Server.Models
{
    public class Order
    {
        public required string Layer { get; set; }  
        public required int Price { get; set; }
        public required int Quantity { get; set; }
    }
}
