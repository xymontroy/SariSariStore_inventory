using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Event_inventory
{
    public partial class Form3 : Form
    {
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\simon\OneDrive\Documents\Event.mdb";
        public Form3()
        {
            InitializeComponent();
            timer1.Start(); // Start the timer when the form loads
            UpdateClock(); // Initial clock update
            ConfigureChart();
            PopulatePieChartData();
            PopulateBarChartData();
            
        }

        private void ConfigureChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("ExpiredProducts");
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            chart1.Series[0].IsValueShownAsLabel = true; // Show data labels
            chart1.Series[0].LabelFormat = "{0}%"; // Format labels as percentages

            
           
        }

        private void PopulatePieChartData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string queryExpired = "SELECT COUNT(*) AS ExpiredCount FROM items WHERE [Expiration Date] < Date()";
                string queryTotal = "SELECT COUNT(*) AS TotalCount FROM items";

                using (OleDbCommand commandExpired = new OleDbCommand(queryExpired, connection))
                using (OleDbCommand commandTotal = new OleDbCommand(queryTotal, connection))
                {
                    int expiredCount = (int)commandExpired.ExecuteScalar();
                    int totalCount = (int)commandTotal.ExecuteScalar();

                    if (totalCount > 0)
                    {
                        double percentageExpired = (double)expiredCount / totalCount * 100;

                        chart1.Series["ExpiredProducts"].Points.AddXY("Expired", percentageExpired);
                        chart1.Series["ExpiredProducts"].Points.AddXY("Not Expired", 100 - percentageExpired);
                    }
                }
            }
        }

        private void PopulateBarChartData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Items.Stock, " +
                               "SUM(Items.Stock) AS TotalStock, " +
                               "SUM(IIF(Sales.Stock IS NULL, Items.Stock, Sales.Stock)) AS RemainingStock " +
                               "FROM Items " +
                               "LEFT JOIN Sales ON Items.ID = Sales.ID " +
                               "GROUP BY Items.Stock";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Assuming chart2 is the name of your bar chart control
                        chart2.Series.Clear();
                        chart2.ChartAreas[0].AxisX.Title = "Product Stock";
                        chart2.ChartAreas[0].AxisY.Title = "Number of Stocks";
                        chart2.ChartAreas[0].AxisX.Interval = 1;

                        chart2.Series.Add("TotalStock");
                        chart2.Series.Add("RemainingStock");

                        chart2.Series["TotalStock"].ChartType = SeriesChartType.Bar;
                        chart2.Series["RemainingStock"].ChartType = SeriesChartType.Bar;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Adjust the column names
                            string stockValue = row["Stock"].ToString(); // Adjust the column name
                            int totalStock = Convert.ToInt32(row["TotalStock"]);
                            int remainingStock = Convert.ToInt32(row["RemainingStock"]);

                            // Add data points for total and remaining stock
                            chart2.Series["TotalStock"].Points.AddXY(stockValue, totalStock);
                            chart2.Series["RemainingStock"].Points.AddXY(stockValue, remainingStock);
                        }
                    }
                }
            }
        }









        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form2 = new LoginForm();

            // Show Form2
            form2.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Show Form2
            form2.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void scanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scanning form = new Scanning();

            // Show Form2
            form.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            // Show Form2
            form.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void salesStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesStatistics form = new SalesStatistics();

            // Show Form2
            form.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            labelClock.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm: tt");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
