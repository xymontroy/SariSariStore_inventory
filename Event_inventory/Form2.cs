using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using ZXing;


namespace Event_inventory
{
    public partial class Form2 : Form
    {
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\simon\OneDrive\Documents\Event.mdb";
        private OleDbConnection dbConnection;

        private Dictionary<string, int> scannedItems = new Dictionary<string, int>();
        private int totalAmount = 0;

        public Form2()
        {
            InitializeComponent();
            LoadData();
            InitializeDatabaseConnection();
            InitializeUI();
        }
        private void InitializeUI()
        {
            // Add a DataGridView to display scanned items
            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn();
            colItemName.HeaderText = "Item Name";
            DataGridViewTextBoxColumn colItemPrice = new DataGridViewTextBoxColumn();
            colItemPrice.HeaderText = "Item Price";

            dataGridView1.Columns.Add(colItemName);
            dataGridView1.Columns.Add(colItemPrice);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDatabaseConnection()
        {
            dbConnection = new OleDbConnection(connectionString);
        }

        private void LoadData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Items", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

            }
        }

        private void btnScanBarcode_Click_Click(object sender, EventArgs e)
        {
            // Use your phone to scan the barcode and get the result
            string scannedBarcode = ScanBarcode();

            // Check if a barcode was successfully scanned
            if (!string.IsNullOrEmpty(scannedBarcode))
            {
                // Set the scanned barcode in the txtBarcode TextBox
                txtBarcode.Text = scannedBarcode;

                // Now, you can load additional data based on the scanned barcode, if needed
                LoadDataForScannedBarcode(scannedBarcode);

                InsertSaleRecord(scannedBarcode);
            }
        }

        private void InsertSaleRecord(string scannedBarcode)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Retrieve data from the Items table
                string itemQuery = $"SELECT * FROM Items WHERE Barcode = '{scannedBarcode}'";
                using (OleDbCommand itemCmd = new OleDbCommand(itemQuery, connection))
                {
                    using (OleDbDataReader itemReader = itemCmd.ExecuteReader())
                    {
                        if (itemReader.Read())
                        {
                            // Barcode found in Items, get data
                            string itemName = itemReader["Name"].ToString();
                            string itemDescription = itemReader["Description"].ToString();
                            int itemPrice = Convert.ToInt32(itemReader["Price"]);
                            int originalStock = Convert.ToInt32(itemReader["Stock"]);
                            string expirationDate = itemReader["Expiration Date"].ToString();

                            // Check if the scanned barcode exists in the Sales table
                            string checkSaleQuery = $"SELECT * FROM Sales WHERE Barcode = '{scannedBarcode}'";
                            using (OleDbCommand checkSaleCmd = new OleDbCommand(checkSaleQuery, connection))
                            {
                                using (OleDbDataReader saleReader = checkSaleCmd.ExecuteReader())
                                {
                                    if (saleReader.Read())
                                    {
                                        // Barcode already exists in Sales, update the quantity and stock
                                        int currentQuantity = Convert.ToInt32(saleReader["Quantity"]);
                                        int currentStock = Convert.ToInt32(saleReader["Stock"]);

                                        int newQuantity = currentQuantity + 1;
                                        int newStock = currentStock - 1;

                                        string updateSaleQuery = $"UPDATE Sales SET Quantity = {newQuantity}, Stock = {newStock} WHERE Barcode = '{scannedBarcode}'";
                                        using (OleDbCommand updateSaleCmd = new OleDbCommand(updateSaleQuery, connection))
                                        {
                                            updateSaleCmd.ExecuteNonQuery();
                                            MessageBox.Show($"Sale recorded for barcode: {scannedBarcode}. New quantity: {newQuantity}, New stock: {newStock}");

                                            // Refresh the data and update the txtStockSales TextBox
                                            LoadDataForScannedBarcode(scannedBarcode);
                                            txtStockSales.Text = newStock.ToString();

                                            dataGridView1.Rows.Add(itemName, itemPrice);

                                            // Update the total amount
                                            totalAmount += itemPrice;
                                            lblTotalAmount.Text = $"Total Amount: {totalAmount}";
                                        }
                                    }
                                    else
                                    {
                                        // Barcode doesn't exist in Sales, insert a new record
                                        // Insert into Sales table with relevant data
                                        string insertSaleQuery = "INSERT INTO Sales ([Barcode], [Name], [Description], [Price], [Stock], [Quantity], [Expiration Date]) VALUES (?, ?, ?, ?, ?, 1, ?)";
                                        using (OleDbCommand insertSaleCmd = new OleDbCommand(insertSaleQuery, connection))
                                        {
                                            insertSaleCmd.Parameters.AddWithValue("Barcode", scannedBarcode);
                                            insertSaleCmd.Parameters.AddWithValue("Name", itemName);
                                            insertSaleCmd.Parameters.AddWithValue("Description", itemDescription);
                                            insertSaleCmd.Parameters.AddWithValue("Price", itemPrice);
                                            insertSaleCmd.Parameters.AddWithValue("Stock", originalStock - 1); // Deduct 1 from the original stock
                                            insertSaleCmd.Parameters.AddWithValue("Expiration Date", expirationDate);

                                            insertSaleCmd.ExecuteNonQuery();
                                            MessageBox.Show($"Sale recorded for barcode: {scannedBarcode}");

                                            // Refresh the data and update the txtStockSales TextBox
                                            LoadDataForScannedBarcode(scannedBarcode);
                                            txtStockSales.Text = (originalStock - 1).ToString();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Barcode not found in the Items table: {scannedBarcode}");
                        }
                    }
                }
            }
        }

        private string ScanBarcode()
        {
            var barcodeReader = new BarcodeReader();
            var openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                var barcodeBitmap = (Bitmap)Bitmap.FromFile(openDialog.FileName);
                var result = barcodeReader.Decode(barcodeBitmap);

                if (result != null)
                {
                    pictureBoxScannedBarcode.Image = barcodeBitmap;
                    return result.Text;
                }
                else
                {
                    MessageBox.Show("Barcode decoding failed.");
                }
            }

            return null;
        }

        private void LoadDataForScannedBarcode(string scannedBarcode)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Items WHERE Barcode = '{scannedBarcode}'";
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate textboxes with data from the database
                            txtName.Text = reader["Name"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            expirationDate.Text = reader["Expiration Date"].ToString();

                            // Convert numeric values to their respective types
                            if (int.TryParse(reader["Price"].ToString(), out int priceValue))
                            {
                                txtPrice.Text = priceValue.ToString();
                            }
                            else
                            {
                                // Handle the case where parsing fails (non-numeric input)
                                MessageBox.Show("Invalid numeric data in Price field.");
                            }

                            if (int.TryParse(reader["Stock"].ToString(), out int stockValue))
                            {
                                txtStockSales.Text = stockValue.ToString();
                            }
                            else
                            {
                                // Handle the case where parsing fails (non-numeric input)
                                MessageBox.Show("Invalid numeric data in Stock field.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found for the scanned barcode.");
                        }
                    }
                }

                // Fetch quantity and stock from the Sales table
                string salesQuery = $"SELECT * FROM Sales WHERE Barcode = '{scannedBarcode}'";
                using (OleDbCommand salesCmd = new OleDbCommand(salesQuery, connection))
                {
                    using (OleDbDataReader salesReader = salesCmd.ExecuteReader())
                    {
                        if (salesReader.Read())
                        {
                            // Display quantity and stock in the corresponding TextBoxes
                            if (int.TryParse(salesReader["Quantity"].ToString(), out int quantityValue))
                            {
                                txtQuantity.Text = quantityValue.ToString();
                            }
                            else
                            {
                                // Handle the case where parsing fails (non-numeric input)
                                MessageBox.Show("Invalid numeric data in Quantity field.");
                            }

                            if (int.TryParse(salesReader["Stock"].ToString(), out int stockValue))
                            {
                                txtStockSales.Text = stockValue.ToString();
                            }
                            else
                            {
                                // Handle the case where parsing fails (non-numeric input)
                                MessageBox.Show("Invalid numeric data in Stock field.");
                            }
                        }
                        else
                        {
                            // No sales record found, set quantity and stock TextBoxes to empty or default values
                            txtQuantity.Text = "0";
                            txtStockSales.Text = "0";
                        }
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxBarcode_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // Show Form2
            form3.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void newbutton_Click(object sender, EventArgs e)
        {

            // Clear other textboxes if needed
            txtBarcode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStockSales.Text = string.Empty;
            expirationDate.Text = string.Empty;
            dataGridView1.Rows.Clear();
            lblTotalAmount.Text = "Total Amount: 0";
            pictureBoxScannedBarcode.Image = null;
        }

        private void ClearPOS()
        {
            scannedItems.Clear();
            totalAmount = 0;

            dataGridView1.Rows.Clear();
            lblTotalAmount.Text = "Total Amount: 0";

            txtAmountPaid.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStockSales.Text = string.Empty;
            expirationDate.Text = string.Empty;

            pictureBoxScannedBarcode.Image = null;

        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtAmountPaid.Text, out int amountPaid))
            {
                int change = amountPaid - totalAmount;
                MessageBox.Show($"Change: {change}");

                ClearPOS();
            }
            else
            {
                MessageBox.Show("Invalid amount paid. Please enter cash amount.");
            }

        }
    }
}
