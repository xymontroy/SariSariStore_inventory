using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Event_inventory
{
    public partial class LoginForm : Form
    {
        private const string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\simon\OneDrive\Documents\Event.mdb";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = unamebox.Text;
            string password = passbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (IsLoginValid(username, password))
            {
                MessageBox.Show("Login successful!");
                Form3 form = new Form3();
                // Show Form2
                form.Show();

                // Optionally, you can hide Form1 if needed
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private bool IsLoginValid(string username, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users WHERE Username = @Username AND Password = @Password";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Register form3 = new Register();
            // Show Form2
            form3.Show();

            // Optionally, you can hide Form1 if needed
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
