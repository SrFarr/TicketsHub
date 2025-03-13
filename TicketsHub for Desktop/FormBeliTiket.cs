using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicketsHub_for_Desktop
{
    public partial class FormBeliTiket : Form
    {
        private string judul;
        private string genre;
        private double harga;
        private string nama;
        private string email;
        private DateTime tanggalMulai;
        private string jamMulai;
        int tiket, id, idFilm, idTiket;
        TicketDbEntities1 db;

        public FormBeliTiket(int idTiket, int id, int idFilm, string nama, string email, string judul, string genre, double hargaPerTiket, DateTime tanggalMulai, string jamMulai, int tiket)
        {
            InitializeComponent();
            db = new TicketDbEntities1();
            this.id = id;
            this.idTiket = idTiket;
            this.idFilm = idFilm;
            this.nama = nama;
            this.email = email;
            this.judul = judul;
            this.genre = genre;
            this.harga = hargaPerTiket;
            this.tanggalMulai = tanggalMulai;
            this.jamMulai = jamMulai;
            this.tiket = tiket;

            double totalHarga = hargaPerTiket * tiket;
            lblHarga.Text = totalHarga.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
        }

        void Belitiket(string statusPembayaran)
        {

            TiketSaya mytiket;

            double totalHarga = harga * tiket;
            if (double.TryParse(lblHarga.Text, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("id-ID"), out double hargaAkhir))
            {
                totalHarga = hargaAkhir;
            }

            if(idTiket > 0)
            {
                var tiketdb = db.tickets.FirstOrDefault(x => x.Id == idTiket && x.Id_pelanggan == id);
                if(tiketdb != null)
                {
                    tiketdb.Status_pembayaran = statusPembayaran;
                    db.SaveChanges();
                    MessageBox.Show("Pembayaran berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    using (mytiket = new TiketSaya(id, nama))
                    {
                        mytiket.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tiket tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                var pelanggan = db.customers.FirstOrDefault(c => c.Id == id);
                if (pelanggan == null)
                {
                    MessageBox.Show("Pelanggan tidak ditemukan! Harap daftar terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ticket tiketBaru = new ticket
                {
                    Id_pelanggan = id,
                    Id_film = idFilm,
                    Jumlah_tiket = tiket,
                    Status_pembayaran = statusPembayaran,
                    Total_harga = (decimal)totalHarga
                };

                db.tickets.Add(tiketBaru);
                db.SaveChanges();
                MessageBox.Show("Tiket berhasil dibeli! Selamat menikmati film.", "Pembelian Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                using (mytiket = new TiketSaya(id, nama))
                {
                    mytiket.ShowDialog();
                }
                this.Close();
            }
        }

        private void btnBeli_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbUang.Text) || !double.TryParse(txtbUang.Text, out double uangDiberikan))
            {
                MessageBox.Show("Masukkan jumlah uang yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double totalHarga = harga * tiket;
            if (double.TryParse(lblHarga.Text, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("id-ID"), out double hargaAkhir))
            {
                totalHarga = hargaAkhir;
            }

            if (uangDiberikan < totalHarga)
            {
                MessageBox.Show($"Uang tidak cukup! Kurang {totalHarga - uangDiberikan}", "Pembayaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double kembalian = uangDiberikan - totalHarga;
                MessageBox.Show($"Tiket berhasil dibeli!\nKembalian Anda: {kembalian}", "Pembelian Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Belitiket("Lunas");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            List_ticket listtiket = new List_ticket(id,nama,email,judul,genre,tanggalMulai,tiket);
            listtiket.Show();
            this.Hide();
        }

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void btnBayarNanti_Click(object sender, EventArgs e)
        {
            Belitiket("Belum Lunas");
        }

        private void FormBeliTiket_Load(object sender, EventArgs e)
        {
            lblJudul.Text = "Nama Film: " + judul;
            lblGenre.Text = "Genre: " + genre;
            lblNama.Text = "Nama: " + nama;
            lblEmail.Text = "Email: " + email;
            lblTanggalMulai.Text = "Tanggal Mulai: " + tanggalMulai.ToString("dd MMM yyyy");
            lblJamMulai.Text = "Jam Mulai: " + jamMulai;
            lbltiket.Text = $"{tiket} Tiket";
            lblKarcis.Text = $"{judul} -> {genre}";
        }

        private void btnPromo_Click(object sender, EventArgs e)
        {
            if (tiket <= 3)
            {
                MessageBox.Show("Kode promo hanya berlaku jika membeli lebih dari 3 tiket!", "Promo Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var promoCodes = new Dictionary<string, int>
            {
                {"HUGACOR", 10},
                {"FARRKECE", 15},
                {"FILM20", 20},
                {"TIX25", 25},
                {"MOVIE30", 30},
                {"HAPPYHOUR5", 5},
                {"WEEKEND12", 12},
                {"DISKON50", 50},
                {"SPECIAL8", 8},
                {"TIKETHEMAT50", 50}
            };

            string inputPromo = txtbPromo.Text.ToUpper();

            if (promoCodes.ContainsKey(inputPromo))
            {
                int diskonPersen = promoCodes[inputPromo];
                double totalHarga = harga * tiket;
                double diskon = totalHarga * diskonPersen / 100;
                double hargaSetelahDiskon = totalHarga - diskon;

                lblHarga.Text = hargaSetelahDiskon.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
                MessageBox.Show($"Kode promo diterapkan! Diskon {diskonPersen}%", "Promo Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kode promo tidak valid!", "Promo Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
