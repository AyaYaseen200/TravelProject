using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace TravelApp
{
    public partial class FormDetails : Form
    {


        public FormDetails()
        {

            InitializeComponent();
            this.Text = "تفاصيل الرحلات";
            this.Width = 900;
            this.Height = 700;

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.AutoScroll = true;
            this.Controls.Add(flow);

            // قائمة رحلات (لكل مدينة كائن Trip)
            Trip[] trips =
            {
                new Trip { Destination="دبي", Company="طيران الإمارات", Time="10:00 صباحاً", Price=300, Rating=4.5, SeatsAvailable=12, Description="رحلة رائعة إلى دبي", ImagePath="images/dubai1.jpg"},
                new Trip { Destination="اسطنبول", Company="الخطوط التركية", Time="12:00 ظهراً", Price=250, Rating=4.7, SeatsAvailable=8, Description="استكشف اسطنبول", ImagePath="images/istanbul.jpg"},
                new Trip { Destination="عمان", Company="الملكية الأردنية", Time="6:00 مساءً", Price=240, Rating=4.2, SeatsAvailable=11, Description="زيارة المدينة القديمة في عمان",ImagePath="images/amman.jpeg"},
                new Trip { Destination="القاهرة", Company="مصر للطيران", Time="2:00 مساءً", Price=200, Rating=4.3, SeatsAvailable=10, Description="زيارة الأهرامات", ImagePath="images/cairo.jpeg"},
                new Trip { Destination="بيروت", Company="طيران الشرق الأوسط", Time="8:00 مساءً", Price=260, Rating=4.1, SeatsAvailable=7, Description="استمتع بحياة بيروت الليلية", ImagePath="images/beirut.jpeg"},
                new Trip { Destination="جدة", Company="الخطوط السعودية", Time="3:00 مساءً", Price=220, Rating=4.4, SeatsAvailable=15, Description="اكتشف كورنيش جدة", ImagePath="images/jeddah.jpeg"},
                new Trip { Destination="الدوحة", Company="الخطوط القطرية", Time="5:00 مساءً", Price=280, Rating=4.6, SeatsAvailable=9, Description="استمتع بأفق الدوحة", ImagePath="images/doha.jpeg"},
                new Trip { Destination="اليابان", Company="الخطوط اليابانية", Time="11:00 مساءً", Price=700, Rating=4.9, SeatsAvailable=6, Description="اكتشف طوكيو وكيوتو", ImagePath="images/japan.jpg"},
                new Trip { Destination="باريس", Company="Air France", Time="9:00 مساءً", Price=500, Rating=4.8, SeatsAvailable=5, Description="رحلة جميلة إلى باريس", ImagePath="images/paris.jpg"},
            };

            // إنشاء بطاقة لكل رحلة
            foreach (var trip in trips)
            {
                flow.Controls.Add(CreateTripCard(trip));
            }
        }

        private Panel CreateTripCard(Trip trip)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.Height = 380;
            card.BackColor = Color.White;
            card.Margin = new Padding(10);
            // حواف دائرية + خلفية متدرجة + إطار
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

            

                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            };
            PictureBox pic = new PictureBox();
            pic.ImageLocation = trip.ImagePath;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Width = 230;
            pic.Height = 120;
            pic.Top = 10;
            pic.Left = 10;

            Label lblCity = new Label();
            lblCity.Text = trip.Destination;
            lblCity.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCity.Top = pic.Bottom + 5;
            lblCity.Left = 10;
            lblCity.AutoSize = true;

            Label lblCompany = new Label();
            lblCompany.Text = "الشركة: " + trip.Company;
            lblCompany.Top = lblCity.Bottom + 5;
            lblCompany.Left = 10;
            lblCompany.AutoSize = true;

            Label lblTime = new Label();
            lblTime.Text = "الوقت: " + trip.Time;
            lblTime.Top = lblCompany.Bottom + 5;
            lblTime.Left = 10;
            lblTime.AutoSize = true;

            Label lblPrice = new Label();
            lblPrice.Text = "السعر: $" + trip.Price;
            lblPrice.Top = lblTime.Bottom + 5;
            lblPrice.Left = 10;
            lblPrice.AutoSize = true;

            Label lblRating = new Label();
            lblRating.Text = "التقييم: " + trip.Rating;
            lblRating.Top = lblPrice.Bottom + 5;
            lblRating.Left = 10;
            lblRating.AutoSize = true;

            Label lblSeats = new Label();
            lblSeats.Text = "المقاعد: " + trip.SeatsAvailable;
            lblSeats.Top = lblRating.Bottom + 5;
            lblSeats.Left = 10;
            lblSeats.AutoSize = true;

            Label lblDesc = new Label();
            lblDesc.Text = trip.Description;
            lblDesc.Top = lblSeats.Bottom + 5;
            lblDesc.Left = 10;
            lblDesc.Width = 220;

            Button btnBook = new Button();
            btnBook.Text = "احجز الآن";
            btnBook.Top = lblDesc.Bottom + 5;
            btnBook.Left = 10;
            btnBook.Width = 100;

            // ✨ ربط الزر بالفورم الثاني
            btnBook.Click += (s, e) =>
            {
                Form2 bookingForm = new Form2();
                bookingForm.SetBookingInfo(trip.Destination, trip.Price);
                bookingForm.ShowDialog();
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblCity);
            card.Controls.Add(lblCompany);
            card.Controls.Add(lblTime);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblRating);
            card.Controls.Add(lblSeats);
            card.Controls.Add(lblDesc);
            card.Controls.Add(btnBook);

            return card;
        }
    }
}