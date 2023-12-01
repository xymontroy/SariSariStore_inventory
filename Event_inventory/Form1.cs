using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ZXing;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using System.Net.Http;




namespace Event_inventory
{
    public partial class Form1 : Form
    {
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\simon\OneDrive\Documents\Event.mdb";
        private OleDbConnection dbConnection;


        public Form1()
        {
            InitializeComponent();
            LoadData();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            dbConnection = new OleDbConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eventDataSet12.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter11.Fill(this.eventDataSet12.Items);
            dataGridViewItems.SelectionChanged += DataGridViewItems_SelectionChanged;

        }

        private void LoadData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Items", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewItems.DataSource = dataTable;

               
            }
        }

        private void DataGridViewItems_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridViewItems.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewItems.SelectedRows[0];

                // Get the column indices of the columns you want to retrieve
                int nameColumnIndex = dataGridViewItems.Columns["nameDataGridViewTextBoxColumn"]?.Index ?? -1;
                int descriptionColumnIndex = dataGridViewItems.Columns["descriptionDataGridViewTextBoxColumn"]?.Index ?? -1;
                int barcodeColumnIndex = dataGridViewItems.Columns["barcodeDataGridViewTextBoxColumn"]?.Index ?? -1;
                int expirationDateColumnIndex = dataGridViewItems.Columns["expirationDateDataGridViewTextBoxColumn"]?.Index ?? -1;
                int priceColumnIndex = dataGridViewItems.Columns["priceDataGridViewTextBoxColumn"]?.Index ?? -1;
                int stockColumnIndex = dataGridViewItems.Columns["stockDataGridViewTextBoxColumn"]?.Index ?? -1;

                // Check if all columns are found
                if (nameColumnIndex != -1 && descriptionColumnIndex != -1 && barcodeColumnIndex != -1 &&
                    expirationDateColumnIndex != -1 && priceColumnIndex != -1 && stockColumnIndex != -1)
                {
                    // Get the values in the selected row
                    string name = selectedRow.Cells[nameColumnIndex].Value?.ToString();
                    string description = selectedRow.Cells[descriptionColumnIndex].Value?.ToString();
                    string barcode = selectedRow.Cells[barcodeColumnIndex].Value?.ToString();
                    string expirationdate = selectedRow.Cells[expirationDateColumnIndex].Value?.ToString();
                    string price = selectedRow.Cells[priceColumnIndex].Value?.ToString();
                    string stock = selectedRow.Cells[stockColumnIndex].Value?.ToString();

                    // Populate textboxes with data from the selected row
                    txtName.Text = name;
                    txtDescription.Text = description;
                    txtBarcode.Text = barcode;
                    if (DateTime.TryParse(expirationdate, out DateTime parsedExpirationDate))
                    {
                        expirationDate.Value = parsedExpirationDate;
                    }

                    txtPrice.Text = price;
                    txtStock.Text = stock;
                }
            }
        }

        private void DisplayExpiredItems()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Query the database to select only items that have expired
                string query = "SELECT * FROM Items WHERE [Expiration Date] <= Date()";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable expiredItemsTable = new DataTable();
                adapter.Fill(expiredItemsTable);

                // Display the expired items in a MessageBox
                if (expiredItemsTable.Rows.Count > 0)
                {
                    StringBuilder message = new StringBuilder("Expired Items:\n\n");

                    foreach (DataRow row in expiredItemsTable.Rows)
                    {
                        // Customize the display format based on your requirements
                        message.AppendLine($"Items: {row["Name"]}, Expiration Date: {row["Expiration Date"]}");
                    }

                    MessageBox.Show(message.ToString(), "Expiration Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No expired items found.", "Expiration Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string barcodeValue = txtBarcode.Text;

            if (string.IsNullOrWhiteSpace(barcodeValue))
            {
                MessageBox.Show("Please enter a valid barcode value.");
                return;
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Generate barcode image
                Bitmap barcodeBitmap = GenerateBarcode(barcodeValue);
                // Fetch product information asynchronously
               


                // Save barcode image to a file or display it in a PictureBox
                // In this example, we'll display it in a PictureBox named pictureBoxBarcode
                pictureBoxBarcode.Image = barcodeBitmap;

                string query = "INSERT INTO Items ([Name], [Description], [Barcode], [Expiration Date], [Price], [Stock]) VALUES (?, ?, ?, ?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("Name", txtName.Text);
                    cmd.Parameters.AddWithValue("Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("Barcode", barcodeValue);
                    cmd.Parameters.Add("Expiration Date", OleDbType.Date).Value = DateTime.Parse(expirationDate.Text);


                    // Convert numeric values to their respective types
                    if (int.TryParse(txtPrice.Text, out int priceValue))
                    {
                        cmd.Parameters.AddWithValue("Price", priceValue);
                    }
                    else
                    {
                        // Handle the case where parsing fails (non-numeric input)
                        MessageBox.Show("Invalid numeric input in Price field.");
                        return;
                    }

                    if (int.TryParse(txtStock.Text, out int stackValue))
                    {
                        cmd.Parameters.AddWithValue("Stock", stackValue);
                    }
                    else
                    {
                        // Handle the case where parsing fails (non-numeric input)
                        MessageBox.Show("Invalid numeric input in Stock field.");
                        return;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            LoadData();
            ClearTextBoxes();

        }

        private Bitmap GenerateBarcode(string value)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_39;
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 250,
                Height = 85
            };

            return new Bitmap(barcodeWriter.Write(value));
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
                    return result.Text;
                }
                else
                {
                    MessageBox.Show("Barcode decoding failed.");
                }
            }

            return null;
        }

        private void b_Click(object sender, EventArgs e)
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
            }
        }

        private void buttonGenerateBarcode_Click(object sender, EventArgs e)
        {
            // Generate a new barcode
            string generatedBarcode = GenerateRandomBarcode();

            // Display the generated barcode in txtBarcode
            txtBarcode.Text = generatedBarcode;

            // Generate barcode image
            Bitmap barcodeBitmap = GenerateBarcode(generatedBarcode);

            // Set the PictureBoxSizeMode to Zoom
            pictureBoxBarcode.SizeMode = PictureBoxSizeMode.Zoom;

            // Set the generated barcode image to the PictureBox
            pictureBoxBarcode.Image = barcodeBitmap;


        }

        private string GenerateRandomBarcode()
        {
            // Generate a random barcode for testing purposes
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // You can customize the range as needed


        }

        private void LoadDataForScannedBarcode(string scannedBarcode)
        {
            // Assuming you have a method to load data based on the barcode
            // Modify this method according to your database structure and requirements

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

                            if (int.TryParse(reader["Stock"].ToString(), out int stackValue))
                            {
                                txtStock.Text = stackValue.ToString();
                            }
                            else
                            {
                                // Handle the case where parsing fails (non-numeric input)
                                MessageBox.Show("Invalid numeric data in Stack field.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found for the scanned barcode.");
                        }
                        
                    }
                }
            }
        }
        private void SaveBarcodeImage(Bitmap barcodeBitmap, string barcodeValue)
        {
            // Specify the path where you want to save the barcode images
            string savePath = @"C:\Users\simon\OneDrive\Documents\GeneratedBarcodes\";

            // Check if the directory exists, and create it if not
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            // Generate a unique file name using a timestamp
            string fileName = $"Barcode_{barcodeValue}_{DateTime.Now:yyyyMMddHHmmssfff}.png";

            // Combine the path and file name
            string filePath = Path.Combine(savePath, fileName);

            // Convert System.Drawing.Bitmap to byte array
            using (MemoryStream memoryStream = new MemoryStream())
            {
                barcodeBitmap.Save(memoryStream, ImageFormat.Png);
                byte[] byteArray = memoryStream.ToArray();

                // Convert byte array to SixLabors.ImageSharp.Image
                using (var image = SixLabors.ImageSharp.Image.Load(byteArray))
                {
                    // Save the barcode image to the specified file path using PngEncoder
                    image.Save(filePath, new PngEncoder());

                    MessageBox.Show($"Barcode image saved to: {filePath}");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBoxBarcode.Image != null)
            {
                // Get the generated barcode value from txtBarcode
                string barcodeValue = txtBarcode.Text;

                // Get the currently displayed barcode image from pictureBoxGeneratedBarcode
                Bitmap barcodeBitmap = (Bitmap)pictureBoxBarcode.Image;

                // Save the barcode image to a file
                SaveBarcodeImage(barcodeBitmap, barcodeValue);
            }
            else
            {
                MessageBox.Show("No barcode image to save. Generate a barcode first.");
            }

        }

        private void ClearTextBoxes()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            expirationDate.Text = string.Empty;
        }

        private void ClearAllTextboxesButton_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            expirationDate.Text = string.Empty;
            pictureBoxBarcode.Image = null;
        }

        private void pictureBoxBarcode_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // Show Form2
            form3.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCheckExpiredItems_Click(object sender, EventArgs e)
        {
            DisplayExpiredItems();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridViewItems.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewItems.SelectedRows[0];

                // Get the column index of the "Barcode" column
                int barcodeColumnIndex = dataGridViewItems.Columns["barcodeDataGridViewTextBoxColumn"]?.Index ?? -1;

                // Get the column index of the "Name" column
                int nameColumnIndex = dataGridViewItems.Columns["nameDataGridViewTextBoxColumn"]?.Index ?? -1;

                // Check if both Barcode and Name columns are found
                if (barcodeColumnIndex != -1 && nameColumnIndex != -1)
                {
                    // Get the values in the "Barcode" and "Name" columns of the selected row
                    string selectedBarcode = selectedRow.Cells[barcodeColumnIndex].Value?.ToString();
                    string selectedName = selectedRow.Cells[nameColumnIndex].Value?.ToString();

                    if (selectedBarcode != null && selectedName != null)
                    {
                        // Display a confirmation dialog
                        DialogResult result = MessageBox.Show($"Are you sure you want to delete '{selectedName}' with barcode '{selectedBarcode}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // If the user confirms deletion, proceed with deletion
                        if (result == DialogResult.Yes)
                        {
                            // Delete the item from the database
                            DeleteItem(selectedBarcode);

                            // Clear the textboxes and reload the data
                            ClearTextBoxes();
                            LoadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The 'Barcode' or 'Name' value in the selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The 'Barcode' or 'Name' column was not found in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteItem(string barcode)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Delete the item with the specified barcode
                string query = "DELETE FROM Items WHERE [Barcode] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("Barcode", barcode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridViewItems.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewItems.SelectedRows[0];

                // Get the column indices of the columns you want to retrieve
                int barcodeColumnIndex = dataGridViewItems.Columns["barcodeDataGridViewTextBoxColumn"]?.Index ?? -1;

                // Check if the Barcode column is found
                if (barcodeColumnIndex != -1)
                {
                    // Get the value in the "Barcode" column of the selected row
                    string selectedBarcode = selectedRow.Cells[barcodeColumnIndex].Value?.ToString();

                    if (selectedBarcode != null)
                    {
                        // Get the updated values from the textboxes
                        string newName = txtName.Text;
                        string newDescription = txtDescription.Text;
                        DateTime newExpirationDate = expirationDate.Value;
                        int newPrice = int.Parse(txtPrice.Text); // You may want to handle parsing errors
                        int newStock = int.Parse(txtStock.Text); // You may want to handle parsing errors

                        // Call the UpdateItem method to update the item in the database
                        UpdateItem(selectedBarcode, newName, newDescription, newExpirationDate, newPrice, newStock);

                        MessageBox.Show("Product Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        // Clear the textboxes and reload the data
                        ClearTextBoxes();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("The 'Barcode' value in the selected row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The 'Barcode' column was not found in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateItem(string barcode, string newName, string newDescription, DateTime newExpirationDate, int newPrice, int newStock)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Update the item with the specified barcode
                string query = "UPDATE Items SET [Name] = ?, [Description] = ?, [Expiration Date] = ?, [Price] = ?, [Stock] = ? WHERE [Barcode] = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("Name", newName);
                    cmd.Parameters.AddWithValue("Description", newDescription);
                    cmd.Parameters.Add("Expiration Date", OleDbType.Date).Value = newExpirationDate;
                    cmd.Parameters.AddWithValue("Price", newPrice);
                    cmd.Parameters.AddWithValue("Stock", newStock);
                    cmd.Parameters.AddWithValue("Barcode", barcode);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
