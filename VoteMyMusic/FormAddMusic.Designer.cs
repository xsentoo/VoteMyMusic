namespace VoteMyMusic
{
    partial class FormAddMusic
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
            labelAddMusic = new Label();
            textBoxMusicTitle = new TextBox();
            textBoxLink = new TextBox();
            labelMusicTitle = new Label();
            label2 = new Label();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // labelAddMusic
            // 
            labelAddMusic.AutoSize = true;
            labelAddMusic.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAddMusic.Location = new Point(590, 130);
            labelAddMusic.Name = "labelAddMusic";
            labelAddMusic.Size = new Size(118, 31);
            labelAddMusic.TabIndex = 0;
            labelAddMusic.Text = "AddMusic";
            // 
            // textBoxMusicTitle
            // 
            textBoxMusicTitle.Location = new Point(525, 184);
            textBoxMusicTitle.Name = "textBoxMusicTitle";
            textBoxMusicTitle.Size = new Size(257, 27);
            textBoxMusicTitle.TabIndex = 1;
            textBoxMusicTitle.TextChanged += textBoxMusicTitle_TextChanged;
            // 
            // textBoxLink
            // 
            textBoxLink.Location = new Point(525, 257);
            textBoxLink.Name = "textBoxLink";
            textBoxLink.Size = new Size(257, 27);
            textBoxLink.TabIndex = 2;
            textBoxLink.TextChanged += textBoxLink_TextChanged;
            // 
            // labelMusicTitle
            // 
            labelMusicTitle.AutoSize = true;
            labelMusicTitle.Location = new Point(525, 161);
            labelMusicTitle.Name = "labelMusicTitle";
            labelMusicTitle.Size = new Size(80, 20);
            labelMusicTitle.TabIndex = 4;
            labelMusicTitle.Text = "Music Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(525, 234);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 5;
            label2.Text = "Link";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(688, 307);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormAddMusic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 780);
            Controls.Add(buttonAdd);
            Controls.Add(label2);
            Controls.Add(labelMusicTitle);
            Controls.Add(textBoxLink);
            Controls.Add(textBoxMusicTitle);
            Controls.Add(labelAddMusic);
            Name = "FormAddMusic";
            Text = "FormAddMusic";
            Load += FormAddMusic_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAddMusic;
        private TextBox textBoxMusicTitle;
        private TextBox textBoxLink;
        private Label labelMusicTitle;
        private Label label2;
        private Button buttonAdd;
    }
}