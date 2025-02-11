namespace MASDA_Client.Models
{
    public class Trade
    {
        public required string Time { get; set; }
        public required string Side { get; set; }
        public required string Ticker { get; set; }
        public required string Price { get; set; }
        public required string Quantity { get; set; }
    }
}
