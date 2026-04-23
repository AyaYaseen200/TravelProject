#nullable disable
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlyStackPayment 
{
    public partial class PaymentForm : Form
    {
        private Panel p1, p2, p3, pFlights, pHome, navBar;
        private RoundedCard card;
        private MaskedTextBox t1, t2, t3;
        private Color rjBlue = Color.FromArgb(0, 35, 90);

        public PaymentForm()
        {
            this.Text = "Confirm payment";
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            // --- تطوير الخلفية (نفس كودك القديم بالظبط) ---
            this.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (LinearGradientBrush baseBrush = new LinearGradientBrush(this.ClientRectangle,
                    Color.FromArgb(10, 25, 60), Color.FromArgb(30, 70, 150), 45f))
                { g.FillRectangle(baseBrush, this.ClientRectangle); }

                using (Pen pen = new Pen(Color.FromArgb(15, Color.White), 2))
                {
                    g.DrawEllipse(pen, -100, -100, 600, 600);
                    g.DrawEllipse(pen, this.Width - 400, this.Height - 400, 800, 800);
                    g.DrawEllipse(pen, this.Width / 2 + 100, -200, 500, 500);
                }

                using (Pen linePen = new Pen(Color.FromArgb(10, Color.White), 1))
                {
                    for (int i = 0; i < this.Width; i += 150)
                        g.DrawLine(linePen, i, 0, i + 300, this.Height);
                }
            };
            InitUI();
        }

        private void InitUI()
        {
            // 1. الشريط العلوي (NavBar)
            navBar = new Panel { Dock = DockStyle.Top, Height = 85, BackColor = Color.FromArgb(180, 5, 15, 35) };
            this.Controls.Add(navBar);

            Label lblLogo = new Label { Text = "Fly Stack ✈", ForeColor = Color.Gold, Font = new Font("Segoe UI", 22, FontStyle.Bold), Dock = DockStyle.Left, TextAlign = ContentAlignment.MiddleCenter, AutoSize = true, Padding = new Padding(30, 0, 0, 0) };
            navBar.Controls.Add(lblLogo);

            FlowLayoutPanel menuPanel = new FlowLayoutPanel { Dock = DockStyle.Right, Width = 800, FlowDirection = FlowDirection.RightToLeft, BackColor = Color.Transparent, Padding = new Padding(0, 25, 30, 0) };
            navBar.Controls.Add(menuPanel);

            AddIcon(menuPanel, "🚪", (s, e) => { if (MessageBox.Show("هل أنت متأكد من رغبتك في تسجيل الخروج؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit(); });
            AddIcon(menuPanel, "🔔", (s, e) => MessageBox.Show("لا يوجد إشعارات"));
            AddIcon(menuPanel, "🌐", (s, e) => MessageBox.Show("اللغة: العربية"));

            // 2. الكرت الأبيض (المحتوى)
            card = new RoundedCard
            {
                Size = new Size(880, 520),
                BackColor = Color.White,
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - 880) / 2, (Screen.PrimaryScreen.Bounds.Height - 520) / 2 + 50),
                Radius = 50
            };
            this.Controls.Add(card);

            p1 = AddP(); p2 = AddP(); p3 = AddP(); pFlights = AddP(); pHome = AddP();

            // --- شاشة الدفع (p1) ---
            Label l1 = new Label { Text = "تفاصيل الدفع", ForeColor = rjBlue, Font = new Font("Segoe UI", 32, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Size = new Size(880, 100), Location = new Point(0, 30) };
            p1.Controls.Add(l1);

            t1 = AddF(p1, "رقم البطاقة (16 رقم)", "0000 0000 0000 0000", 400, 170, 50);
            t2 = AddF(p1, "التاريخ (شهر/سنة)", "00 / 00", 180, 170, 480);
            t3 = AddF(p1, "الرمز (CVV)", "000", 140, 170, 690);

            Label lp = new Label { Text = "المبلغ المطلوب دفعه: $600.00", ForeColor = Color.Gray, Font = new Font("Segoe UI Semibold", 13), Location = new Point(55, 305), AutoSize = true };
            p1.Controls.Add(lp);

            Button b1 = AddBtn(p1, "الانتقال لدفع $600 ✈", rjBlue, 370, 780, 50);
            b1.Click += (s, e) => { if (t1.MaskFull && t2.MaskFull && t3.MaskFull) ShowScreen(p2); else MessageBox.Show("يرجى إكمال البيانات!"); };

            // --- شاشة التأكيد (p2) ---
            Label l2 = new Label { Text = "تأكيد عملية الدفع\nالقيمة: $600.00", ForeColor = rjBlue, Font = new Font("Segoe UI", 24, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Size = new Size(880, 150), Location = new Point(0, 50) };
            p2.Controls.Add(l2);
            AddBtn(p2, "تأكيد الدفع النهائي ✅", Color.SeaGreen, 200, 450, 215).Click += (s, e) => ShowScreen(p3);
            AddBtn(p2, "تعديل البيانات ✏", Color.Goldenrod, 290, 450, 215).Click += (s, e) => ShowScreen(p1);
            AddBtn(p2, "إلغاء العملية ❌", Color.Crimson, 380, 450, 215).Click += (s, e) => { if (MessageBox.Show("هل أنت متأكد من إلغاء العملية؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit(); };

            // --- شاشة النجاح (p3) ---
            Label l3 = new Label { Text = "شكراً لك!\nتم دفع $600.00 بنجاح\nهذا هو آخر إجراء في التطبيق", ForeColor = rjBlue, Font = new Font("Segoe UI", 22, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Size = new Size(880, 250), Location = new Point(0, 80) };
            p3.Controls.Add(l3);
            AddBtn(p3, "الخروج من التطبيق ❌", Color.SlateGray, 330, 450, 215).Click += (s, e) => Application.Exit();

            ShowScreen(p1);
        }

        private void ShowScreen(Panel screen)
        {
            p1.Visible = p2.Visible = p3.Visible = pFlights.Visible = pHome.Visible = false;
            screen.Visible = true;
            screen.BringToFront();
        }

        private void AddIcon(FlowLayoutPanel p, string i, EventHandler ev)
        {
            Label l = new Label { Text = i, ForeColor = Color.White, Font = new Font("Segoe UI Symbol", 20), Margin = new Padding(15, 0, 0, 0), AutoSize = true, Cursor = Cursors.Hand };
            l.Click += ev; p.Controls.Add(l);
        }

        private Panel AddP() { Panel p = new Panel { Size = new Size(880, 520), BackColor = Color.Transparent, Location = new Point(0, 0) }; card.Controls.Add(p); return p; }

        private Button AddBtn(Panel p, string t, Color c, int y, int w, int x)
        {
            Button b = new Button { Text = t, Size = new Size(w, 75), Location = new Point(x, y), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 16, FontStyle.Bold) };
            b.FlatAppearance.BorderSize = 0; p.Controls.Add(b); return b;
        }

        private MaskedTextBox AddF(Panel p, string lb, string msk, int w, int y, int x)
        {
            Label l = new Label { Text = lb, ForeColor = Color.Gray, Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold) };
            MaskedTextBox m = new MaskedTextBox { Mask = msk, PromptChar = '_', Location = new Point(x, y + 35), Size = new Size(w, 50), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Consolas", 15), TextAlign = HorizontalAlignment.Center };
            p.Controls.Add(l); p.Controls.Add(m); return m;
        }
    }

    public class RoundedCard : Panel
    {
        [System.ComponentModel.Browsable(false)]
        public int Radius { get; set; } = 50;
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, Radius, Radius, 180, 90);
            path.AddArc(Width - Radius, 0, Radius, Radius, 270, 90);
            path.AddArc(Width - Radius, Height - Radius, Radius, Radius, 0, 90);
            path.AddArc(0, Height - Radius, Radius, Radius, 90, 90);
            this.Region = new Region(path);
            base.OnPaint(e);
        }
    }
}
