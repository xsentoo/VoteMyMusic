namespace VoteMyMusic
{
    partial class FormMusic
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMusic));
            panel1 = new Panel();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            button1 = new Button();
            panel4 = new Panel();
            button3 = new Button();
            panel3 = new Panel();
            button2 = new Button();
            panel5 = new Panel();
            panel6 = new Panel();
            buttonOut = new Button();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(954, 62);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(404, 25);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 0;
            label1.Text = "Bienvenue";
            label1.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel6);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 62);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(208, 447);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(182, 46);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(182, 46);
            button1.TabIndex = 0;
            button1.Text = "Profile";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Location = new Point(3, 55);
            panel4.Name = "panel4";
            panel4.Size = new Size(182, 46);
            panel4.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaptionText;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(182, 46);
            button3.TabIndex = 0;
            button3.Text = "Music save";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(button2);
            panel3.Location = new Point(3, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(182, 46);
            panel3.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(182, 46);
            button2.TabIndex = 0;
            button2.Text = "Add Music";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonHighlight;
            panel5.Location = new Point(246, 95);
            panel5.Name = "panel5";
            panel5.Size = new Size(662, 375);
            panel5.TabIndex = 2;
            panel5.Paint += panel5_Paint;
            // 
            // panel6
            // 
            panel6.Controls.Add(buttonOut);
            panel6.Location = new Point(3, 159);
            panel6.Name = "panel6";
            panel6.Size = new Size(182, 46);
            panel6.TabIndex = 6;
            // 
            // buttonOut
            // 
            buttonOut.BackColor = SystemColors.ActiveCaptionText;
            buttonOut.FlatStyle = FlatStyle.Popup;
            buttonOut.Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonOut.ForeColor = SystemColors.ButtonFace;
            buttonOut.Image = (Image)resources.GetObject("buttonOut.Image");
            buttonOut.ImageAlign = ContentAlignment.MiddleLeft;
            buttonOut.Location = new Point(0, 0);
            buttonOut.Name = "buttonOut";
            buttonOut.Size = new Size(182, 46);
            buttonOut.TabIndex = 0;
            buttonOut.Text = "Deconnexion";
            buttonOut.UseVisualStyleBackColor = false;
            buttonOut.Click += buttonOut_Click;
            // 
            // FormMusic
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 509);
            Controls.Add(panel5);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMusic";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMusic";
            Load += FormMusic_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button button1;
        private Panel panel4;
        private Button button3;
        private Panel panel3;
        private Button button2;
        private Panel panel5;
        private Panel panel6;
        private Button buttonOut;
    }
}
