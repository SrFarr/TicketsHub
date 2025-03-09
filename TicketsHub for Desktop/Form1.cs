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
    public partial class Form1: Form
    {
        readonly TicketDbEntities db;
        FormLogin login;
        public Form1()
        {
            InitializeComponent();
            db = new TicketDbEntities();
            login = new FormLogin();
        }
        void regist()
        {
           
            customer cs = new customer();

            if(string.IsNullOrEmpty(txtbNama.Text) ||
                string.IsNullOrEmpty(txtbEmail.Text) ||
                string.IsNullOrEmpty(txtbNoTelp.Text) ||
                string.IsNullOrEmpty(txtbPassword.Text) ||
                string.IsNullOrEmpty(txtbConfirmpw.Text))
            {
                MessageBox.Show("Data harus di isi semua!");
                return;
            }

            if (!txtbConfirmpw.Text.Equals(txtbPassword.Text))
            {
                MessageBox.Show("Kata sandi harus sama harus sama!", "Peringatan",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            cs.Nama = txtbNama.Text.Trim();
            cs.Email = txtbEmail.Text.Trim();
            cs.Nomor_telepon = txtbNoTelp.Text.Trim();
            cs.password = txtbPassword.Text.Trim();

            db.customers.Add(cs);
            db.SaveChanges();
            MessageBox.Show("Berhasil Daftar!", "Informasi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            login.Show();
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login.Show();
            this.Hide();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            regist();
        }

        private void airCheckBox1_CheckedChanged(object sender)
        {
            if (airCheckBox1.Checked)
            {
                txtbPassword.PasswordChar = '\0';
                txtbConfirmpw.PasswordChar = '\0';
            }
            else
            {
                txtbPassword.PasswordChar = '*';
                txtbConfirmpw.PasswordChar = '*';

            }
        }
    }
}
