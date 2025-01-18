using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace VoteMyMusic
{
    public partial class FormProfile : Form

    {
        private string _connectionString = "server=localhost; port=3308; database=votemymusic; user=root; password=";
        private string _username;
        public FormProfile(string username, string connectionString)
        {
            InitializeComponent();
            _username = username;
            _connectionString = connectionString;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                connection.Open(); // Ouvrir explicitement la connexion

                string query = "SELECT username, password FROM users WHERE username = @Username";

                using (MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", _username);

                    using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString("username");
                            string password = reader.GetString("password");

                            // Créer des contrôles pour afficher et modifier les informations utilisateur
                            Label usernameLabel = new Label
                            {
                                Text = $"Utilisateur: {username}",
                                AutoSize = true,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                Margin = new Padding(5)
                            };

                            Label passwordLabel = new Label
                            {
                                Text = $"Mot de passe: *********",
                                AutoSize = true,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                Margin = new Padding(5)
                            };

                            Button modifyButton = new Button
                            {
                                Text = "Modifier",
                                AutoSize = true,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                Margin = new Padding(5)
                            };

                            modifyButton.Click += (s, args) =>
                            {
                                string newUsername = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nouveau nom d'utilisateur:", "Modifier le nom d'utilisateur", username);
                                string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nouveau mot de passe:", "Modifier le mot de passe", password);

                                if (!string.IsNullOrEmpty(newUsername) && !string.IsNullOrEmpty(newPassword))
                                {
                                    // Vérifiez que la connexion est ouverte avant de démarrer la transaction
                                    if (connection.State == System.Data.ConnectionState.Open)
                                    {
                                        using (MySql.Data.MySqlClient.MySqlTransaction transaction = connection.BeginTransaction())
                                        {
                                            try
                                            {
                                                // Mettre à jour la table `votes` pour refléter le nouveau nom d'utilisateur
                                                string updateVotesQuery = "UPDATE votes SET Username = @NewUsername WHERE Username = @OldUsername";
                                                using (MySql.Data.MySqlClient.MySqlCommand updateVotesCommand = new MySql.Data.MySqlClient.MySqlCommand(updateVotesQuery, connection, transaction))
                                                {
                                                    updateVotesCommand.Parameters.AddWithValue("@NewUsername", newUsername);
                                                    updateVotesCommand.Parameters.AddWithValue("@OldUsername", _username);
                                                    updateVotesCommand.ExecuteNonQuery();
                                                }

                                                // Mettre à jour la table `users`
                                                string updateUsersQuery = "UPDATE users SET username = @NewUsername, password = @NewPassword WHERE username = @Username";
                                                using (MySql.Data.MySqlClient.MySqlCommand updateUsersCommand = new MySql.Data.MySqlClient.MySqlCommand(updateUsersQuery, connection, transaction))
                                                {
                                                    updateUsersCommand.Parameters.AddWithValue("@NewUsername", newUsername);
                                                    updateUsersCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                                                    updateUsersCommand.Parameters.AddWithValue("@Username", _username);
                                                    updateUsersCommand.ExecuteNonQuery();
                                                }

                                                // Commit de la transaction
                                                transaction.Commit();

                                                MessageBox.Show("Les informations ont été mises à jour avec succès.", "Succès");

                                                // Mettre à jour le nom d'utilisateur local pour refléter les changements
                                                _username = newUsername;

                                                // Rafraîchir le panneau
                                                panel2.Invalidate();
                                            }
                                            catch (Exception ex)
                                            {
                                                // En cas d'erreur, rollback de la transaction
                                                transaction.Rollback();
                                                MessageBox.Show($"Erreur lors de la mise à jour : {ex.Message}", "Erreur");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La connexion à la base de données est fermée. Veuillez réessayer.", "Erreur");
                                    }
                                }
                            };

                            // Ajouter les contrôles au panneau
                          
                            panel2.Controls.Add(usernameLabel);
                            panel2.Controls.Add(passwordLabel);
                            panel2.Controls.Add(modifyButton);
                        }
                        else
                        {
                            Label errorLabel = new Label
                            {
                                Text = "Utilisateur non trouvé.",
                                AutoSize = true,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                ForeColor = Color.Red,
                                Margin = new Padding(5)
                            };

                           
                            panel2.Controls.Add(errorLabel);
                        }
                    }
                }
            }
        }






    }
}
