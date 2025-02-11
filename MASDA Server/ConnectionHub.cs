using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using MASDA_Server.Models;

public class ConnectionHub : Hub
{
    // Sends the list of initially generated tickers 
    public List<string> GetTickers()
    {
        return TradeAndOrderbookService.tickers;
    }

    // Sends the orderbook of a ticker 
    public OrderBook GetOrderbook(string ticker)
    {
        return TradeAndOrderbookService.Orderbooks[ticker];
    }

    // Allows to subscribe to updates made to an orderbook
    public async Task SubscribeToOrderbook(string ticker)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, ticker);
    }

    // Allows to unsubscribe from updates made to an orderbook
    public async Task UnsubscribeFromOrderbook(string ticker)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, ticker);
    }

    // Allows to stream both past and future trades
    public async IAsyncEnumerable<Trade> StreamTradeHistory([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Sends existing trade history
        foreach (Trade trade in TradeAndOrderbookService.tradeHistory)
        {
            yield return trade;
        }

        // Sends continuously generated trades through a channel 
        var channel = Channel.CreateUnbounded<Trade>();
        var subscription = TradeAndOrderbookService.Subscribe(channel.Writer);

        // Yields newly generated trades
        try
        {
            while (await channel.Reader.WaitToReadAsync(cancellationToken))
            {
                while (channel.Reader.TryRead(out var trade))
                {
                    yield return trade;
                }
            }
        }
        // Unsubscribes when client disconnects
        finally
        {
            TradeAndOrderbookService.Unsubscribe(subscription);
        }
    }

    // Allows the user to manually submit a trade order
    public async Task SubmitTrade(Trade trade)
    {
        // Applies the trade to the orderbook first and gets actual fulfilled trade 
        Trade fulfilledTrade = TradeAndOrderbookService.ApplyTradeToOrderBook(TradeAndOrderbookService.Orderbooks[trade.Ticker], trade);

        // Does not proceed if the resulting quantity of fulfilled trade is 0
        if (fulfilledTrade.Quantity != "0")
        {
            // Adds the fulfilled trade to the trade history
            TradeAndOrderbookService.tradeHistory.Add(fulfilledTrade);

            // Notifies all clients subscribed to this ticker's orderbook
            await Clients.Group(fulfilledTrade.Ticker).SendAsync("UpdateOrderbook",TradeAndOrderbookService.Orderbooks[fulfilledTrade.Ticker]);

            // Writes the the fulfilled trade to the trade streaming channel, not the one submitted by the user
            // All subscribers will see the trade as soon as it is made
            foreach (var subscriber in TradeAndOrderbookService.Subscribers.Values)
            {
                await subscriber.WriteAsync(fulfilledTrade);
            }
        }
    }
}