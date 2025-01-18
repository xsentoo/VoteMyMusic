using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VoteMyMusic
{
    public partial class FormAddMusic : Form
    {
        private string _connectionString;
        private string _username;
        public FormAddMusic(string username, string connectionString)
        {
            InitializeComponent();
            _username = username; 
            _connectionString = connectionString;
        }

        private void textBoxMusicTitle_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxLink_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            string title = textBoxMusicTitle.Text;
            string link = textBoxLink.Text;

           
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(link))
            {
                try
                {
                   
                    using (MySqlConnection connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();

                        
                        string query = "INSERT INTO Musics (Title, Link, Username) VALUES (@Title, @Link, @Username)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                           
                            command.Parameters.AddWithValue("@Title", title);
                            command.Parameters.AddWithValue("@Link", link);
                            command.Parameters.AddWithValue("@Username", _username);

                            
                            command.ExecuteNonQuery();
                        }
                    }

                   
                    MessageBox.Show("Musique ajoutée avec succès !");

                   
                    FormMusic formMusic = new FormMusic(_username, _connectionString);

                   
                    formMusic.Show();

                   
                    this.Close();
                }
                catch (MySqlException ex)
                {
                   
                    MessageBox.Show($"Erreur de base de données: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show($"Une erreur inattendue est survenue: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }

        private void FormAddMusic_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMusic musicForm = new FormMusic(_username, _connectionString);

            // Affichez la nouvelle page
            musicForm.Show();

            // Fermez ou masquez la page actuelle si nécessaire
            this.Hide(); 
        }
    }
}
