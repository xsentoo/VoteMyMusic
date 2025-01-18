using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VoteMyMusic
{
    public partial class FormSavedMusic : Form
    {
        private string _username;
        private string _connectionString;

       
        private List<string> _votedTitles = new List<string>();

        
        public FormSavedMusic(string username, string connectionString)
        {
            InitializeComponent();
            _username = username;
            _connectionString = connectionString;
            LoadVotedMusic();
        }

        private void LoadVotedMusic()
        {
            MySqlConnection connection = null;
            _votedTitles.Clear(); 

            try
            {
               
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                
                string query = "SELECT Title FROM votes WHERE Username = @Username";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", _username);

                
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        string title = reader.GetString("Title");
                        _votedTitles.Add(title);
                    }
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

            
            UpdateVotedMusicDisplay();
        }

        
        private void UpdateVotedMusicDisplay()
        {
            listBoxVotedMusic.Items.Clear();

            if (_votedTitles.Count > 0)
            {
                foreach (string title in _votedTitles)
                {
                    listBoxVotedMusic.Items.Add(title); 
                }
            }
            else
            {
                listBoxVotedMusic.Items.Add("Aucun titre voté trouvé."); 
            }
        }

        
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            FormMusic formMusic = new FormMusic(_username, _connectionString);

           
            formMusic.Show();

           
            this.Hide();
        }

       
    }
}
