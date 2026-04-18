namespace FlightBookingSystem
{
    partial class LoginForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm1));
            panel1 = new Panel();
            LblPassword = new Label();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            checkBox1 = new CheckBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            LblUsername = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(LblPassword);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(LblUsername);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(673, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(127, 401);
            panel1.TabIndex = 0;
            panel1.Click += LoginForm1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // LblPassword
            // 
            LblPassword.AutoSize = true;
            LblPassword.BackColor = Color.Transparent;
            LblPassword.BorderStyle = BorderStyle.FixedSingle;
            LblPassword.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPassword.Location = new Point(112, 184);
            LblPassword.Name = "LblPassword";
            LblPassword.Size = new Size(66, 19);
            LblPassword.TabIndex = 8;
            LblPassword.Text = "Password";
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(107, 321);
            button1.Name = "button1";
            button1.Size = new Size(78, 32);
            button1.TabIndex = 6;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(98, 373);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(94, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forget Password";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Location = new Point(100, 275);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Remember me";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.GradientActiveCaption;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(98, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(102, 23);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.GradientActiveCaption;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(98, 132);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(102, 23);
            txtUsername.TabIndex = 2;
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.Transparent;
            LblUsername.BorderStyle = BorderStyle.FixedSingle;
            LblUsername.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblUsername.Location = new Point(109, 89);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(76, 19);
            LblUsername.TabIndex = 1;
            LblUsername.Text = "User Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("PT Bold Broken", 24F, FontStyle.Regular, GraphicsUnit.Point, 178);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(88, 16);
            label1.Name = "label1";
            label1.Size = new Size(139, 57);
            label1.TabIndex = 0;
            label1.Text = "Login";
            label1.Click += label1_Click;
            // 
            // LoginForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 401);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "LoginForm1";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "LoginForm1";
            Load += LoginForm1_Load;
            Click += LoginForm1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label LblUsername;
        private Button button1;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label LblPassword;
    }
}