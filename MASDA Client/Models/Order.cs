namespace MASDA_Client.Models
{
    public class Order
    {
        public required string Layer { get; set; }  // "Ask 1", "Bid 1", etc.
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
    }
}
