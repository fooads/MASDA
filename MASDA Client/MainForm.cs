using Microsoft.AspNetCore.SignalR.Client;
using MASDA_Client.Models;

namespace MASDA_Client
{
    public partial class ClientWindow : Form
    {
        private readonly HubConnection _connection;
        private bool _shouldReconnect = true;
        private CancellationTokenSource? _tradeHistoryCancellationTokenSource;

        public ClientWindow()
        {
            InitializeComponent();

            // Prelim connection setup
            _connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/connectionHub").Build();

            // Handle disconnection
            _connection.Closed += async (error) =>
            {
                // Update UI because client disconnected
                UpdateStatus(false);
                while (_shouldReconnect)
                {
                    await Task.Delay(new Random().Next(5, 10) * 1000); // Wait for 5-10 seconds before reconnecting
                    await Connect();
                    break;
                }
            };
        }

        // Handles subscription to trade history
        private async Task SubscribeToTradeHistory()
        {
            _tradeHistoryCancellationTokenSource?.Cancel();
            _tradeHistoryCancellationTokenSource = new CancellationTokenSource();

            // Duplicate data is shown if table is not cleared
            TradehistoryTable.Rows.Clear(); 

            // Receive the trade stream
            var tradeStream = _connection.StreamAsync<Trade>(
                "StreamTradeHistory",
                _tradeHistoryCancellationTokenSource.Token
            );

            // Populate the trade history table
            await foreach (var trade in tradeStream)
            {
                if (TradehistoryTable.InvokeRequired)
                {
                    TradehistoryTable.Invoke(new Action(() =>
                    {
                        TradehistoryTable.Rows.Add(trade.Time, trade.Side, trade.Ticker, trade.Price, trade.Quantity);
                    }));
                }
                else
                {
                    TradehistoryTable.Rows.Add(trade.Time, trade.Side, trade.Ticker, trade.Price, trade.Quantity);
                }
            }
        }

        // Retrieves all available tickers from server
        private async Task<List<string>> GetTickersFromServer()
        {
            return await _connection.InvokeAsync<List<string>>("GetTickers");
        }

        // Opens a new tab for an orderbook
        private async void AddOrderbookButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Orderbook " + (Orderbooks.TabCount + 1).ToString(); // Example: Orderbook 1
            TabPage tabPage = new TabPage(title);

            // Gets available tickers when tab is created
            List<string> tickers = await GetTickersFromServer();

            // A new form is created (tickers are passed to it)
            OrderbookForm form = new OrderbookForm(tickers, _connection)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            tabPage.Controls.Add(form);
            Orderbooks.TabPages.Add(tabPage);
            form.Show();
            Orderbooks.SelectedTab = tabPage; // Newly created tab is selected
        }

        // Connects to server
        private async Task Connect()
        {
            try
            {
                _shouldReconnect = true; // Reconnection is set to true by default

                await _connection.StartAsync();
                UpdateStatus(true); // Updates the UI if connected to server
                
                // Automatically start receiving trade history when connected
                await SubscribeToTradeHistory();
            }
            catch (Exception ex)
            {
                UpdateStatus(false);
                MessageBox.Show($"Failed to connect to the server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Disconnects from server
        private async Task Disconnect()
        {
            // Client will not reconnect if disconnected manually
            _shouldReconnect = false;

            _tradeHistoryCancellationTokenSource?.Cancel();

            await _connection.StopAsync();
            UpdateStatus(false);
        }

        // Main menu's Connect button
        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            await Connect();
        }

        // Main menu's Disconnect button
        private async void DisconnectButton_Click(object sender, EventArgs e)
        {
            await Disconnect();
        }

        // Updates UI components based on connection status
        private void UpdateUI(bool connected)
        {
            if (connected)
            {
                ConnectionStatus.Text = "Status: Connected";
                DisconnectButton.Enabled = true;
                ConnectButton.Enabled = false;
                TogglePannel.Visible = true;
            }
            else
            {
                ConnectionStatus.Text = "Status: Disconnected";
                DisconnectButton.Enabled = false;
                ConnectButton.Enabled = true;
                TogglePannel.Visible = false;
                TradehistoryPanel.Visible = false;
                OrderbookPanel.Visible = false;
            }
        }

        // Handles thread-safe updating of the UI
        private void UpdateStatus(bool status)
        {
            if (ConnectionStatus.InvokeRequired)
            {
                ConnectionStatus.Invoke(new Action(() => UpdateUI(status)));
            }
            else
            {
                UpdateUI(status);
            }
        }

        // UI stuff
        private void TradehistoryToggleButton_Click(object sender, EventArgs e)
        {
            if (TradehistoryPanel.Visible)
            {
                TradehistoryPanel.Visible = false;
            }
            else
            {
                TradehistoryPanel.Visible = true;
            }
        }

        // UI stuff
        private void OrderbooksToggleButton_Click(object sender, EventArgs e)
        {
            if (OrderbookPanel.Visible)
            {
                OrderbookPanel.Visible = false;
            }
            else
            {
                OrderbookPanel.Visible = true;
                Orderbooks.TabPages.Clear();
            }
        }
    }
}
