namespace MASDA_Server.Models
{
    public class OrderBook
    {
        public required string Ticker { get; set; }
        public required List<Order> Asks { get; set; } = new();
        public required List<Order> Bids { get; set; } = new();
    }
}
