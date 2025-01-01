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

        // Liste pour stocker les titres votés
        private List<string> _votedTitles = new List<string>();

        // Constructeur pour FormSavedMusic
        public FormSavedMusic(string username, string connectionString)
        {
            InitializeComponent();
            _username = username;
            _connectionString = connectionString;
            LoadVotedMusic(); // Charger les titres votés
        }

        // Fonction pour charger les titres votés par l'utilisateur depuis la table `votes`
        private void LoadVotedMusic()
        {
            MySqlConnection connection = null;
            _votedTitles.Clear(); // Vider la liste avant de charger les nouvelles données

            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                // Requête SQL pour récupérer les titres votés par l'utilisateur
                string query = "SELECT Title FROM votes WHERE Username = @Username";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", _username);

                // Exécution de la requête et récupération des données
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Ajouter chaque titre voté à la liste
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            // Mettre à jour l'affichage des titres votés dans un contrôle (ListBox)
            UpdateVotedMusicDisplay();
        }

        // Fonction pour mettre à jour l'affichage des titres votés dans un ListBox
        private void UpdateVotedMusicDisplay()
        {
            listBoxVotedMusic.Items.Clear(); // Vider le ListBox avant de rajouter les titres

            if (_votedTitles.Count > 0)
            {
                foreach (string title in _votedTitles)
                {
                    listBoxVotedMusic.Items.Add(title); // Ajouter chaque titre voté à la liste
                }
            }
            else
            {
                listBoxVotedMusic.Items.Add("Aucun titre voté trouvé."); // Message si aucun titre n'a été voté
            }
        }

        // Action au clic sur le bouton Back
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            FormMusic formMusic = new FormMusic(_username, _connectionString);

            // Afficher FormMusic
            formMusic.Show();

            // (Optionnel) Cacher le formulaire actuel si vous voulez qu'il ne soit plus visible
            this.Hide();
        }

        // Autres méthodes et gestionnaires d'événements pour FormSavedMusic...
    }
}
