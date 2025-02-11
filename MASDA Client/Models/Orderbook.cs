namespace MASDA_Client.Models
{
    public class Orderbook
    {
        public required string Ticker { get; set; }  // Example: "ABC"
        public required List<Order> Asks { get; set; } = new();
        public required List<Order> Bids { get; set; } = new();
    }
}
