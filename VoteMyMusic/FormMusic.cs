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
        private string _username; // Champ pour stocker le nom d'utilisateur
        private string _connectionString = "server=localhost; port=3306; database=votemymusic; user=root; password="; // Chaîne de connexion

        // Liste pour stocker les titres de musique, les noms d'utilisateurs et les boutons de vote
        private List<(string Title, string Username, Button VoteButton)> _musicData = new List<(string, string, Button)>();

        // Déclaration du FlowLayoutPanel
        private FlowLayoutPanel musicPanel;

        // Constructeur modifié pour recevoir le nom d'utilisateur
        public FormMusic(string username, string connectionString)
        {
            InitializeComponent();
            _username = username; // Stocke le nom d'utilisateur
            _connectionString = connectionString; // Stocke la chaîne de connexion
        }

        // Fonction pour charger les titres de musique et leurs utilisateurs
        private void LoadMusicTitles()
        {
            MySqlConnection connection = null;

            // Vider la liste avant de charger de nouveaux titres et utilisateurs
            _musicData.Clear();

            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                // Requête SQL pour récupérer les titres et les noms d'utilisateurs
                string query = "SELECT Title, Username, Link FROM Musics"; // Ajout de la colonne Link pour chaque musique

                MySqlCommand command = new MySqlCommand(query, connection);

                // Exécution de la requête
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Ajouter chaque titre, nom d'utilisateur et bouton de vote à la liste
                    while (reader.Read())
                    {
                        string title = reader.GetString("Title");
                        string username = reader.GetString("Username");
                        string link = reader.IsDBNull(reader.GetOrdinal("Link")) ? "" : reader.GetString("Link");

                        // Créer un bouton de vote pour chaque titre
                        Button voteButton = new Button
                        {
                            Text = "Voter",
                            Tag = title // Utiliser le titre comme identifiant unique
                        };
                        voteButton.Click += VoteButton_Click; // Ajouter un gestionnaire d'événements pour le clic

                        // Ajouter les données à la liste
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            // Forcer le redessin du panel5 après avoir chargé les titres
            panel5.Invalidate();
        }

        // Fonction pour afficher les titres de musique et leurs utilisateurs dans le panel5
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            // Vérifiez si des données ont été récupérées
            if (_musicData.Count > 0)
            {
                int yPosition = 10; // Position verticale de départ

                foreach (var (title, username, voteButton) in _musicData)
                {
                    // Récupérer le nombre de votes pour chaque titre
                    int voteCount = GetVoteCount(title);

                    // Récupérer le lien associé au titre depuis la base de données
                    string link = GetMusicLink(title);

                    // Dessiner chaque titre, le nom de l'utilisateur, le nombre de votes et le lien dans panel5
                    string displayText = $"{title} (Ajouté par: {username}) - {voteCount} votes";
                    e.Graphics.DrawString(displayText, new Font("Arial", 10), Brushes.Black, new PointF(10, yPosition));

                    // Afficher le lien sous forme de texte cliquable
                    if (!string.IsNullOrEmpty(link))
                    {
                        e.Graphics.DrawString("Lien: " + link, new Font("Arial", 10, FontStyle.Underline), Brushes.Blue, new PointF(10, yPosition + 20));
                    }

                    // Placer les boutons de vote à côté du titre
                    voteButton.Location = new Point(300, yPosition); // Ajustez la position du bouton
                    panel5.Controls.Add(voteButton); // Ajouter le bouton au panel

                    yPosition += 40; // Décaler la position verticale pour chaque titre et son bouton
                }
            }
            else
            {
                e.Graphics.DrawString("Aucun titre disponible.", new Font("Arial", 10), Brushes.Red, new PointF(10, 10));
            }
        }

        // Méthode pour obtenir le nombre de votes pour un titre donné
        private int GetVoteCount(string title)
        {
            MySqlConnection connection = null;
            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                // Requête SQL pour récupérer le nombre de votes pour le titre
                string query = "SELECT COUNT(*) FROM Votes WHERE Title = @Title";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);

                // Retourner le nombre de votes
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Méthode pour obtenir le lien associé à un titre donné depuis la base de données
        private string GetMusicLink(string title)
        {
            MySqlConnection connection = null;
            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                // Requête SQL pour récupérer le lien associé à ce titre
                string query = "SELECT Link FROM Musics WHERE Title = @Title";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);

                // Retourner le lien trouvé, ou une chaîne vide si aucun lien n'est associé
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Action au clic sur le bouton de vote
        private void VoteButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string title = (string)clickedButton.Tag; // Récupérer le titre du bouton

            // Vérifier si l'utilisateur a déjà voté pour ce titre
            if (UserHasVoted(title))
            {
                MessageBox.Show("Vous avez déjà voté pour ce titre.");
                return;
            }

            // Ajouter un vote pour ce titre
            AddVote(title);

            // Désactiver le bouton après le vote
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Ajouter un vote pour un titre
        private void AddVote(string title)
        {
            MySqlConnection connection = null;

            try
            {
                // Connexion à la base de données
                connection = new MySqlConnection(_connectionString);
                connection.Open();

                // Requête SQL pour insérer un vote dans la table Votes
                string query = "INSERT INTO Votes (Username, Title) VALUES (@Username, @Title)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", _username);
                command.Parameters.AddWithValue("@Title", title);

                // Exécution de la commande
                command.ExecuteNonQuery();

                // Mettre à jour le nombre de votes dans la base de données pour ce titre
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
                // Fermeture de la connexion
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Action au clic sur FormMusic (lors de son chargement)
        private void FormMusic_Load(object sender, EventArgs e)
        {
            // Affiche le nom d'utilisateur
            label1.Text = $"Bienvenue, {_username}!";

            // Charger les titres de musique et leurs utilisateurs lors du chargement du formulaire
            LoadMusicTitles();
        }

        // Action au clic sur label1
        private void label1_Click(object sender, EventArgs e)
        {
            // Code à exécuter lorsque le label est cliqué
            MessageBox.Show("Label clicked!");
        }

        // Action au clic sur le bouton Profile
        private void button1_Click(object sender, EventArgs e)
        {
            // Code pour gérer le clic sur le bouton "Profile"
            MessageBox.Show("Profile button clicked!");
        }

        // Action au clic sur le bouton Music save
        private void button3_Click(object sender, EventArgs e)
        {
            FormSavedMusic formSavedMusic = new FormSavedMusic(_username, _connectionString);

            // Affichez FormSavedMusic
            formSavedMusic.Show();

            // (Optionnel) Cachez le formulaire actuel si vous voulez qu'il ne soit plus visible
            this.Hide();
        }

        // Action au clic sur le bouton Add Music
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Créer une instance de FormAddMusic
            FormAddMusic formAddMusic = new FormAddMusic(_username, _connectionString);

            // Afficher FormAddMusic
            formAddMusic.Show();

            // Cacher le formulaire actuel (si vous voulez le faire disparaître)
            this.Hide();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();

            // Afficher le formulaire de connexion
            loginForm.Show();

            // Fermer le formulaire actuel (FormMusic)
            this.Close();
        }
    }
}
