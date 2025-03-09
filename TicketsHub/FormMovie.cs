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
    public partial class FormMovie: Form
    {
        readonly TicketDbEntities1 db;
        int selectedMovieId = -1;

        void LoadGenres()
        {
            var genres = db.movies.Select(x => x.Genre).Distinct().ToList();
            genres.Insert(0, "None");
            cmbxGenre.DataSource = new List<string>(genres);
            comboboxgenre.DataSource = new List<string>(genres);
        }

        void LoadMovies()
        {
            try
            {
                string selectedGenre = cmbxGenre.SelectedItem?.ToString();
                string searchText = txtbSearch.Text.ToLower();
                var movies = db.movies.AsQueryable();

                if (!string.IsNullOrEmpty(selectedGenre) && selectedGenre != "None")
                    movies = movies.Where(x => x.Genre == selectedGenre);

                if (!string.IsNullOrEmpty(searchText))
                    movies = movies.Where(x => x.Judul.ToLower().Contains(searchText));

                var movieList = movies.Select(x => new
                {
                    x.Id,
                    x.Judul,
                    x.Genre,
                    x.Harga_tiket,
                    x.Stok_tiket,
                    x.Jam_mulai,
                    x.Tanggal_mulai
                }).ToList();

                dataGridView1.DataSource = movieList.Select((x, index) => new
                {
                    No = index + 1,
                    x.Id,
                    x.Judul,
                    x.Genre,
                    x.Harga_tiket,
                    x.Stok_tiket,
                    x.Jam_mulai,
                    x.Tanggal_mulai
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["Id"].Visible = false;

                AddDeleteButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddDeleteButton()
        {
            if (dataGridView1.Columns["Action"] == null)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "Hapus",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnDelete);
            }
        }

        void SaveMovie()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtbJudul.Text) || string.IsNullOrWhiteSpace(txtbHargaTiket.Text))
                {
                    MessageBox.Show("Mohon lengkapi data terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtbHargaTiket.Text, out decimal harga))
                {
                    MessageBox.Show("Harga tiket harus berupa angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedMovieId == -1)
                {
                    var newMovie = new movy
                    {
                        Judul = txtbJudul.Text.Trim(),
                        Genre = cmbxGenre.Text,
                        Harga_tiket = harga,
                        Stok_tiket = (int)numericStockTiket.Value,
                        Jam_mulai = jam_mulai.Value.TimeOfDay,
                        Tanggal_mulai = tanggal_mulai.Value
                    };
                    db.movies.Add(newMovie);
                }
                else
                {
                    var movieToUpdate = db.movies.FirstOrDefault(x => x.Id == selectedMovieId);
                    if (movieToUpdate != null)
                    {
                        movieToUpdate.Judul = txtbJudul.Text.Trim();
                        movieToUpdate.Genre = cmbxGenre.Text;
                        movieToUpdate.Harga_tiket = harga;
                        movieToUpdate.Stok_tiket = (int)numericStockTiket.Value;
                        movieToUpdate.Jam_mulai = jam_mulai.Value.TimeOfDay;
                        movieToUpdate.Tanggal_mulai = tanggal_mulai.Value;
                    }
                }
                db.SaveChanges();
                LoadMovies();
                ClearForm();
                MessageBox.Show("Data berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DeleteMovie(int id)
        {
            try
            {
                var movieToDelete = db.movies.FirstOrDefault(x => x.Id == id);
                if (movieToDelete != null)
                {
                    db.movies.Remove(movieToDelete);
                    db.SaveChanges();
                    LoadMovies();
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ClearForm()
        {
            txtbJudul.Clear();
            comboboxgenre.SelectedIndex = 0;
            txtbHargaTiket.Clear();
            numericStockTiket.Value = 0;
            jam_mulai.Value = DateTime.Now;
            tanggal_mulai.Value = DateTime.Now;
            selectedMovieId = -1;
        }


        public FormMovie()
        {
            InitializeComponent();
            db = new TicketDbEntities1();
        }

        private void FormMovie_Load(object sender, EventArgs e)
        {
            LoadGenres();

            LoadMovies();

        }

        private void txtbSearch_TextChanged(object sender, EventArgs e) => LoadMovies();

        private void cmbxGenre_SelectedIndexChanged(object sender, EventArgs e) => LoadMovies();

        private void btnTambah_Click(object sender, EventArgs e) => SaveMovie();

        private void btnEdit_Click(object sender, EventArgs e) => SaveMovie();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                var confirm = MessageBox.Show("Apakah kamu yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    DeleteMovie(id);
                }
            }
            if (e.RowIndex >= 0)
            {
                selectedMovieId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                var movie = db.movies.FirstOrDefault(x => x.Id == selectedMovieId);
                if (movie != null)
                {
                    txtbJudul.Text = movie.Judul;
                    comboboxgenre.SelectedItem = movie.Genre;
                    txtbHargaTiket.Text = movie.Harga_tiket.ToString();
                    numericStockTiket.Value = Math.Min(numericStockTiket.Maximum, Math.Max(numericStockTiket.Minimum, movie.Stok_tiket));
                    jam_mulai.Value = DateTime.Today + movie.Jam_mulai;
                    tanggal_mulai.Value = (DateTime)movie.Tanggal_mulai;
                }
            }

        }
    }
}
