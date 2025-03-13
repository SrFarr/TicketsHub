using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TicketsHub_for_Desktop
{
    public partial class List_ticket : Form
    {
        private TicketDbEntities1 db;
        private readonly string selectedJudul;
        private readonly string selectedGenre;
        private readonly DateTime tanggalMulai;
        private string nama;
        private string email;
        private int jumlahTiket, idUser ;
        private int idtiket = 0;
        public List_ticket(int idUser, string nama, string email, string judul, string genre, DateTime tanggal, int tiket)
        {
            InitializeComponent();
            db = new TicketDbEntities1();
            this.idUser = idUser;
     
            this.nama = nama;
            this.email = email;
            selectedJudul = judul;
            selectedGenre = genre;
            tanggalMulai = tanggal;
            jumlahTiket = tiket; // Menyimpan jumlah tiket
            this.Load += new System.EventHandler(this.List_ticket_Load);

       
        }

        private void List_ticket_Load(object sender, EventArgs e)
        {
           
            LoadMovies();
        }

        private void LoadMovies()
        {
            if (!db.movies.Any())
            {
                MessageBox.Show("Database film kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var moviesQuery = db.movies.AsQueryable();

            if (!string.IsNullOrEmpty(selectedJudul))
            {
                moviesQuery = moviesQuery.Where(m => m.Judul.Equals(selectedJudul, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(selectedGenre))
            {
                moviesQuery = moviesQuery.Where(m => m.Genre.Equals(selectedGenre, StringComparison.OrdinalIgnoreCase));
            }

            moviesQuery = moviesQuery.Where(m => m.Tanggal_mulai >= tanggalMulai);

            var movies = moviesQuery.Select(m => new
            {
                m.Id,
                m.Judul,
                m.Genre,
                m.Harga_tiket,
                m.Tanggal_mulai,
                m.Jam_mulai
            }).ToList();

            if (!movies.Any())
            {
                MessageBox.Show("Tidak ada film yang sesuai filter.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            datagridview.DataSource = movies;
            datagridview.Columns["Id"].Visible = false;
           
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!datagridview.Columns.Cast<DataGridViewColumn>().Any(c => c.Name == "BeliTiket"))
            {
                DataGridViewButtonColumn beliTiketColumn = new DataGridViewButtonColumn
                {
                    Name = "BeliTiket",
                    HeaderText = "Beli Tiket",
                    Text = "Beli",
                    UseColumnTextForButtonValue = true
                };
                datagridview.Columns.Add(beliTiketColumn);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Lobby lobby = new Lobby(idUser,nama);
            lobby.Show();
            this.Hide();
        }

        private void ApplyFilter()
        {
            // Aktifkan semua checkbox terlebih dahulu
            checkHargaTertinggi.Enabled = true;
            checkHagaTerendah.Enabled = true;
            checkZA.Enabled = true;
            checkAZ.Enabled = true;
            check06.Enabled = true;
            check612.Enabled = true;
            check1218.Enabled = true;
            check1824.Enabled = true;

            TimeSpan start06 = new TimeSpan(0, 0, 0);
            TimeSpan end06 = new TimeSpan(5, 59, 59);
            TimeSpan start612 = new TimeSpan(6, 0, 0);
            TimeSpan end612 = new TimeSpan(11, 59, 59);
            TimeSpan start1218 = new TimeSpan(12, 0, 0);
            TimeSpan end1218 = new TimeSpan(17, 59, 59);
            TimeSpan start1824 = new TimeSpan(18, 0, 0);
            TimeSpan end1824 = new TimeSpan(23, 59, 59);

            if (!db.movies.Any())
            {
                MessageBox.Show("Database film kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var moviesQuery = db.movies.AsQueryable();

            // Filter berdasarkan judul dan genre
            if (!string.IsNullOrEmpty(selectedJudul))
            {
                moviesQuery = moviesQuery.Where(m => m.Judul.Equals(selectedJudul, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(selectedGenre))
            {
                moviesQuery = moviesQuery.Where(m => m.Genre.Equals(selectedGenre, StringComparison.OrdinalIgnoreCase));
            }
            moviesQuery = moviesQuery.Where(m => m.Tanggal_mulai >= tanggalMulai);

            // Sorting berdasarkan harga
            if (checkHargaTertinggi.Checked)
            {
                checkHagaTerendah.Enabled = false; // Nonaktifkan checkbox terendah jika tertinggi aktif
                moviesQuery = moviesQuery.OrderByDescending(m => m.Harga_tiket);
            }
            else if (checkHagaTerendah.Checked)
            {
                checkHargaTertinggi.Enabled = false; // Nonaktifkan checkbox tertinggi jika terendah aktif
                moviesQuery = moviesQuery.OrderBy(m => m.Harga_tiket);
            }

            // Sorting berdasarkan abjad
            if (checkZA.Checked)
            {
                checkAZ.Enabled = false; // Nonaktifkan AZ jika ZA aktif
                moviesQuery = moviesQuery.OrderByDescending(m => m.Judul);
            }
            else if (checkAZ.Checked)
            {
                checkZA.Enabled = false; // Nonaktifkan ZA jika AZ aktif
                moviesQuery = moviesQuery.OrderBy(m => m.Judul);
            }

            // Filter berdasarkan jam tayang
            if (check06.Checked)
            {
                check612.Enabled = false;
                check1218.Enabled = false;
                check1824.Enabled = false;
                moviesQuery = moviesQuery.Where(m => m.Jam_mulai >= start06 && m.Jam_mulai < end06);
            }
            else if (check612.Checked)
            {
                check06.Enabled = false;
                check1218.Enabled = false;
                check1824.Enabled = false;
                moviesQuery = moviesQuery.Where(m => m.Jam_mulai >= start612 && m.Jam_mulai < end612);
            }
            else if (check1218.Checked)
            {
                check06.Enabled = false;
                check612.Enabled = false;
                check1824.Enabled = false;
                moviesQuery = moviesQuery.Where(m => m.Jam_mulai >= start1218 && m.Jam_mulai < end1218);
            }
            else if (check1824.Checked)
            {
                check06.Enabled = false;
                check612.Enabled = false;
                check1218.Enabled = false;
                moviesQuery = moviesQuery.Where(m => m.Jam_mulai >= start1824 && m.Jam_mulai < end1824);
            }

            // Ambil data hasil query
            var movies = moviesQuery.Select(m => new
            {
                m.Id,
                m.Judul,
                m.Genre,
                m.Harga_tiket,
                m.Tanggal_mulai,
                m.Jam_mulai
            }).ToList();

            if (!movies.Any())
            {
                MessageBox.Show("Tidak ada film yang sesuai filter.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tampilkan data di DataGridView
            datagridview.DataSource = movies;
        }
        private void checkHargaTertinggi_CheckedChanged(object sender, EventArgs e)
        {

            if (checkHargaTertinggi.Checked)
            {
                checkHagaTerendah.Checked = false; // Pastikan hanya satu checkbox harga yang aktif
            }
            ApplyFilter();
        }

        private void checkHagaTerendah_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHagaTerendah.Checked)
            {
                checkHargaTertinggi.Checked = false; // Pastikan hanya satu checkbox harga yang aktif
            }
            ApplyFilter();
        }

        private void checkZA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkZA.Checked)
            {
                checkAZ.Checked = false; // Pastikan hanya satu checkbox abjad yang aktif
            }
            ApplyFilter();
        }

        private void checkAZ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAZ.Checked)
            {
                checkZA.Checked = false; // Pastikan hanya satu checkbox abjad yang aktif
            }
            ApplyFilter();
        }

        private void check06_CheckedChanged(object sender, EventArgs e)
        {
            if (check06.Checked)
            {
                check612.Checked = false;
                check1218.Checked = false;
                check1824.Checked = false; // Pastikan hanya satu checkbox jam yang aktif
            }
            ApplyFilter();
        }

        private void check612_CheckedChanged(object sender, EventArgs e)
        {

            if (check612.Checked)
            {
                check06.Checked = false;
                check1218.Checked = false;
                check1824.Checked = false; // Pastikan hanya satu checkbox jam yang aktif
            }
            ApplyFilter();
        }

        private void check1218_CheckedChanged(object sender, EventArgs e)
        {
            if (check1218.Checked)
            {
                check06.Checked = false;
                check612.Checked = false;
                check1824.Checked = false; // Pastikan hanya satu checkbox jam yang aktif
            }
            ApplyFilter();
        }

        private void check1824_CheckedChanged(object sender, EventArgs e)
        {
            if (check1824.Checked)
            {
                check06.Checked = false;
                check612.Checked = false;
                check1218.Checked = false; // Pastikan hanya satu checkbox jam yang aktif
            }
            ApplyFilter();
        }

        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Memeriksa apakah klik terjadi pada tombol "Beli Tiket"
            if (e.RowIndex >= 0 && datagridview.Columns[e.ColumnIndex].Name == "BeliTiket")
            {
                string judul = datagridview.Rows[e.RowIndex].Cells["Judul"].Value.ToString();
                string genre = datagridview.Rows[e.RowIndex].Cells["Genre"].Value.ToString();
                double hargaPerTiket = Convert.ToDouble(datagridview.Rows[e.RowIndex].Cells["Harga_tiket"].Value);
                DateTime tanggal = Convert.ToDateTime(datagridview.Rows[e.RowIndex].Cells["Tanggal_mulai"].Value);
                string jam = datagridview.Rows[e.RowIndex].Cells["Jam_mulai"].Value.ToString();
                int idFilm = Convert.ToInt32(datagridview.Rows[e.RowIndex].Cells["Id"].Value);
                // Pastikan jumlah tiket tidak 0 atau negatif
                if (jumlahTiket <= 0)
                {
                    MessageBox.Show("Jumlah tiket harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Membuka form pembelian tiket
                FormBeliTiket formBeli = new FormBeliTiket(idtiket,idUser,idFilm, nama.ToString(),email.ToString(),judul, genre, hargaPerTiket, tanggal, jam, jumlahTiket);
                formBeli.Show();
                this.Hide();
            }
        }
    }
}
