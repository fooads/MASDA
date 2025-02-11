
namespace MASDA_Client
{
    partial class ClientWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConnectionPanel = new Panel();
            TogglePannel = new FlowLayoutPanel();
            TradehistoryToggleButton = new Button();
            OrderbooksToggleButton = new Button();
            ConnectionStatus = new Label();
            DisconnectButton = new Button();
            ConnectButton = new Button();
            OrderbookPanel = new Panel();
            AddOrderbookButton = new LinkLabel();
            Orderbooks = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            TradehistoryPanel = new Panel();
            TradehistoryTable = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Side = new DataGridViewTextBoxColumn();
            Ticker = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            ConnectionPanel.SuspendLayout();
            TogglePannel.SuspendLayout();
            OrderbookPanel.SuspendLayout();
            Orderbooks.SuspendLayout();
            TradehistoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TradehistoryTable).BeginInit();
            SuspendLayout();
            // 
            // ConnectionPanel
            // 
            ConnectionPanel.BorderStyle = BorderStyle.FixedSingle;
            ConnectionPanel.Controls.Add(TogglePannel);
            ConnectionPanel.Controls.Add(ConnectionStatus);
            ConnectionPanel.Controls.Add(DisconnectButton);
            ConnectionPanel.Controls.Add(ConnectButton);
            ConnectionPanel.Location = new Point(12, 12);
            ConnectionPanel.Name = "ConnectionPanel";
            ConnectionPanel.Size = new Size(332, 324);
            ConnectionPanel.TabIndex = 0;
            // 
            // TogglePannel
            // 
            TogglePannel.BorderStyle = BorderStyle.FixedSingle;
            TogglePannel.Controls.Add(TradehistoryToggleButton);
            TogglePannel.Controls.Add(OrderbooksToggleButton);
            TogglePannel.Location = new Point(-1, 287);
            TogglePannel.Name = "TogglePannel";
            TogglePannel.Size = new Size(332, 36);
            TogglePannel.TabIndex = 3;
            TogglePannel.Visible = false;
            // 
            // TradehistoryToggleButton
            // 
            TradehistoryToggleButton.Location = new Point(3, 3);
            TradehistoryToggleButton.Name = "TradehistoryToggleButton";
            TradehistoryToggleButton.Size = new Size(155, 29);
            TradehistoryToggleButton.TabIndex = 0;
            TradehistoryToggleButton.Text = "Trade History";
            TradehistoryToggleButton.UseVisualStyleBackColor = true;
            TradehistoryToggleButton.Click += TradehistoryToggleButton_Click;
            // 
            // OrderbooksToggleButton
            // 
            OrderbooksToggleButton.Location = new Point(164, 3);
            OrderbooksToggleButton.Name = "OrderbooksToggleButton";
            OrderbooksToggleButton.Size = new Size(163, 29);
            OrderbooksToggleButton.TabIndex = 1;
            OrderbooksToggleButton.Text = "Orderbooks";
            OrderbooksToggleButton.UseVisualStyleBackColor = true;
            OrderbooksToggleButton.Click += OrderbooksToggleButton_Click;
            // 
            // ConnectionStatus
            // 
            ConnectionStatus.AutoSize = true;
            ConnectionStatus.Location = new Point(90, 181);
            ConnectionStatus.Name = "ConnectionStatus";
            ConnectionStatus.Size = new Size(146, 20);
            ConnectionStatus.TabIndex = 2;
            ConnectionStatus.Text = "Status: Disconnected";
            // 
            // DisconnectButton
            // 
            DisconnectButton.Enabled = false;
            DisconnectButton.Location = new Point(90, 122);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(147, 42);
            DisconnectButton.TabIndex = 1;
            DisconnectButton.Text = "Disconnect";
            DisconnectButton.UseVisualStyleBackColor = true;
            DisconnectButton.Click += DisconnectButton_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(90, 74);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(147, 42);
            ConnectButton.TabIndex = 0;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // OrderbookPanel
            // 
            OrderbookPanel.BorderStyle = BorderStyle.FixedSingle;
            OrderbookPanel.Controls.Add(AddOrderbookButton);
            OrderbookPanel.Controls.Add(Orderbooks);
            OrderbookPanel.Location = new Point(350, 12);
            OrderbookPanel.Name = "OrderbookPanel";
            OrderbookPanel.Size = new Size(653, 324);
            OrderbookPanel.TabIndex = 1;
            OrderbookPanel.Visible = false;
            // 
            // AddOrderbookButton
            // 
            AddOrderbookButton.AutoSize = true;
            AddOrderbookButton.Location = new Point(7, 16);
            AddOrderbookButton.Name = "AddOrderbookButton";
            AddOrderbookButton.Size = new Size(113, 20);
            AddOrderbookButton.TabIndex = 1;
            AddOrderbookButton.TabStop = true;
            AddOrderbookButton.Text = "Add Orderbook";
            AddOrderbookButton.LinkClicked += AddOrderbookButton_LinkClicked;
            // 
            // Orderbooks
            // 
            Orderbooks.Controls.Add(tabPage1);
            Orderbooks.Controls.Add(tabPage2);
            Orderbooks.Location = new Point(3, 39);
            Orderbooks.Name = "Orderbooks";
            Orderbooks.SelectedIndex = 0;
            Orderbooks.Size = new Size(645, 279);
            Orderbooks.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(637, 246);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(637, 246);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // TradehistoryPanel
            // 
            TradehistoryPanel.BorderStyle = BorderStyle.FixedSingle;
            TradehistoryPanel.Controls.Add(TradehistoryTable);
            TradehistoryPanel.Location = new Point(12, 342);
            TradehistoryPanel.Name = "TradehistoryPanel";
            TradehistoryPanel.Size = new Size(991, 247);
            TradehistoryPanel.TabIndex = 2;
            TradehistoryPanel.Visible = false;
            // 
            // TradehistoryTable
            // 
            TradehistoryTable.AllowUserToAddRows = false;
            TradehistoryTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TradehistoryTable.BackgroundColor = SystemColors.Control;
            TradehistoryTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TradehistoryTable.Columns.AddRange(new DataGridViewColumn[] { Time, Side, Ticker, Price, Quantity });
            TradehistoryTable.Location = new Point(3, 3);
            TradehistoryTable.Name = "TradehistoryTable";
            TradehistoryTable.RowHeadersVisible = false;
            TradehistoryTable.RowHeadersWidth = 51;
            TradehistoryTable.Size = new Size(979, 239);
            TradehistoryTable.TabIndex = 0;
            // 
            // Time
            // 
            Time.HeaderText = "Time";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.ReadOnly = true;
            // 
            // Side
            // 
            Side.HeaderText = "Side";
            Side.MinimumWidth = 6;
            Side.Name = "Side";
            Side.ReadOnly = true;
            // 
            // Ticker
            // 
            Ticker.HeaderText = "Ticker";
            Ticker.MinimumWidth = 6;
            Ticker.Name = "Ticker";
            Ticker.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // ClientWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 601);
            Controls.Add(TradehistoryPanel);
            Controls.Add(OrderbookPanel);
            Controls.Add(ConnectionPanel);
            Name = "ClientWindow";
            Text = "MASDA Client";
            ConnectionPanel.ResumeLayout(false);
            ConnectionPanel.PerformLayout();
            TogglePannel.ResumeLayout(false);
            OrderbookPanel.ResumeLayout(false);
            OrderbookPanel.PerformLayout();
            Orderbooks.ResumeLayout(false);
            TradehistoryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TradehistoryTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ConnectionPanel;
        private Panel OrderbookPanel;
        private Panel TradehistoryPanel;
        private Button DisconnectButton;
        private Button ConnectButton;
        private Label ConnectionStatus;
        private FlowLayoutPanel TogglePannel;
        private Button TradehistoryToggleButton;
        private Button OrderbooksToggleButton;
        private TabControl Orderbooks;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private LinkLabel AddOrderbookButton;
        private DataGridView TradehistoryTable;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Side;
        private DataGridViewTextBoxColumn Ticker;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
    }
}
