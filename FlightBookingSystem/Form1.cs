namespace FlightBookingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(400, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // ===== زر الخروج =====
            Label btnClose = new Label();
            btnClose.Text = "✕";
            btnClose.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.Transparent;
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;

            btnClose.Location = new Point(this.ClientSize.Width - 35, 10);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // الضغط
            btnClose.Click += (s, e) =>
            {
                Application.Exit();
            };

            // 🔥 Hover (تكبير + لون)
            btnClose.MouseEnter += (s, e) =>
            {
                btnClose.ForeColor = Color.Red;
                btnClose.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            };

            btnClose.MouseLeave += (s, e) =>
            {
                btnClose.ForeColor = Color.White;
                btnClose.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            };

            this.Controls.Add(btnClose);
            btnClose.BringToFront();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginForm1 login = new LoginForm1();
            login.Show();
            this.Hide();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
