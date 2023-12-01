using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_inventory
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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
    }
}
