namespace VoteMyMusic
{
    partial class FormSavedMusic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSavedMusic = new Panel();
            ButtonBack = new Button();
            listBoxVotedMusic = new ListBox(); // Ajout du ListBox pour les titres votés
            panelSavedMusic.SuspendLayout();
            SuspendLayout();
            // 
            // panelSavedMusic
            // 
            panelSavedMusic.BackColor = SystemColors.ControlLightLight;
            panelSavedMusic.Controls.Add(ButtonBack);
            panelSavedMusic.Controls.Add(listBoxVotedMusic); // Ajouter le ListBox au panel
            panelSavedMusic.Location = new Point(32, 28);
            panelSavedMusic.Name = "panelSavedMusic";
            panelSavedMusic.Size = new Size(886, 440);
            panelSavedMusic.TabIndex = 0;
            // 
            // ButtonBack
            // 
            ButtonBack.Location = new Point(777, 12);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(94, 28);
            ButtonBack.TabIndex = 0;
            ButtonBack.Text = "Back";
            ButtonBack.UseVisualStyleBackColor = true;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // listBoxVotedMusic
            // 
            listBoxVotedMusic.FormattingEnabled = true;
            listBoxVotedMusic.ItemHeight = 20;
            listBoxVotedMusic.Location = new Point(10, 50); // Positionner le ListBox sous le bouton
            listBoxVotedMusic.Name = "listBoxVotedMusic";
            listBoxVotedMusic.Size = new Size(860, 380); // Taille du ListBox
            listBoxVotedMusic.TabIndex = 1;
            // 
            // FormSavedMusic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 509);
            Controls.Add(panelSavedMusic);
            Name = "FormSavedMusic";
            Text = "FormSavedMusic";
            panelSavedMusic.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSavedMusic;
        private Button ButtonBack;
        private ListBox listBoxVotedMusic; // Déclaration du ListBox
    }
}
