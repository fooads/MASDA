using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Channels;
using MASDA_Server.Models;
using static MASDA_Server.Utils;

public class TradeAndOrderbookService : BackgroundService
{
    private static readonly Random _randomNumberGenerator = new Random();
    public static readonly List<Trade> tradeHistory = new(); // History of all trades made

    public static readonly ConcurrentDictionary<Guid, ChannelWriter<Trade>> Subscribers = new(); // Subscribers to trades

    public static readonly ConcurrentDictionary<string, OrderBook> Orderbooks = new(); // Orderbooks for all tickers
    public static readonly List<string> tickers = GenerateRandomTickers(12); // Random tickers

    private readonly IHubContext<ConnectionHub> _hubContext;

    public TradeAndOrderbookService(IHubContext<ConnectionHub> hubContext)
    {
        _hubContext = hubContext;

        // Generates a random orderbook for each ticker on startup
        foreach (var ticker in tickers)
        {
            Orderbooks[ticker] = GenerateRandomOrderBook(ticker);
        }
    }

    // Needed for the connection
    public static Guid Subscribe(ChannelWriter<Trade> writer)
    {
        var id = Guid.NewGuid();
        Subscribers.TryAdd(id, writer);
        return id;
    }

    // Needed for the connection
    public static void Unsubscribe(Guid id)
    {
        Subscribers.TryRemove(id, out _);
    }

    // Generates a trade and applies it to the orderbook
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string randomTicker = Orderbooks.Keys.ElementAt(_randomNumberGenerator.Next(Orderbooks.Count));
            var randomTrade = GenerateRandomTrade(Orderbooks[randomTicker]); // Generates a random trade for a random ticker

            tradeHistory.Add(randomTrade); // Adds the new trade to the trade history
            ApplyTradeToOrderBook(Orderbooks[randomTicker], randomTrade); // Changes the orderbook based on the random trade

            // Notifies all clients subscribed to this ticker's orderbook
            await _hubContext.Clients.Group(randomTrade.Ticker).SendAsync("UpdateOrderbook", Orderbooks[randomTrade.Ticker], stoppingToken);

            // Sends the trade to all clients
            foreach (var subscriber in Subscribers.Values)
            {
                await subscriber.WriteAsync(randomTrade, stoppingToken);
            }

            await Task.Delay(5000, stoppingToken); // 5-second delay between random trades
        }
    }

    // Processes a trade based on the orderbook, returns the fulfilled trade, updates the orderbook
    public static Trade ApplyTradeToOrderBook(OrderBook orderBook, Trade trade)
    {
        int requestedPrice = int.Parse(trade.Price);
        int requestedQuantity = int.Parse(trade.Quantity);

        // Depending on the orderbook, requested price and quantity might be different from fulfilled price and quantity
        int fulfilledPrice = 0;
        int fulfilledQuantity = 0;

        if (trade.Side == "Buy")
        {
            var highestAsk = orderBook.Asks.OrderByDescending(ask => ask.Price).FirstOrDefault();

            // Checks if there is at least one ask order in the orderbook
            if (highestAsk != null)
            {
                // If requested price is higher than the highest ask, modifies the highest ask entry of  the orderbook
                if (requestedPrice > highestAsk.Price)
                {
                    int quantityReduction = Math.Min(requestedQuantity, highestAsk.Quantity);
                    highestAsk.Quantity = highestAsk.Quantity - quantityReduction;

                    fulfilledQuantity = fulfilledQuantity + quantityReduction;
                    fulfilledPrice = highestAsk.Price;

                    // Removes the orderbook entry if it is fully fulfilled
                    if (highestAsk.Quantity <= 0)
                    {
                        orderBook.Asks.Remove(highestAsk);
                    }
                }
                // Otherwise, find the orderbook entry and modify that
                else
                {
                    var matchingAsk = orderBook.Asks.FirstOrDefault(ask => ask.Price == requestedPrice);

                    if (matchingAsk != null)
                    {
                        int quantityReduction = Math.Min(requestedQuantity, matchingAsk.Quantity);
                        matchingAsk.Quantity = matchingAsk.Quantity - quantityReduction;

                        fulfilledQuantity = fulfilledQuantity + quantityReduction;
                        fulfilledPrice = matchingAsk.Price;

                        if (matchingAsk.Quantity <= 0)
                        {
                            orderBook.Asks.Remove(matchingAsk);
                        }
                    }
                }
            }
        }
        else
        {
            var lowestBid = orderBook.Bids.OrderBy(bid => bid.Price).FirstOrDefault();

            // Checks if there is at least one bid order in the orderbook
            if (lowestBid!= null)
            {
                // If requested price is lower than the lowest bid, modifies the lowest bid entry of the orderbook
                if (requestedPrice < lowestBid.Price)
                {
                    int quantityReduction = Math.Min(requestedQuantity, lowestBid.Quantity);
                    lowestBid.Quantity = lowestBid.Quantity - quantityReduction;

                    fulfilledQuantity = fulfilledQuantity + quantityReduction;
                    fulfilledPrice = lowestBid.Price;

                    if (lowestBid.Quantity <= 0)
                    {
                        orderBook.Bids.Remove(lowestBid);
                    }
                }
                // Otherwise, find the orderbook entry and modify that
                else
                {
                    var matchingBid = orderBook.Bids.FirstOrDefault(bid => bid.Price == requestedPrice);
                    if (matchingBid!= null) 
                    {
                        int quantityReduction = Math.Min(requestedQuantity, matchingBid.Quantity);
                        matchingBid.Quantity = matchingBid.Quantity - quantityReduction;
                        
                        fulfilledQuantity = fulfilledQuantity + quantityReduction;
                        fulfilledPrice = matchingBid.Price;

                        if (matchingBid.Quantity <= 0)
                        {
                            orderBook.Bids.Remove(matchingBid);
                        }
                    }
                }
            } 
        }

        // Returns a fulfilled trade, which might be different from the requested trade
        return new Trade
        {
            Ticker = trade.Ticker,
            Side = trade.Side,
            Price = fulfilledPrice.ToString(),
            Quantity = fulfilledQuantity.ToString(),
            Time = DateTime.Now.ToString("HH:mm:ss.fff")
        };
    }
}