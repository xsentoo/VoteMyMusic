using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace VoteMyMusic
{
    public partial class FormLogin : Form
    {
        // Chaîne de connexion à la base de données
        private string connString = "server=localhost; port=3306; database=votemymusic; user=root; password=";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Gestionnaire d'événement laissé vide (aucune action nécessaire pour le moment)
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Récupération des données utilisateur depuis les champs TextBox
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // Vérification des champs vides
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection connection = null;

            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(connString);
                connection.Open();

                // Requête SQL pour vérifier si l'utilisateur existe
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Paramètres sécurisés pour éviter les injections SQL
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // Exécution de la requête et lecture des résultats
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // Si l'utilisateur existe
                {
                    MessageBox.Show("Login successful! Welcome to Vote My Music.", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ouvrir FormMusic après connexion réussie
                    FormMusic formMusic = new FormMusic(); // Passer le nom d'utilisateur ou toute autre info nécessaire
                    formMusic.Show();
                    this.Hide(); // Cacher le formulaire de login
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void linkLabelForRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Ouvrir le formulaire d'inscription et masquer le formulaire de connexion
            new Register().Show();
            this.Hide();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Code à exécuter au chargement du formulaire (si nécessaire)
        }
    }
}
