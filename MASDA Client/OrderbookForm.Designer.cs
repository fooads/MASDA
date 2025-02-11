using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MASDA_Client
{
    partial class OrderbookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RemoveOrderbookButton = new Button();
            TickerSelector = new ComboBox();
            RetrieveOrderbookButton = new Button();
            TickerTableLabel = new Label();
            OrderbookTable = new DataGridView();
            Layer = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            OrderSideSelector = new ComboBox();
            SubmitOrderButton = new Button();
            PriceInput = new NumericUpDown();
            PriceLabel = new Label();
            QuantityLabel = new Label();
            QuantityInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)OrderbookTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PriceInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)QuantityInput).BeginInit();
            SuspendLayout();
            // 
            // RemoveOrderbookButton
            // 
            RemoveOrderbookButton.Location = new Point(460, 12);
            RemoveOrderbookButton.Name = "RemoveOrderbookButton";
            RemoveOrderbookButton.Size = new Size(170, 29);
            RemoveOrderbookButton.TabIndex = 1;
            RemoveOrderbookButton.Text = "Remove Orderbook";
            RemoveOrderbookButton.UseVisualStyleBackColor = true;
            RemoveOrderbookButton.Click += RemoveOrderbookButton_Click;
            // 
            // TickerSelector
            // 
            TickerSelector.FormattingEnabled = true;
            TickerSelector.Location = new Point(12, 12);
            TickerSelector.Name = "TickerSelector";
            TickerSelector.Size = new Size(151, 28);
            TickerSelector.TabIndex = 3;
            TickerSelector.Text = "Select ticker";
            // 
            // RetrieveOrderbookButton
            // 
            RetrieveOrderbookButton.Enabled = false;
            RetrieveOrderbookButton.Location = new Point(169, 11);
            RetrieveOrderbookButton.Name = "RetrieveOrderbookButton";
            RetrieveOrderbookButton.Size = new Size(94, 29);
            RetrieveOrderbookButton.TabIndex = 4;
            RetrieveOrderbookButton.Text = "Retrieve";
            RetrieveOrderbookButton.UseVisualStyleBackColor = true;
            RetrieveOrderbookButton.Click += RetrieveOrderbookButton_Click;
            // 
            // TickerTableLabel
            // 
            TickerTableLabel.BackColor = Color.White;
            TickerTableLabel.BorderStyle = BorderStyle.FixedSingle;
            TickerTableLabel.Location = new Point(12, 43);
            TickerTableLabel.Name = "TickerTableLabel";
            TickerTableLabel.Size = new Size(121, 22);
            TickerTableLabel.TabIndex = 5;
            TickerTableLabel.Text = "Ticker: ";
            TickerTableLabel.Visible = false;
            // 
            // OrderbookTable
            // 
            OrderbookTable.AllowUserToAddRows = false;
            OrderbookTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OrderbookTable.BackgroundColor = SystemColors.Control;
            OrderbookTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderbookTable.Columns.AddRange(new DataGridViewColumn[] { Layer, Price, Quantity });
            OrderbookTable.Location = new Point(12, 66);
            OrderbookTable.Name = "OrderbookTable";
            OrderbookTable.RowHeadersVisible = false;
            OrderbookTable.RowHeadersWidth = 51;
            OrderbookTable.Size = new Size(359, 206);
            OrderbookTable.TabIndex = 6;
            OrderbookTable.Visible = false;
            // 
            // Layer
            // 
            Layer.HeaderText = "Layer";
            Layer.MinimumWidth = 6;
            Layer.Name = "Layer";
            Layer.ReadOnly = true;
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
            // OrderSideSelector
            // 
            OrderSideSelector.FormattingEnabled = true;
            OrderSideSelector.Location = new Point(428, 57);
            OrderSideSelector.Name = "OrderSideSelector";
            OrderSideSelector.Size = new Size(151, 28);
            OrderSideSelector.TabIndex = 7;
            OrderSideSelector.Text = "Choose order side";
            OrderSideSelector.Visible = false;
            // 
            // SubmitOrderButton
            // 
            SubmitOrderButton.Location = new Point(485, 206);
            SubmitOrderButton.Name = "SubmitOrderButton";
            SubmitOrderButton.Size = new Size(94, 29);
            SubmitOrderButton.TabIndex = 10;
            SubmitOrderButton.Text = "Submit";
            SubmitOrderButton.UseVisualStyleBackColor = true;
            SubmitOrderButton.Visible = false;
            SubmitOrderButton.Click += SubmitOrderButton_Click;
            // 
            // PriceInput
            // 
            PriceInput.Location = new Point(428, 111);
            PriceInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            PriceInput.Name = "PriceInput";
            PriceInput.Size = new Size(125, 27);
            PriceInput.TabIndex = 11;
            PriceInput.Visible = false;
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(428, 88);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(41, 20);
            PriceLabel.TabIndex = 12;
            PriceLabel.Text = "Price";
            PriceLabel.Visible = false;
            // 
            // QuantityLabel
            // 
            QuantityLabel.AutoSize = true;
            QuantityLabel.Location = new Point(428, 141);
            QuantityLabel.Name = "QuantityLabel";
            QuantityLabel.Size = new Size(65, 20);
            QuantityLabel.TabIndex = 13;
            QuantityLabel.Text = "Quantity";
            QuantityLabel.Visible = false;
            // 
            // QuantityInput
            // 
            QuantityInput.Location = new Point(428, 164);
            QuantityInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            QuantityInput.Name = "QuantityInput";
            QuantityInput.Size = new Size(124, 27);
            QuantityInput.TabIndex = 14;
            QuantityInput.Visible = false;
            // 
            // OrderbookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 257);
            Controls.Add(QuantityInput);
            Controls.Add(QuantityLabel);
            Controls.Add(PriceLabel);
            Controls.Add(PriceInput);
            Controls.Add(SubmitOrderButton);
            Controls.Add(OrderSideSelector);
            Controls.Add(OrderbookTable);
            Controls.Add(TickerTableLabel);
            Controls.Add(RetrieveOrderbookButton);
            Controls.Add(TickerSelector);
            Controls.Add(RemoveOrderbookButton);
            Name = "OrderbookForm";
            Text = "OrderbookForm";
            ((System.ComponentModel.ISupportInitialize)OrderbookTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)PriceInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)QuantityInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button RemoveOrderbookButton;
        private ComboBox TickerSelector;
        private Button RetrieveOrderbookButton;
        private Label TickerTableLabel;
        private DataGridView OrderbookTable;
        private DataGridViewTextBoxColumn Layer;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private ComboBox OrderSideSelector;
        private Button SubmitOrderButton;
        private NumericUpDown PriceInput;
        private Label PriceLabel;
        private Label QuantityLabel;
        private NumericUpDown QuantityInput;
    }
}