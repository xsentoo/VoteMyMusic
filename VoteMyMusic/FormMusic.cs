using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VoteMyMusic
{
    public partial class FormMusic : Form
    {
        private string _username;
        private string _connectionString = "server=localhost; port=3308; database=votemymusic; user=root; password="; 

        // Liste pour stocker les titres de musique, les noms d'utilisateurs et les boutons de vote
        private List<(string Title, string Username, Button VoteButton)> _musicData = new List<(string, string, Button)>();

       
        private FlowLayoutPanel musicPanel;

       
        public FormMusic(string username, string connectionString)
        {
            InitializeComponent();
            _username = username; 
            _connectionString = connectionString;
        }

        
        private void LoadMusicTitles()
        {
            MySqlConnection connection = null;

           
            _musicData.Clear();

            try
            {
                
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                
                string query = "SELECT Title, Username, Link FROM Musics"; 

                MySqlCommand command = new MySqlCommand(query, connection);

               
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        string title = reader.GetString("Title");
                        string username = reader.GetString("Username");
                        string link = reader.IsDBNull(reader.GetOrdinal("Link")) ? "" : reader.GetString("Link");

                        
                        Button voteButton = new Button
                        {
                            Text = "Voter",
                            Tag = title 
                        };
                        voteButton.Click += VoteButton_Click;

                        
                        _musicData.Add((title, username, voteButton));
                    }
                }
                else
                {
                    MessageBox.Show("Aucune musique trouvée dans la base de données.");
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            
            panel5.Invalidate();
        }

       
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
            if (_musicData.Count > 0)
            {
                int yPosition = 10; 

                foreach (var (title, username, voteButton) in _musicData)
                {
                   
                    int voteCount = GetVoteCount(title);

                    
                    string link = GetMusicLink(title);

                    
                    string displayText = $"{title} (Ajouté par: {username}) - {voteCount} votes";
                    e.Graphics.DrawString(displayText, new Font("Arial", 10), Brushes.Black, new PointF(10, yPosition));

                    
                    if (!string.IsNullOrEmpty(link))
                    {
                        e.Graphics.DrawString("Lien: " + link, new Font("Arial", 10, FontStyle.Underline), Brushes.Blue, new PointF(10, yPosition + 20));
                    }

                   
                    voteButton.Location = new Point(300, yPosition); 
                    panel5.Controls.Add(voteButton);

                    yPosition += 40;
                }
            }
            else
            {
                e.Graphics.DrawString("Aucun titre disponible.", new Font("Arial", 10), Brushes.Red, new PointF(10, 10));
            }
        }

      
        private int GetVoteCount(string title)
        {
            MySqlConnection connection = null;
            try
            {
                
                connection = new MySqlConnection(_connectionString);
                connection.Open();

               
                string query = "SELECT COUNT(*) FROM Votes WHERE Title = @Title";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);

                
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
               
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        
        private string GetMusicLink(string title)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                
                string query = "SELECT Link FROM Musics WHERE Title = @Title";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);

                
                object result = command.ExecuteScalar();
                return result != DBNull.Value ? result.ToString() : string.Empty;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
               
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

       
        private void VoteButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string title = (string)clickedButton.Tag; 

            // Vérifier si l'utilisateur a déjà voté pour ce titre
            if (UserHasVoted(title))
            {
                MessageBox.Show("Vous avez déjà voté pour ce titre.");
                return;
            }

            
            AddVote(title);

            
            clickedButton.Enabled = false;

            MessageBox.Show("Vote ajouté avec succès!");
        }

        // Vérifier si l'utilisateur a déjà voté pour ce titre
        private bool UserHasVoted(string title)
        {
            MySqlConnection connection = null;
            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                // Requête SQL pour vérifier si l'utilisateur a déjà voté pour ce titre
                string query = "SELECT COUNT(*) FROM Votes WHERE Username = @Username AND Title = @Title";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", _username);
                command.Parameters.AddWithValue("@Title", title);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0; // Retourne vrai si l'utilisateur a déjà voté
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

       
        private void AddVote(string title)
        {
            MySqlConnection connection = null;

            try
            {
                
                connection = new MySqlConnection(_connectionString);
                connection.Open();

               
                string query = "INSERT INTO Votes (Username, Title) VALUES (@Username, @Title)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", _username);
                command.Parameters.AddWithValue("@Title", title);

               
                command.ExecuteNonQuery();

               
                string updateQuery = "UPDATE Musics SET Votes = Votes + 1 WHERE Title = @Title";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@Title", title);

                updateCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

       
        private void FormMusic_Load(object sender, EventArgs e)
        {
            
            label1.Text = $"Bienvenue, {_username}!";

            LoadMusicTitles();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Label clicked!");
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            FormProfile formProfile = new FormProfile(_username, _connectionString);

            formProfile.Show();

            
            this.Hide();

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            FormSavedMusic formSavedMusic = new FormSavedMusic(_username, _connectionString);

           
            formSavedMusic.Show();

            
            this.Hide();
        }

       
        private void button2_Click_1(object sender, EventArgs e)
        {
            
            FormAddMusic formAddMusic = new FormAddMusic(_username, _connectionString);

            
            formAddMusic.Show();

           
            this.Hide();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();

           
            loginForm.Show();

            
            this.Close();
        }
    }
}
