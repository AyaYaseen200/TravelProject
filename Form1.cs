using TravelApp;

namespace TravelApp
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           // this.Load += Form1_Load;
        }

        private Panel CreateCityCard(string city,string imagePath)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.Height = 250;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.None;
            card.BackColor = Color.FromArgb(120, Color.White); // شفافية
            card.BorderStyle = BorderStyle.None;

            // نعمل حواف دائرية باستخدام GraphicsPath
            card.Paint += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 20;
                Rectangle rect = new Rectangle(0, 0, card.Width, card.Height);

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                card.Region = new Region(path);

                // خلفية شبه شفافة مع تدرج
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect, Color.FromArgb(180, Color.White), Color.FromArgb(180, Color.LightBlue), 45f))
                {
                    e.Graphics.FillPath(brush, path);
                }





                // إطار خارجي أنيق
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            };


            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.FromArgb(120, Color.White);
                card.Width = 250;
                card.Height = 250;
            };



            PictureBox pic = new PictureBox();
            pic.ImageLocation = imagePath;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Width = 230;
            pic.Height = 140;
            pic.Top = 10;
            pic.Left = 10;
           
            // 2. زر المفضلة (القلب) - يظهر فوق الصورة مباشرة
            Label lblFav = new Label();
            lblFav.Text = "❤";
            lblFav.ForeColor = Color.White;
            lblFav.BackColor = Color.Transparent;
            lblFav.Font = new Font("Segoe UI Symbol", 16, FontStyle.Bold);
            lblFav.AutoSize = true;
            lblFav.Cursor = Cursors.Hand;
            lblFav.Parent = pic; // ربط القلب بالصورة
            lblFav.Location = new Point(pic.Width - 35, 5);

            lblFav.Click += (s, e) =>
            {
                lblFav.ForeColor = (lblFav.ForeColor == Color.White) ? Color.Red : Color.White;
            };

            Label lblCity = new Label();

            lblCity.Text = "✈️ " + city;
            lblCity.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCity.Top = pic.Bottom + 10;   // ✅ تحت الصورة مباشرة
            lblCity.Left = 10;
            lblCity.AutoSize = true;
            // lblCity.ForeColor = Color.Black; // ✅ لون واضح

   

            card.Controls.Add(pic);
                        card.Controls.Add(lblCity);


            return card;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

          flowLayoutPanel1.Controls.Add(CreateCityCard("اسطنبول", "images/istanbul.jpg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("دبي", "images/dubai1.jpg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("عمّان", "images/amman.jpeg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("القاهرة", "images/cairo.jpeg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("بيروت", "images/beirut.jpeg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("جدة", "images/jeddah.jpeg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("الدوحة",  "images/doha.jpeg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("اليابان", "images/japan.jpg"));
            flowLayoutPanel1.Controls.Add(CreateCityCard("باريس", "images/paris.jpg"));

            // ... الكود اللي يبني الكروت

            Button btnDetailsGlobal = new Button();
            btnDetailsGlobal.Text = "عرض التفاصيل";
            btnDetailsGlobal.Height = 40;
            btnDetailsGlobal.Dock = DockStyle.Bottom;

            btnDetailsGlobal.Click += (s, e2) =>
            {
                FormDetails detailsForm = new FormDetails();
                detailsForm.Show();
            };

            this.Controls.Add(btnDetailsGlobal);
        }
    }
    }



