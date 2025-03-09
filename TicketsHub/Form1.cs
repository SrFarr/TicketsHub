using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsHub
{
    public partial class FormLogin: Form
    {
        TicketDbEntities1 db;
        public FormLogin()
        {
            InitializeComponent();
            db = new TicketDbEntities1();
        }
        void set()
        {
            if (airCheckBox1.Checked)
            {
                txtbPw.PasswordChar = '\0';
            }
            else
            {
                txtbPw.PasswordChar = '*';
            }
        }
        void login()
        {
            var usr = txtbEmail.Text.Trim();
            var passwrd = txtbPw.Text.Trim();

            if(string.IsNullOrEmpty(usr) || string.IsNullOrEmpty(passwrd))
            {
                MessageBox.Show("Data harus di isi semua", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
           
            var login = db.admins.FirstOrDefault(x => x.Username == usr && x.password == passwrd);
            if(login != null)
            {
                MainMenu menu = new MainMenu(login.Username);
                MessageBox.Show("Login Berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Akun tidak ditemukan", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {

            btnLogin.PrimaryColor = Color.Blue;
            btnLogin.HoverTextColor = Color.White;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.PrimaryColor = Color.DodgerBlue;

        }

        private void txtbEmail_MouseClick(object sender, MouseEventArgs e)
        {
            txtbEmail.Text = "";
        }

        private void txtbPw_MouseClick(object sender, MouseEventArgs e)
        {
            txtbPw.Text = "";
            txtbPw.PasswordChar = '*';
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            set();
        }

        private void txtbPw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbPw_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void airCheckBox1_CheckedChanged(object sender)
        {
            set();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
