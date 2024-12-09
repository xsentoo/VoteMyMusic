namespace VoteMyMusic
{
    partial class Register
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            PanelShowPassword = new Panel();
            linkLabel1 = new LinkLabel();
            buttonClear = new Button();
            buttonRegister = new Button();
            checkBox1 = new CheckBox();
            textBoxComPassword = new TextBox();
            LabelComPassword = new Label();
            textBoxPassword = new TextBox();
            LabelPassword = new Label();
            textBoxUsername = new TextBox();
            LabelUsername = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
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
            panel1.Location = new Point(197, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(971, 504);
            panel1.TabIndex = 0;
            // 
            // PanelShowPassword
            // 
            PanelShowPassword.Controls.Add(linkLabel1);
            PanelShowPassword.Controls.Add(buttonClear);
            PanelShowPassword.Controls.Add(buttonRegister);
            PanelShowPassword.Controls.Add(checkBox1);
            PanelShowPassword.Controls.Add(textBoxComPassword);
            PanelShowPassword.Controls.Add(LabelComPassword);
            PanelShowPassword.Controls.Add(textBoxPassword);
            PanelShowPassword.Controls.Add(LabelPassword);
            PanelShowPassword.Controls.Add(textBoxUsername);
            PanelShowPassword.Controls.Add(LabelUsername);
            PanelShowPassword.Controls.Add(label1);
            PanelShowPassword.Dock = DockStyle.Right;
            PanelShowPassword.Location = new Point(468, 0);
            PanelShowPassword.Name = "PanelShowPassword";
            PanelShowPassword.Size = new Size(503, 504);
            PanelShowPassword.TabIndex = 1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(253, 373);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(178, 20);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Already Have An Account";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // buttonClear
            // 
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(104, 369);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 9;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Location = new Point(104, 334);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(94, 29);
            buttonRegister.TabIndex = 8;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Location = new Point(299, 336);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(128, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxComPassword
            // 
            textBoxComPassword.Location = new Point(104, 291);
            textBoxComPassword.Name = "textBoxComPassword";
            textBoxComPassword.Size = new Size(327, 27);
            textBoxComPassword.TabIndex = 6;
            // 
            // LabelComPassword
            // 
            LabelComPassword.AutoSize = true;
            LabelComPassword.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelComPassword.Location = new Point(104, 268);
            LabelComPassword.Name = "LabelComPassword";
            LabelComPassword.Size = new Size(144, 20);
            LabelComPassword.TabIndex = 5;
            LabelComPassword.Text = "Confirm Password";
            LabelComPassword.Click += label4_Click;
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
            LabelPassword.Click += label3_Click;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(104, 156);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(327, 27);
            textBoxUsername.TabIndex = 2;
            textBoxUsername.TextChanged += textBox1_TextChanged;
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
            LabelUsername.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(179, 79);
            label1.Name = "label1";
            label1.Size = new Size(158, 40);
            label1.TabIndex = 0;
            label1.Text = "Registration";
            label1.Click += label1_Click;
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
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(468, 504);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1315, 780);
            Controls.Add(label2);
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1333, 827);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            WindowState = FormWindowState.Minimized;
            Load += Register_Load;
            panel1.ResumeLayout(false);
            PanelShowPassword.ResumeLayout(false);
            PanelShowPassword.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel PanelShowPassword;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Label label1;
        private Label LabelUsername;
        private TextBox textBoxUsername;
        private TextBox textBoxComPassword;
        private Label LabelComPassword;
        private TextBox textBoxPassword;
        private Label LabelPassword;
        private CheckBox checkBox1;
        private Button buttonRegister;
        private Button buttonClear;
        private Label label2;
        private LinkLabel linkLabel1;
    }
}
