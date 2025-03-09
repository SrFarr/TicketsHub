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
    public partial class FormTicketadm : Form
    {
        TicketDbEntities1 db;
        public FormTicketadm()
        {
            db = new TicketDbEntities1();
            InitializeComponent();
        }

        void set()
        {
            var search = txtbSearch.Text.Trim();
            var grid = db.tickets
                .Join(db.customers,
                    t => t.Id_pelanggan,
                    c => c.Id,
                    (ticket, customers) => new { ticket, customers })
                .Join(db.movies,
                    tc => tc.ticket.Id_film,
                    m => m.Id,
                    (tc, movie) => new { tc, movie })
                .AsEnumerable()
                .Where(x => x.tc.customers.Nama.ToLower().Contains(search))
                .Select((item, index) => new
                {
                    Id = item.tc.ticket.Id,
                    No = index + 1,
                    Nama = item.tc.customers.Nama,
                    Film = item.movie.Judul,
                    Tiket = item.tc.ticket.Jumlah_tiket,
                    Harga = item.tc.ticket.Total_harga,
                    Status = item.tc.ticket.Status_pembayaran
                })
                .ToList();

            datagridviewTc.DataSource = grid;
            if (datagridviewTc.Columns["Id"] != null)
            {
                datagridviewTc.Columns["Id"].Visible = false;
            }
            datagridviewTc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridviewTc.ReadOnly = true;

            if (datagridviewTc.Columns["Action"] == null)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "Hapus",
                    UseColumnTextForButtonValue = true
                };
                datagridviewTc.Columns.Add(btnDelete);
            }
        }

        void LoadFilmList()
        {
            var films = db.movies.Select(m => new { m.Id, m.Judul }).ToList();
            cbFilm.DataSource = films.ToList();
            cbFilm.DisplayMember = "Judul";
            cbFilm.ValueMember = "Id";
        }

        void TambahTiket()
        {
            string namaCustomer = txtbNamaCustomer.Text.Trim();
            int idFilm = Convert.ToInt32(cbFilm.SelectedValue);
            int jumlahTiket = Convert.ToInt32(nudJumlahTiket.Value);
            string statusPembayaran = cbStatusPembayaran.Text.Trim();
            var customer = db.customers.FirstOrDefault(c => c.Nama.ToLower() == namaCustomer.ToLower());
            var movie = db.movies.FirstOrDefault(m => m.Id == idFilm);

            
            if (customer == null)
            {
                MessageBox.Show("Customer tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbStatusPembayaran.Text))
            {
                MessageBox.Show("Status pembayaran harus dipilih!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (movie == null || jumlahTiket > movie.Stok_tiket)
            {
                MessageBox.Show("Stok tiket tidak mencukupi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal hargaTotal = jumlahTiket * movie.Harga_tiket;
            var tiketBaru = new ticket { Id_pelanggan = customer.Id, Id_film = idFilm, Jumlah_tiket = jumlahTiket, Total_harga = hargaTotal, Status_pembayaran = statusPembayaran };
            movie.Stok_tiket -= jumlahTiket;
            db.tickets.Add(tiketBaru);
            db.SaveChanges();
            UpdateTotalHarga();
            set();
            MessageBox.Show("Tiket berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void EditTiket(int idTiket)
        {
            var tiket = db.tickets.FirstOrDefault(t => t.Id == idTiket);
            if (tiket == null)
            {
                MessageBox.Show("Tiket tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idFilm = Convert.ToInt32(cbFilm.SelectedValue);
            int jumlahTiketBaru = Convert.ToInt32(nudJumlahTiket.Value);
            var movie = db.movies.FirstOrDefault(m => m.Id == idFilm);

            if (movie == null || jumlahTiketBaru > movie.Stok_tiket + tiket.Jumlah_tiket)
            {
                MessageBox.Show("Stok tiket tidak mencukupi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            movie.Stok_tiket += tiket.Jumlah_tiket; // Kembalikan stok sebelumnya
            tiket.Jumlah_tiket = jumlahTiketBaru;
            tiket.Total_harga = jumlahTiketBaru * movie.Harga_tiket;
            movie.Stok_tiket -= jumlahTiketBaru;

            db.SaveChanges();
            UpdateTotalHarga();
            set();
            MessageBox.Show("Tiket berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void HapusTiket(int idTiket)
        {
            var tiket = db.tickets.FirstOrDefault(t => t.Id == idTiket);
            if (tiket == null)
            {
                MessageBox.Show("Tiket tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movie = db.movies.FirstOrDefault(m => m.Id == tiket.Id_film);
            if (movie != null)
            {
                movie.Stok_tiket += tiket.Jumlah_tiket; // Kembalikan stok tiket
            }

            db.tickets.Remove(tiket);
            db.SaveChanges();

            MessageBox.Show("Tiket berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            set(); // Refresh DataGridView
        }

        void UpdateTotalHarga()
        {
            decimal totalHarga = db.tickets.Sum(t => t.Total_harga);
            txtbTotalHarga.Text = totalHarga.ToString("N2");
        }

        private void FormTicketadm_Load(object sender, EventArgs e)
        {
            set();
            LoadFilmList();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            TambahTiket();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (datagridviewTc.SelectedRows.Count > 0)
            {
                int idTiket = Convert.ToInt32(datagridviewTc.SelectedRows[0].Cells["Id"].Value);
                EditTiket(idTiket);
            }
            else
            {
                MessageBox.Show("Pilih tiket yang akan diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtbSearch_TextChanged(object sender, EventArgs e)
        {
            set();
        }

        private void datagridviewTc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtbNamaCustomer.Text = datagridviewTc.Rows[e.RowIndex].Cells["Nama"].Value.ToString();
                int idTicket = Convert.ToInt32(datagridviewTc.Rows[e.RowIndex].Cells["Id"].Value);

                var movie = db.movies.FirstOrDefault(m => m.Id == idTicket);
                if (movie != null)
                {
                    cbFilm.SelectedValue = movie.Id;
                    nudJumlahTiket.Value = Convert.ToInt32(datagridviewTc.Rows[e.RowIndex].Cells["Tiket"].Value);
                    txtbTotalHarga.Text = Convert.ToDecimal(datagridviewTc.Rows[e.RowIndex].Cells["Harga"].Value).ToString("N0");
                    UpdateCurrentTotal();
                }
            }
            if (e.RowIndex >= 0 && datagridviewTc.Columns[e.ColumnIndex].Name == "Action")
            {
                int idTiket = Convert.ToInt32(datagridviewTc.Rows[e.RowIndex].Cells["Id"].Value);

                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus tiket ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    HapusTiket(idTiket);
                }
            }
          
        }
        private void UpdateCurrentTotal()
        {
            if (cbFilm.SelectedValue == null)
            {
                txtbTotalHarga.Text = "0";
                return;
            }
            int idFilm = Convert.ToInt32(((dynamic)cbFilm.SelectedItem).Id);



            var movie = db.movies.FirstOrDefault(m => m.Id == idFilm);
            if (movie == null)
            {
                txtbTotalHarga.Text = "0";
                return;
            }

            int jumlahTiket = Convert.ToInt32(nudJumlahTiket.Value);
            decimal total = jumlahTiket * movie.Harga_tiket;
            txtbTotalHarga.Text = total.ToString("N2");
        }
        private void txtbTotalHarga_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void nudJumlahTiket_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentTotal();
        }

        private void cbFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentTotal();
        }

        private void cbStatusPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
