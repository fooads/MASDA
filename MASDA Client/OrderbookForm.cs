using System.Windows.Forms;
using MASDA_Client.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace MASDA_Client
{
    public partial class OrderbookForm : Form
    {
        private readonly List<string> _tickers;  // Available tickers
        private string _selectedTicker; // Ticker selected by user
        private readonly HubConnection _connection;

        // Used to isolate orderbook-related functionality to individual tabs
        private IDisposable _orderbookUpdateHandler;

        public OrderbookForm(List<string> tickers, HubConnection connection)
        {
            InitializeComponent();
            _tickers = tickers;
            _connection = connection;

            // Populates the ticker selector
            foreach (var ticker in _tickers)
            {
                TickerSelector.Items.Add(ticker);
            }

            // Gives two options to manually place a trade order
            OrderSideSelector.Items.Add("Buy");
            OrderSideSelector.Items.Add("Sell");

            // Handles ticker selection
            TickerSelector.SelectedIndexChanged += (sender, e) =>
            {
                if (TickerSelector.SelectedItem is string selectedTicker)
                {
                    RetrieveOrderbookButton.Enabled = true;
                    _selectedTicker = selectedTicker;
                }
            };
        }

        // Gets the current orderbook state to show as soon as orderbook is retrieved
        private async Task<Orderbook> GetInitialOrderbook(string ticker)
        {
            return await _connection.InvokeAsync<Orderbook>("GetOrderbook", ticker);
        }

        // Subscribes to an orderbook
        private async Task SubscribeToOrderbook(string ticker)
        {
            // Gets the initial orderbook for the selected ticker
            Orderbook initialOrderbook = await GetInitialOrderbook(ticker);
            UpdateOrderbookUI(initialOrderbook);

            // Registers a handler for updates of a specific orderbook
            _orderbookUpdateHandler = _connection.On<Orderbook>("UpdateOrderbook", orderbook =>
            {
                if (orderbook.Ticker == ticker)
                {
                    UpdateOrderbookUI(orderbook);
                }
            });

            await _connection.InvokeAsync("SubscribeToOrderbook", ticker);
        }

        // Changes UI and subscribes to an orderbook after Retrieve button is clicked
        private async void RetrieveOrderbookButton_Click(object sender, EventArgs e)
        {
            await SubscribeToOrderbook(_selectedTicker);
            TickerTableLabel.Visible = true;
            OrderbookTable.Visible = true;
            TickerSelector.Visible = false;
            RetrieveOrderbookButton.Visible = false;

            OrderSideSelector.Visible = true;
            PriceLabel.Visible = true;
            PriceInput.Visible = true;
            QuantityLabel.Visible = true;
            QuantityInput.Visible = true;
            SubmitOrderButton.Visible = true;

            TickerTableLabel.Top -= 31;
            OrderbookTable.Top -= 31;

            TickerTableLabel.Text = $"Ticker: {_selectedTicker}";

            if (this.Parent is TabPage orderbookTab && orderbookTab.Parent is TabControl Orderbooks)
            {
                orderbookTab.Text = _selectedTicker;
            }
        }

        // Changes UI when orderbook is removed
        private async void RemoveOrderbookButton_Click(object sender, EventArgs e)
        {
            if (this.Parent is TabPage orderbookTab && orderbookTab.Parent is TabControl Orderbooks)
            {
                // Checks if there is a selected ticker and unsubscribe from its orderbook
                if (!string.IsNullOrEmpty(_selectedTicker))
                {
                    await _connection.InvokeAsync("UnsubscribeFromOrderbook", _selectedTicker);
                    _orderbookUpdateHandler?.Dispose();
                }

                // Removes the tab
                int tabIndex = Orderbooks.TabPages.IndexOf(orderbookTab);
                Orderbooks.TabPages.Remove(orderbookTab);

                // Selects the tab to the left if there is one
                if (tabIndex > 0)
                {
                    Orderbooks.SelectedIndex = tabIndex - 1;
                }
                // Select the first available tab otherwise
                else if (Orderbooks.TabPages.Count > 0)
                {
                    Orderbooks.SelectedIndex = 0;
                }
            }
        }

        // Updates the orderbook table
        private void UpdateOrderbookUI(Orderbook orderbook)
        {
            if (OrderbookTable.InvokeRequired)
            {
                OrderbookTable.Invoke(new Action(() =>
                {
                    OrderbookTable.Rows.Clear();
                    foreach (var ask in orderbook.Asks)
                    {
                        OrderbookTable.Rows.Add(ask.Layer, ask.Price, ask.Quantity);
                    }
                    foreach (var bid in orderbook.Bids)
                    {
                        OrderbookTable.Rows.Add(bid.Layer, bid.Price, bid.Quantity);
                    }
                }));
            }
            else
            {
                OrderbookTable.Rows.Clear();
                foreach (var ask in orderbook.Asks)
                {
                    OrderbookTable.Rows.Add(ask.Layer, ask.Price, ask.Quantity);
                }
                foreach (var bid in orderbook.Bids)
                {
                    OrderbookTable.Rows.Add(bid.Layer, bid.Price, bid.Quantity);
                }
            }
        }

        // Sends the trade order to server
        private async void SubmitOrderButton_Click(object sender, EventArgs e)
        {
            // Shows error if order side is not selected
            if (OrderSideSelector.SelectedItem == null)
            {
                MessageBox.Show("Please select a trade side.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var trade = new Trade
                {
                    Ticker = _selectedTicker,
                    Side = OrderSideSelector.SelectedItem.ToString(),
                    Price = PriceInput.Value.ToString(),
                    Quantity = QuantityInput.Value.ToString(),
                    Time = DateTime.Now.ToString("HH:mm:ss.fff")
                };
                await _connection.InvokeAsync("SubmitTrade", trade);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit trade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
