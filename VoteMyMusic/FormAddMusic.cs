using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VoteMyMusic
{
    public partial class FormAddMusic : Form
    {
        private string _connectionString;
        private string _username; // Variable pour stocker le nom d'utilisateur

        // Constructeur qui accepte le nom d'utilisateur et la chaîne de connexion
        public FormAddMusic(string username, string connectionString)
        {
            InitializeComponent();
            _username = username; // Stocker le nom d'utilisateur passé
            _connectionString = connectionString; // Stocker la chaîne de connexion
        }

        private void textBoxMusicTitle_TextChanged(object sender, EventArgs e)
        {
            // Cette méthode est appelée chaque fois que le texte dans textBoxMusicTitle change
            // Vous pouvez ajouter du code ici pour valider ou effectuer des actions pendant la saisie.
        }

        private void textBoxLink_TextChanged(object sender, EventArgs e)
        {
            // Cette méthode est appelée chaque fois que le texte dans textBoxLink change
            // Vous pouvez ajouter du code ici pour valider ou effectuer des actions pendant la saisie.
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs saisies par l'utilisateur dans les TextBox
            string title = textBoxMusicTitle.Text;
            string link = textBoxLink.Text;

            // Vérifier si les champs ne sont pas vides
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(link))
            {
                try
                {
                    // Connexion à la base de données pour insérer la musique
                    using (MySqlConnection connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();

                        // Requête pour insérer la musique dans la table Musics
                        string query = "INSERT INTO Musics (Title, Link, Username) VALUES (@Title, @Link, @Username)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            // Ajout des paramètres à la commande SQL
                            command.Parameters.AddWithValue("@Title", title);
                            command.Parameters.AddWithValue("@Link", link);
                            command.Parameters.AddWithValue("@Username", _username); // Utilisez _username ici

                            // Exécution de la commande
                            command.ExecuteNonQuery();
                        }
                    }

                    // Afficher un message de succès
                    MessageBox.Show("Musique ajoutée avec succès !");

                    // Créer une instance de FormMusic et lui passer les paramètres nécessaires
                    FormMusic formMusic = new FormMusic(_username, _connectionString);

                    // Afficher FormMusic
                    formMusic.Show();

                    // Fermer le formulaire actuel (FormAddMusic)
                    this.Close();
                }
                catch (MySqlException ex)
                {
                    // Gestion des erreurs MySQL
                    MessageBox.Show($"Erreur de base de données: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Gestion des erreurs générales
                    MessageBox.Show($"Une erreur inattendue est survenue: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Si les champs sont vides, afficher un message d'erreur
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }

        private void FormAddMusic_Load(object sender, EventArgs e)
        {
            // Code à exécuter lors du chargement du formulaire
        }
    }
}
