using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VoteMyMusic
{
    public partial class Register : Form
    {
        String connString = "server=localhost; port=3308;database=votemymusic;user=root;password=";

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Move(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmPassword = textBoxComPassword.Text.Trim();


            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            else if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            else
            {
                MySqlConnection myConnection = null;

                try
                {

                    myConnection = new MySqlConnection(connString);
                    myConnection.Open();


                    MySqlCommand myCommand = new MySqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandText = @"INSERT INTO users(username, password) VALUES (@username, @password)";


                    myCommand.Parameters.AddWithValue("@username", username);
                    myCommand.Parameters.AddWithValue("@password", password);


                    int result = myCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Registration successful!");


                        new FormLogin().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error during registration.");
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show($"MySQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                    if (myConnection != null && myConnection.State == System.Data.ConnectionState.Open)
                    {
                        myConnection.Close();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the login form: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void PanelShowPassword_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
