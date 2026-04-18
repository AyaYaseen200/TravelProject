using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FlightBookingSystem
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
            panel1.Size = new Size(280, 450);
            panel1.BorderStyle = BorderStyle.None;
            panel1.Location = new Point(this.ClientSize.Width - panel1.Width - 3, 100);
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BringToFront();
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uName = txtUsername.Text.Trim();
            string pw = txtPassword.Text.Trim();

            string filePath = Application.StartupPath + "\\users.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("ملف users.txt غير موجود");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool found = false;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 2)
                {
                    string savedUser = parts[0].Trim();
                    string savedPass = parts[1].Trim();

                    if (uName == savedUser && pw == savedPass)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (found)
            {
                MessageBox.Show("جاهزون للإقلاع! ✈️", "FlyStack ✈️",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                HomeForm home = new HomeForm();
                this.Hide();
                home.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void LoginForm1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }
    }
}