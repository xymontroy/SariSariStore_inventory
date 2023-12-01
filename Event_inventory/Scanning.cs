using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Event_inventory
{
    public partial class Scanning : Form
    {
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private bool messageBoxShown = false;

        public Scanning()
        {
            InitializeComponent();
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in _videoDevices)
            {
                cboCamera.Items.Add(device.Name);
            }

            if (cboCamera.Items.Count > 0)
            {
                cboCamera.SelectedIndex = 0;
            }

            // Set PictureBox size mode to Zoom
            picCamera.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnStartScanning_Click(object sender, EventArgs e)
        {
            try
            {
                if (_videoDevices.Count > 0)
                {
                    // Dispose of the existing video source if it's running
                    if (_videoSource != null && _videoSource.IsRunning)
                    {
                        _videoSource.SignalToStop();
                        _videoSource.WaitForStop();
                        _videoSource = null;
                    }

                    // Start a new video source
                    _videoSource = new VideoCaptureDevice(_videoDevices[cboCamera.SelectedIndex].MonikerString);
                    _videoSource.NewFrame += OnNewFrame;
                    _videoSource.Start();
                }
                else
                {
                    MessageBox.Show("No video devices found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // Check if the form is disposed or the control's handle is not created
                if (IsDisposed || !picCamera.IsHandleCreated)
                {
                    return;
                }

                if (picCamera.InvokeRequired)
                {
                    picCamera.Invoke(new Action(() =>
                    {
                        if (!IsDisposed && picCamera.IsHandleCreated)
                        {
                            picCamera.Image = (Bitmap)eventArgs.Frame.Clone();
                            picCamera.Refresh();

                            // Use ZXing to decode the barcode from the camera feed
                            BarcodeReader barcodeReader = new BarcodeReader();
                            Result result = barcodeReader.Decode((Bitmap)picCamera.Image);

                            // Handle the scanned barcode result
                            if (result != null)
                            {
                                txtScannedBarcode.Text = result.Text;

                                // Lookup product information in the database
                                ProductInfo productInfo = LookupProductInDatabase(result.Text);
                                if (productInfo != null && !messageBoxShown)
                                {
                                    DisplayProductInfo(productInfo);
                                    messageBoxShown = true;  // Set the flag to true
                                }
                                else if (productInfo == null)
                                {
                                    ClearProductInfo();
                                    messageBoxShown = false;  // Reset the flag when no product is found
                                }
                            }
                            else
                            {
                                ClearProductInfo();
                                messageBoxShown = false;  // Reset the flag when no barcode is detected
                            }
                        }
                    }));
                }
                else
                {
                    if (!IsDisposed && picCamera.IsHandleCreated)
                    {
                        picCamera.Image = (Bitmap)eventArgs.Frame.Clone();
                        picCamera.Refresh();

                        // Use ZXing to decode the barcode from the camera feed
                        BarcodeReader barcodeReader = new BarcodeReader();
                        Result result = barcodeReader.Decode((Bitmap)picCamera.Image);

                        // Handle the scanned barcode result
                        if (result != null)
                        {
                            txtScannedBarcode.Text = result.Text;

                            // Lookup product information in the database
                            ProductInfo productInfo = LookupProductInDatabase(result.Text);
                            if (productInfo != null && !messageBoxShown)
                            {
                                DisplayProductInfo(productInfo);
                                messageBoxShown = true;  // Set the flag to true
                            }
                            else if (productInfo == null)
                            {
                                ClearProductInfo();
                                messageBoxShown = false;  // Reset the flag when no product is found
                            }
                        }
                        else
                        {
                            ClearProductInfo();
                            messageBoxShown = false;  // Reset the flag when no barcode is detected
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying camera feed: {ex.Message}");
            }
        }

        private ProductInfo LookupProductInDatabase(string barcode)
        {
            // Example connection string; replace with your actual connection string
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\simon\OneDrive\Documents\Event.mdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand("SELECT Name, Price FROM Items WHERE Barcode = @Barcode", connection))
                {
                    command.Parameters.AddWithValue("@Barcode", barcode);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ProductInfo
                            {
                                ProductName = reader["Name"].ToString(),
                                Price = decimal.Parse(reader["Price"].ToString())
                            };
                        }
                    }
                }
            }

            return null; // Product not found in the database
        }

        private void DisplayProductInfo(ProductInfo productInfo)
        {
            DialogResult result = MessageBox.Show($"Name: {productInfo.ProductName}\nPrice: {productInfo.Price:C}", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                ClearProductInfo();
                messageBoxShown = false;
            }
        }

        private void ClearProductInfo()
        {
            txtScannedBarcode.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // Show Form2
            form3.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }
    }

    public class ProductInfo
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
