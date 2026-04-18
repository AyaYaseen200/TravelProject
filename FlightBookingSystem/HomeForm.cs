using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem
{
    public partial class HomeForm : Form
    {
        // Panels
        private Panel headerPanel;
        private Panel titlePanel;
        private Panel searchPanel;

        // Header
        private Label logoLabel;

        // Title section
        private Label mainTitleLabel;
        private Label subTitleLabel;

        // Trip type
        private GroupBox tripTypeGroup;
        private RadioButton roundTripRadio;
        private RadioButton oneWayRadio;

        // From / To
        private Label fromLabel;
        private Label toLabel;
        private ComboBox fromComboBox;
        private ComboBox toComboBox;
        private Button swapButton;

        // Dates
        private Label departureLabel;
        private Label returnLabel;
        private DateTimePicker departureDatePicker;
        private DateTimePicker returnDatePicker;

        // Passengers
        private Label passengersLabel;
        private ComboBox passengersComboBox;

        // Search
        private Button searchButton;

        public HomeForm()
        {
            InitializeComponent();

            SetupForm();
            CreateHeader();
            CreateTitleSection();
            CreateSearchSection();
            UpdateReturnDateVisibility();
        }

        private void SetupForm()
        {
            this.Text = "FlyStack";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Font = new Font("Segoe UI", 10);
        }

        private void CreateHeader()
        {
            headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 70;
            headerPanel.BackColor = Color.White;

            logoLabel = new Label();
            logoLabel.Text = "✈ FlyStack";
            logoLabel.AutoSize = true;
            logoLabel.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            logoLabel.ForeColor = Color.FromArgb(44, 62, 80);
            logoLabel.Location = new Point(30, 15);

            headerPanel.Controls.Add(logoLabel);
            this.Controls.Add(headerPanel);
        }

        private void CreateTitleSection()
        {
            titlePanel = new Panel();
            titlePanel.Dock = DockStyle.Top;
            titlePanel.Height = 260;
            titlePanel.BackColor = Color.FromArgb(31, 89, 158);

            mainTitleLabel = new Label();
            mainTitleLabel.Text = "إلى أين تريد السفر؟";
            mainTitleLabel.Dock = DockStyle.Top;
            mainTitleLabel.Height = 90;
            mainTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainTitleLabel.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            mainTitleLabel.ForeColor = Color.White;

            subTitleLabel = new Label();
            subTitleLabel.Text = "ابحث عن أفضل عروض الرحلات بأسعار تنافسية";
            subTitleLabel.Dock = DockStyle.Top;
            subTitleLabel.Height = 40;
            subTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            subTitleLabel.Font = new Font("Segoe UI", 12);
            subTitleLabel.ForeColor = Color.FromArgb(210, 225, 240);

            CreateTripTypeSection();

            titlePanel.Controls.Add(tripTypeGroup);
            titlePanel.Controls.Add(subTitleLabel);
            titlePanel.Controls.Add(mainTitleLabel);

            this.Controls.Add(titlePanel);
        }

        private void CreateTripTypeSection()
        {
            tripTypeGroup = new GroupBox();
            tripTypeGroup.Text = "نوع الرحلة";
            tripTypeGroup.Size = new Size(320, 60);
            tripTypeGroup.ForeColor = Color.White;
            tripTypeGroup.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            tripTypeGroup.BackColor = Color.Transparent;
            tripTypeGroup.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - tripTypeGroup.Width) / 2,
                155
            );

            roundTripRadio = new RadioButton();
            roundTripRadio.Text = "ذهاب وعودة";
            roundTripRadio.AutoSize = true;
            roundTripRadio.ForeColor = Color.White;
            roundTripRadio.Location = new Point(170, 25);
            roundTripRadio.Checked = true;
            roundTripRadio.CheckedChanged += TripTypeChanged;

            oneWayRadio = new RadioButton();
            oneWayRadio.Text = "ذهاب فقط";
            oneWayRadio.AutoSize = true;
            oneWayRadio.ForeColor = Color.White;
            oneWayRadio.Location = new Point(40, 25);
            oneWayRadio.CheckedChanged += TripTypeChanged;

            tripTypeGroup.Controls.Add(roundTripRadio);
            tripTypeGroup.Controls.Add(oneWayRadio);
        }

        private void CreateSearchSection()
        {
            searchPanel = new Panel();
            searchPanel.Size = new Size(900, 300);
            searchPanel.BackColor = Color.White;
            searchPanel.BorderStyle = BorderStyle.FixedSingle;
            searchPanel.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - searchPanel.Width) / 2,
                280
            );

            string[] cities =
            {
                "عمان (AMM)",
                "دبي (DXB)",
                "جدة (JED)",
                "الدوحة (DOH)",
                "القاهرة (CAI)",
                "اسطنبول (IST)",
                "باريس (CDG)",
                "اليابان (JP)",
                "بيروت (BEY)"
            };

            // From
            fromLabel = CreateLabel("من", new Point(780, 20));
            fromComboBox = CreateComboBox(new Point(470, 45), cities, 0);

            // To
            toLabel = CreateLabel("إلى", new Point(350, 20));
            toComboBox = CreateComboBox(new Point(40, 45), cities, 2);

            // Swap button
            swapButton = new Button();
            swapButton.Text = "⇄";
            swapButton.Size = new Size(45, 35);
            swapButton.Location = new Point(415, 47);
            swapButton.FlatStyle = FlatStyle.Flat;
            swapButton.FlatAppearance.BorderSize = 1;
            swapButton.BackColor = Color.WhiteSmoke;
            swapButton.ForeColor = Color.FromArgb(31, 89, 158);
            swapButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            swapButton.Cursor = Cursors.Hand;
            swapButton.Click += SwapButton_Click;

            // Departure date
            departureLabel = CreateLabel("تاريخ السفر", new Point(780, 100));

            departureDatePicker = new DateTimePicker();
            departureDatePicker.Location = new Point(470, 125);
            departureDatePicker.Size = new Size(350, 30);
            departureDatePicker.Format = DateTimePickerFormat.Short;

            // Return date
            returnLabel = CreateLabel("تاريخ العودة", new Point(350, 100));

            returnDatePicker = new DateTimePicker();
            returnDatePicker.Location = new Point(40, 125);
            returnDatePicker.Size = new Size(350, 30);
            returnDatePicker.Format = DateTimePickerFormat.Short;

            // Passengers
            passengersLabel = new Label();
            passengersLabel.Text = "المسافرين";
            passengersLabel.AutoSize = true;
            passengersLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            passengersLabel.ForeColor = Color.FromArgb(44, 62, 80);

            passengersComboBox = new ComboBox();
            passengersComboBox.Size = new Size(350, 30);
            passengersComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            passengersComboBox.Items.AddRange(new string[]
            {
                "1 مسافر",
                "2 مسافرين",
                "3 مسافرين",
                "4 مسافرين",
                "5 مسافرين أو أكثر"
            });
            passengersComboBox.SelectedIndex = 0;

            passengersComboBox.Left = (searchPanel.Width - passengersComboBox.Width) / 2;
            passengersComboBox.Top = 190;

            passengersLabel.Left = passengersComboBox.Left + 130;
            passengersLabel.Top = 165;

            // Search button
            searchButton = new Button();
            searchButton.Text = "ابحث عن الرحلات";
            searchButton.Size = new Size(780, 45);
            searchButton.Location = new Point(60, 235);
            searchButton.BackColor = Color.FromArgb(230, 126, 34);
            searchButton.ForeColor = Color.White;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            searchButton.Cursor = Cursors.Hand;
            searchButton.Click += SearchButton_Click;

            searchPanel.Controls.Add(fromLabel);
            searchPanel.Controls.Add(fromComboBox);

            searchPanel.Controls.Add(toLabel);
            searchPanel.Controls.Add(toComboBox);

            searchPanel.Controls.Add(swapButton);

            searchPanel.Controls.Add(departureLabel);
            searchPanel.Controls.Add(departureDatePicker);

            searchPanel.Controls.Add(returnLabel);
            searchPanel.Controls.Add(returnDatePicker);

            searchPanel.Controls.Add(passengersLabel);
            searchPanel.Controls.Add(passengersComboBox);

            searchPanel.Controls.Add(searchButton);

            this.Controls.Add(searchPanel);
            searchPanel.BringToFront();
        }

        private Label CreateLabel(string text, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = location;
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(44, 62, 80);
            return label;
        }

        private ComboBox CreateComboBox(Point location, string[] items, int selectedIndex)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Location = location;
            comboBox.Size = new Size(350, 30);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndex = selectedIndex;
            return comboBox;
        }
        private void HomeForm_Load(object sender, EventArgs e)
        {

        }
        private void SwapButton_Click(object sender, EventArgs e)
        {
            int tempIndex = fromComboBox.SelectedIndex;
            fromComboBox.SelectedIndex = toComboBox.SelectedIndex;
            toComboBox.SelectedIndex = tempIndex;
        }

        private void TripTypeChanged(object sender, EventArgs e)
        {
            UpdateReturnDateVisibility();
        }

        private void UpdateReturnDateVisibility()
        {
            bool showReturnDate = roundTripRadio.Checked;

            returnLabel.Visible = showReturnDate;
            returnDatePicker.Visible = showReturnDate;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string tripTypeText;

            if (roundTripRadio.Checked)
            {
                tripTypeText = "ذهاب وعودة";
            }
            else
            {
                tripTypeText = "ذهاب فقط";
            }
       
            string message =
                "نوع الرحلة: " + tripTypeText +
                "\nمن: " + fromComboBox.Text +
                "\nإلى: " + toComboBox.Text +
                "\nتاريخ السفر: " + departureDatePicker.Value.ToShortDateString();

            if (roundTripRadio.Checked)
            {
                message += "\nتاريخ العودة: " + returnDatePicker.Value.ToShortDateString();
            }

            message += "\nعدد المسافرين: " + passengersComboBox.Text;

            MessageBox.Show(message, "تفاصيل الحجز");
        }
    }
}