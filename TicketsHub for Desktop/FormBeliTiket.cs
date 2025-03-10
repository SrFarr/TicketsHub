using System;
using System.Collections.Generic;
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
        int tiket,id,idFilm;
        TicketDbEntities1 db;
        public FormBeliTiket(int id, int idFilm, string nama, string email, string judul, string genre, double hargaPerTiket, DateTime tanggalMulai, string jamMulai, int tiket)
        {
            InitializeComponent();
            db = new TicketDbEntities1();
            this.id = id;
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
        void Belitiket()
        {
            if (string.IsNullOrEmpty(txtbUang.Text) || !double.TryParse(txtbUang.Text, out double uangDiberikan))
            {
                MessageBox.Show("Masukkan jumlah uang yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ambil harga tiket dari label (karena bisa berubah jika pakai promo)
            double totalHarga = harga * tiket;
            if (double.TryParse(lblHarga.Text, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("id-ID"), out double hargaAkhir))
            {
                totalHarga = hargaAkhir; // Jika harga berubah karena promo, pakai yang terbaru
            }

            // Validasi apakah uang cukup
            if (uangDiberikan < totalHarga)
            {
                MessageBox.Show($"Uang tidak cukup! Kurang {totalHarga - uangDiberikan}", "Pembayaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double kembalian = uangDiberikan - totalHarga;
                var statusPembayaran = "Lunas";
                ticket ticket = new ticket();
                ticket.Id_pelanggan = id;
                ticket.Id_film = idFilm;
                decimal hargaakhir;
                if (decimal.TryParse(lblHarga.Text, System.Globalization.NumberStyles.Currency,
                    new System.Globalization.CultureInfo("id-ID"), out hargaakhir))
                {
                    ticket.Total_harga = hargaakhir; // Konversi ke int jika memang harus
                }
                else
                {
                    MessageBox.Show("Gagal mengonversi harga tiket!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                ticket.Status_pembayaran = statusPembayaran;
                
                db.tickets.Add(ticket);
                db.SaveChanges();
                MessageBox.Show($"Tiket berhasil dibeli!\nKembalian Anda: {kembalian}", "Pembelian Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); 
            }
          
        }
        private void FormBeliTiket_Load(object sender, EventArgs e)
        {
          
            int hargaLength = lblHarga.Width;
            btnBeli.Width = 268 + hargaLength;
            // Menampilkan informasi tiket di form saat form dibuka
            lblJudul.Text = "Nama Film: " + judul;
            lblGenre.Text = "Genre: " + genre;
            lblNama.Text = "Nama: " + nama;
            lblEmail.Text = "Email: " + email;
            lblTanggalMulai.Text = "Tanggal Mulai: " + tanggalMulai.ToString("dd MMM yyyy");
            lblJamMulai.Text = "Jam Mulai: " + jamMulai;
            lbltiket.Text = $"{tiket} Tiket";
            lblKarcis.Text = $"{judul} -> {genre}";
        }

       
        private void btnBeli_Click(object sender, EventArgs e)
        {
            Belitiket();  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblHarga_Click(object sender, EventArgs e)
        {

        }

        private void txtbPromo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbPromo.Text))
            {
                double totalHarga = harga * tiket;
                lblHarga.Text = totalHarga.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPromo_Click(object sender, EventArgs e)
        {
            if (tiket <= 3)
            {
                MessageBox.Show("Kode promo hanya berlaku jika membeli lebih dari 3 tiket!", "Promo Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Daftar kode promo dan diskonnya
            var promoCodes = new Dictionary<string, int>()
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
                double totalHarga = harga * tiket; // Total harga sebelum diskon
                double diskon = totalHarga * diskonPersen / 100; // Menghitung diskon
                double hargaSetelahDiskon = totalHarga - diskon; // Menghitung harga setelah diskon

                // Update label harga dengan harga setelah diskon
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
