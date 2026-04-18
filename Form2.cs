using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TravelApp
{
    public partial class Form2 : Form
    {
        private ComboBox comboTrip;
        private Label labelTotal;
        private NumericUpDown numSeats;
        private TextBox textName;
        private TextBox textPhone;
        private Button btnBook;


            public Form2()
            {
                InitializeComponent();
                CreateControls(); // ✨ استدعاء لإنشاء العناصر
            }

            // إنشاء كل العناصر وإضافتها للفورم
            private void CreateControls()
            {
                // ComboBox للرحلات
                comboTrip = new ComboBox();
                comboTrip.Top = 20;
                comboTrip.Left = 20;
                this.Controls.Add(comboTrip);

                // Label للسعر
                labelTotal = new Label();
                labelTotal.Text = "0";
                labelTotal.Top = 60;
                labelTotal.Left = 20;
                this.Controls.Add(labelTotal);

                // NumericUpDown لعدد المقاعد
                numSeats = new NumericUpDown();
                numSeats.Minimum = 1;
                numSeats.Value = 1;
                numSeats.Top = 100;
                numSeats.Left = 20;
                numSeats.ValueChanged += numSeats_ValueChanged;
                this.Controls.Add(numSeats);

                // TextBox للاسم
                textName = new TextBox();
                textName.PlaceholderText = "الاسم";
                textName.Top = 140;
                textName.Left = 20;
                this.Controls.Add(textName);

                // TextBox للهاتف
                textPhone = new TextBox();
                textPhone.PlaceholderText = "رقم الهاتف";
                textPhone.Top = 180;
                textPhone.Left = 20;
                this.Controls.Add(textPhone);

                // زر تأكيد الحجز
                btnBook = new Button();
                btnBook.Text = "تأكيد الحجز";
                btnBook.Top = 220;
                btnBook.Left = 20;
                btnBook.Click += btnBook_Click;
                this.Controls.Add(btnBook);
            }

            // ✨ الدالة اللي تستقبل معلومات الرحلة من الفورم الأول
            public void SetBookingInfo(string destination, double price)
            {
                comboTrip.Items.Clear();
                comboTrip.Items.Add(destination);
                comboTrip.SelectedItem = destination;

                labelTotal.Text = price.ToString();
            }

            private void numSeats_ValueChanged(object sender, EventArgs e)
            {
                CalculateTotal();
            }

            private void btnBook_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(textName.Text) ||
                    string.IsNullOrWhiteSpace(textPhone.Text) ||
                    comboTrip.SelectedItem == null)
                {
                    MessageBox.Show("يرجى تعبئة جميع الحقول!");
                    return;
                }

                MessageBox.Show("تم الحجز بنجاح ✅");
            }

            private void CalculateTotal()
            {
                if (comboTrip.SelectedItem == null)
                {
                    labelTotal.Text = "0";
                    return;
                }

                double tripPrice = Convert.ToDouble(labelTotal.Text);
                int persons = (int)numSeats.Value;
                double total = tripPrice * persons;
                labelTotal.Text = total.ToString();
            }
        }
    }
