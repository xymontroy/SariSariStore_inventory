using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;


namespace Event_inventory
{
    public partial class SalesStatistics : Form
    {
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\simon\OneDrive\Documents\Event.mdb";
        public SalesStatistics()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
         
        }

        private void InitializeChart()
        {    
            // Assuming chart1 is the name of your Chart control
            chart1.Series.Add("Quantity");
            chart1.Series.Add("Price");

            // Fetch data from the database
            DataTable salesData = GetDataFromDatabase();

            // Bind the data to the chart
            BindDataToChart(salesData);

            // Configure chart properties
            chart1.Titles.Add("Sales Chart");
            chart1.ChartAreas[0].AxisX.Title = "Product Name";
            chart1.ChartAreas[0].AxisY.Title = "Quantity Sold";
            chart1.ChartAreas[0].AxisY2.Title = "Price";

            // Set the second Y-axis to be displayed
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart1.Series["Price"].YAxisType = AxisType.Secondary;

            // Customize axis labels as needed
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; // Format for quantity as a whole number
            chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "C2"; // Format for price as currency
        }

        private DataTable GetDataFromDatabase()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Query the database to get sales data
                string query = "SELECT Name, Quantity, Price FROM Sales";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable salesData = new DataTable();
                adapter.Fill(salesData);

                return salesData;
            }
        }

        private void BindDataToChart(DataTable salesData)
        {
            foreach (DataRow row in salesData.Rows)
            {
                // Add data points to the series
                string productName = row["Name"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["Price"]);

                // Assuming your price and quantity are in the same scale, adjust the values as needed
                chart1.Series["Quantity"].Points.AddXY(productName, quantity);
                chart1.Series["Price"].Points.AddXY(productName, price);
            }
        }

        private void SalesStatistics_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();

            // Show Form2
            form.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }
    }
}
