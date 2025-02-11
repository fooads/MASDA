using MASDA_Server.Models;

namespace MASDA_Server
{
    public class Utils
    {

        private static readonly Random _randomNumberGenerator = new Random();

        // Generates count number of 3-letter tickers
        public static List<string> GenerateRandomTickers(int count)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return Enumerable.Range(0, count)
                             .Select(_ => new string(Enumerable.Range(0, 3)
                                                               .Select(_ => letters[_randomNumberGenerator.Next(letters.Length)])
                                                               .ToArray()))
                             .ToList();
        }

        // Generates a random orderbook for a ticker
        public static OrderBook GenerateRandomOrderBook(string ticker)
        {
            var orderBook = new OrderBook { Ticker = ticker, Asks = [], Bids = [] };

            int basePrice = _randomNumberGenerator.Next(90, 110); // Picks a random mid-price

            // Generates ask orders which are higher than the mid-price
            for (int i = 10; i > 0; i--)
            {
                orderBook.Asks.Add(new Order
                {
                    Layer = $"Ask {i}",
                    Price = basePrice + i,  // Each ask layer's price is incremented by 1
                    Quantity = _randomNumberGenerator.Next(1, 50) // Random quantity
                });
            }

            // Generates bid orders which are lower than the mid-price
            for (int i = 1; i <= 10; i++)
            {
                orderBook.Bids.Add(new Order
                {
                    Layer = $"Bid {i}",
                    Price = basePrice - i,  // Each bid layer's price is decremented by 1
                    Quantity = _randomNumberGenerator.Next(1, 50) // Random quantity
                });
            }

            return orderBook;
        }

        // Generates a random trade for an orderbook
        public static Trade GenerateRandomTrade(OrderBook orderBook)
        {
            string side = _randomNumberGenerator.Next(2) == 0 ? "Buy" : "Sell"; // Picks buy or sell randomly
            int price;
            int quantity = _randomNumberGenerator.Next(1, 5); // Random quantity not too big

            if (side == "Buy")
            {
                // Generated buy trade will be at the lowest ask price
                price = orderBook.Asks.Min(a => a.Price);
            }
            else
            {
                // Generated sell trade will be at the highest bid price
                price = orderBook.Bids.Max(b => b.Price);
            }

            return new Trade
            {
                Time = DateTime.Now.ToString("HH:mm:ss.fff"), // Current timestamp
                Side = side,
                Ticker = orderBook.Ticker,
                Price = price.ToString(),
                Quantity = quantity.ToString()
            };
        }
    }
}
