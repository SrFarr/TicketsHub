using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsHub_for_Desktop
{
    public partial class FormLogin: Form
    {
        Lobby lobby;
        TicketDbEntities1 db;
        public FormLogin()
        {
            InitializeComponent();
            db = new TicketDbEntities1();
        
        }
        void login()
        {
            var email = txtbEmail.Text;
            var pw = txtbPassword.Text;

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pw))
            {
                MessageBox.Show("Data harus terisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Format email harus benar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            var data = db.customers.FirstOrDefault(x => x.Email == email && x.password == pw);

            if(data != null)
            {
                MessageBox.Show("Welcome, " + data.Nama, "Information");
                lobby = new Lobby(data.Nama);
                lobby.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Akun tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbPassword.PasswordChar = '\0';
            }
            else
            {
                txtbPassword.PasswordChar = '*';
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 regist = new Form1();
            regist.ShowDialog();

        }
    }
}
