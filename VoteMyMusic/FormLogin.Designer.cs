namespace VoteMyMusic
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            panel1 = new Panel();
            PanelShowPassword = new Panel();
            linkLabelForRegister = new LinkLabel();
            buttonClear = new Button();
            buttonLogin = new Button();
            checkBox1 = new CheckBox();
            textBoxPassword = new TextBox();
            LabelPassword = new Label();
            textBoxUsername = new TextBox();
            LabelUsername = new Label();
            labelLogin = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            PanelShowPassword.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(PanelShowPassword);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(158, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(971, 504);
            panel1.TabIndex = 1;
            // 
            // PanelShowPassword
            // 
            PanelShowPassword.Controls.Add(linkLabelForRegister);
            PanelShowPassword.Controls.Add(buttonClear);
            PanelShowPassword.Controls.Add(buttonLogin);
            PanelShowPassword.Controls.Add(checkBox1);
            PanelShowPassword.Controls.Add(textBoxPassword);
            PanelShowPassword.Controls.Add(LabelPassword);
            PanelShowPassword.Controls.Add(textBoxUsername);
            PanelShowPassword.Controls.Add(LabelUsername);
            PanelShowPassword.Controls.Add(labelLogin);
            PanelShowPassword.Dock = DockStyle.Right;
            PanelShowPassword.Location = new Point(468, 0);
            PanelShowPassword.Name = "PanelShowPassword";
            PanelShowPassword.Size = new Size(503, 504);
            PanelShowPassword.TabIndex = 1;
            // 
            // linkLabelForRegister
            // 
            linkLabelForRegister.AutoSize = true;
            linkLabelForRegister.LinkColor = Color.Black;
            linkLabelForRegister.Location = new Point(368, 287);
            linkLabelForRegister.Name = "linkLabelForRegister";
            linkLabelForRegister.Size = new Size(63, 20);
            linkLabelForRegister.TabIndex = 10;
            linkLabelForRegister.TabStop = true;
            linkLabelForRegister.Text = "Register";
            linkLabelForRegister.LinkClicked += linkLabelForRegister_LinkClicked;
            // 
            // buttonClear
            // 
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(104, 295);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 9;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Location = new Point(104, 260);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(94, 29);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonRegister_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Location = new Point(303, 260);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(128, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(104, 227);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(327, 27);
            textBoxPassword.TabIndex = 4;
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelPassword.Location = new Point(104, 204);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(79, 20);
            LabelPassword.TabIndex = 3;
            LabelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(104, 156);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(327, 27);
            textBoxUsername.TabIndex = 2;
            // 
            // LabelUsername
            // 
            LabelUsername.AutoSize = true;
            LabelUsername.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelUsername.Location = new Point(104, 133);
            LabelUsername.Name = "LabelUsername";
            LabelUsername.Size = new Size(82, 20);
            LabelUsername.TabIndex = 1;
            LabelUsername.Text = "Username";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.Location = new Point(222, 80);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(79, 40);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "Login";
            labelLogin.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(468, 504);
            panel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(468, 504);
            panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(468, 504);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 780);
            Controls.Add(panel1);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            panel1.ResumeLayout(false);
            PanelShowPassword.ResumeLayout(false);
            PanelShowPassword.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel PanelShowPassword;
        private LinkLabel linkLabelForRegister;
        private Button buttonClear;
        private Button buttonLogin;
        private CheckBox checkBox1;
        private TextBox textBoxPassword;
        private Label LabelPassword;
        private TextBox textBoxUsername;
        private Label LabelUsername;
        private Label labelLogin;
        private Panel panel2;
        private Panel panel4;
        private PictureBox pictureBox1;
    }
}