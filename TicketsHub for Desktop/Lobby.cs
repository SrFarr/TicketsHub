using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TicketsHub_for_Desktop
{
    public partial class Lobby : Form
    {
        readonly private TicketDbEntities1 db;
        readonly private string nm;
        private int id;
        private bool isUpdating = false; // Untuk mencegah event recursive

        public Lobby(int id,string nama)
        {
            InitializeComponent();
            db = new TicketDbEntities1();
            this.id = id;
            nm = nama;
            bigLabel1.Text = $"Halo, {nm}!";
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            LoadGenres(); // Load semua genre
            LoadMovies();  // Load semua film
        }

        private void LoadMovies(string genre = null)
        {
            isUpdating = true;

            var movies = string.IsNullOrEmpty(genre)
                ? db.movies.Select(x => x.Judul).Distinct().ToList()
                : db.movies.Where(x => x.Genre == genre).Select(x => x.Judul).Distinct().ToList();

            movies.Insert(0, ""); // Tambahkan opsi None di awal

            cbJudul.DataSource = new List<string>(movies);
            cbJudul.SelectedIndex = 0; // Pilih None sebagai default

            AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(movies.ToArray());
            cbJudul.AutoCompleteCustomSource = autoCompleteData;

            isUpdating = false;
        }

        private void LoadGenres(string judul = null)
        {
            isUpdating = true;

            var genres = db.movies.Select(x => x.Genre).Distinct().ToList();
            string selectedGenre = null;

            if (!string.IsNullOrEmpty(judul))
            {
                selectedGenre = db.movies
                    .Where(x => x.Judul == judul)
                    .Select(x => x.Genre)
                    .FirstOrDefault();

                genres = new List<string> { selectedGenre };
            }
            else
            {
                genres.Insert(0, ""); // Tambahkan opsi None di awal
            }

            cbGenre.DataSource = genres;
            cbGenre.SelectedIndex = 0; // Pilih None sebagai default

            isUpdating = false;
        }

        private void cbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            string selectedGenre = cbGenre.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedGenre))
            {
                LoadMovies(); // Jika genre kosong, tampilkan semua film
            }
            else
            {
                LoadMovies(selectedGenre); // Filter judul berdasarkan genre
            }
        }

        private void cbJudul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            string selectedJudul = cbJudul.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedJudul))
            {
                LoadGenres(); // Jika judul kosong, tampilkan semua genre
            }
            else
            {
                LoadGenres(selectedJudul); // Tampilkan genre sesuai judul
            }
        }

        private void btnCariFIlm_Click(object sender, EventArgs e)
        {

            string selectedJudul = cbJudul.SelectedItem?.ToString();
            string selectedGenre = cbGenre.SelectedItem?.ToString();
            DateTime tanggalMulai = dateTanggal_mulai.Value;
            int jumlahTiket = Convert.ToInt32(numJumlahTiket.Value);

            // Pastikan pengguna memilih minimal genre atau judul
            if (string.IsNullOrEmpty(selectedJudul) && string.IsNullOrEmpty(selectedGenre))
            {
                MessageBox.Show("Pastikan Anda memilih minimal genre atau judul!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (jumlahTiket <= 0)
            {
                MessageBox.Show("Pastikan jumlah tiket lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query database berdasarkan genre dan/atau judul
            var query = db.movies.AsQueryable();
            var user = db.customers.FirstOrDefault(x => x.Nama == nm);
            if (user == null)
            {
                MessageBox.Show("Data user tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nama = user.Nama;
            var email = user.Email;
            if (!string.IsNullOrEmpty(selectedGenre))
            {
                query = query.Where(x => x.Genre == selectedGenre);
            }

            if (!string.IsNullOrEmpty(selectedJudul))
            {
                query = query.Where(x => x.Judul == selectedJudul);
            }

            // Pastikan ada film yang tersedia setelah tanggal mulai yang dipilih
            var filmAda = query.Any(x => x.Tanggal_mulai >= tanggalMulai);

            if (!filmAda)
            {
                MessageBox.Show("Tidak ada film yang tayang setelah tanggal yang dipilih.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Panggil form List_ticket dengan parameter
            List_ticket listTicketForm = new List_ticket(id,nama,email,selectedJudul, selectedGenre, tanggalMulai,jumlahTiket);
            listTicketForm.ShowDialog();
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
