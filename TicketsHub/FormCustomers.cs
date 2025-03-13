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
    public partial class FormCustomers: Form
    {
        readonly TicketDbEntities1 db;
        public FormCustomers()
        {
            InitializeComponent();
            db = new TicketDbEntities1();
        }

        void set()
        {
            var search = txtbSearch.Text;
            var id = db.customers.Select(x => x.Id).AsEnumerable().ToList();
            var grid = db.customers.AsEnumerable().Where(x => x.Nama.Contains(search)).Select((x, index) => new
            {
                x.Id,
                No = index + 1,
                x.Nama,
                x.Nomor_telepon,
                x.Email,
                x.password
            }).ToList();

            datagridviewCs.DataSource = grid;
            datagridviewCs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridviewCs.ReadOnly = true;
            datagridviewCs.Columns["Id"].Visible = false;
            txtbnm.Text = "";
            txtbNoTelp.Text = "";
            txtbemail.Text = "";
            txtbPasswrd.Text = "";
        }
        private void insert()
        {
            if (!string.IsNullOrWhiteSpace(txtbnm.Text) && !string.IsNullOrWhiteSpace(txtbemail.Text) &&
                !string.IsNullOrWhiteSpace(txtbNoTelp.Text) && !string.IsNullOrWhiteSpace(txtbPasswrd.Text))
            {
                var newCustomer = new customer
                {

                    Nama = txtbnm.Text,
                    Email = txtbemail.Text,
                    Nomor_telepon = txtbNoTelp.Text,
                    password = txtbPasswrd.Text
                };
                db.customers.Add(newCustomer);
                db.SaveChanges();
                MessageBox.Show("Customer berhasil ditambahkan.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                set();
            }
            else
            {
                MessageBox.Show("Semua kolom harus diisi.","Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void edit()
        {
            if (datagridviewCs.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datagridviewCs.SelectedRows[0].Cells["Id"].Value);
                var cs = db.customers.FirstOrDefault(x => x.Id == id);

                if (cs != null)
                {
                    cs.Nama = txtbnm.Text;
                    cs.Email = txtbemail.Text;
                    cs.Nomor_telepon = txtbNoTelp.Text;
                    cs.password = txtbPasswrd.Text;

                    db.SaveChanges();
                    MessageBox.Show("Customer berhasil diperbarui.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    set();
                }
            }
            else
            {
                MessageBox.Show("Pilih customer yang ingin diedit.","Exclamation", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void delete()
        {
            if (datagridviewCs.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(datagridviewCs.SelectedRows[0].Cells["Id"].Value);
                var cs = db.customers.FirstOrDefault(x => x.Id == id);

                if (cs != null)
                {
                 
                    bool hasTickets = db.tickets.Any(t => t.Id_pelanggan == id);
                    if (hasTickets)
                    {
                        MessageBox.Show("Customer tidak bisa dihapus karena masih memiliki tiket yang terdaftar.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    db.customers.Remove(cs);
                    db.SaveChanges();
                    MessageBox.Show("Customer berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    set();
                }
            }
            else
            {
                MessageBox.Show("Pilih customer yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            set();
        }

        private void aloneTextBox1_TextChanged(object sender, EventArgs e)
        {
            set();
        }

        private void datagridviewCs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(datagridviewCs.Rows[e.RowIndex].Cells["Id"].Value);
                var cs = db.customers.FirstOrDefault(x => x.Id == id);

                if(cs != null)
                {
                    txtbnm.Text = cs.Nama;
                    txtbemail.Text = cs.Email;
                    txtbNoTelp.Text = cs.Nomor_telepon;
                    txtbPasswrd.Text = cs.password;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            insert();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apakah anda ingin menghapus data ini?", "Exclamation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if(DialogResult == DialogResult.Yes)
            {
                delete();
            }
            
        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
