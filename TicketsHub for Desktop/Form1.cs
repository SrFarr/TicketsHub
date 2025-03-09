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
        public Form1()
        {
            InitializeComponent();
        }
        void regist()
        {
            /*FormLogin login = new FormLogin();
            customer customer = new customer();
            var nm = txtbNM.Text.Trim();
            var email = txtbEmail.Text.Trim();
            var telp = txtbTelp.Text.Trim();
            var pass = txtbPass.Text.Trim();
            
            if (string.IsNullOrEmpty(nm) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(telp) ||
                string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Data Harus di Isi semua!");
            }
            else
            {
                if (!email.Contains("@"))
                {
                    MessageBox.Show("Format Email Harus Benar!");
                    return;
                }
                if (pass.Length < 3)
                {
                    MessageBox.Show("Password harus lebih dari 3 karakter");
                    return;
                }
                customer.Nama = nm;
                customer.Email = email;
                customer.Nomor_telepon = telp;
                customer.password = pass;
                db.customers.Add(customer);
                db.SaveChanges();
                MessageBox.Show("Berhasil Register !");
                login.Show();
                this.Close();
            }

            */
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
