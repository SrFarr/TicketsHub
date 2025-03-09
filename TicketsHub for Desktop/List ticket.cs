using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TicketsHub_for_Desktop
{
    public partial class List_ticket : Form
    {
        readonly private TicketDbEntities1 db;
        readonly private string selectedJudul;
        readonly private string selectedGenre;
        readonly private DateTime tanggalMulai; // Tambahkan variabel tanggal

        public List_ticket(string judul, string genre, DateTime tanggal)
        {
            InitializeComponent();
            db = new TicketDbEntities1();
            selectedJudul = judul;
            selectedGenre = genre;
            tanggalMulai = tanggal; // Simpan tanggal
            this.Load += new System.EventHandler(this.List_ticket_Load);

        }

        private void List_ticket_Load(object sender, EventArgs e)
        {
                 LoadMovies();
        }

        private void LoadMovies()
        {
            var totalMovies = db.movies.Count();
            if (totalMovies == 0)
            {
                MessageBox.Show("Database film kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movies = db.movies
                .Where(m => (string.IsNullOrEmpty(selectedJudul) || m.Judul.ToLower() == selectedJudul.ToLower()) &&
                            (string.IsNullOrEmpty(selectedGenre) || m.Genre.ToLower() == selectedGenre.ToLower()) &&
                            m.Tanggal_mulai >= tanggalMulai)
                .Select(m => new
                {
                    m.Judul,
                    m.Genre,
                    m.Harga_tiket,
                    m.Tanggal_mulai,
                    m.Jam_mulai
                })
                .ToList();

            if (movies.Count == 0)
            {
                MessageBox.Show("Tidak ada film yang sesuai filter.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            datagridview.DataSource = movies;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if (e.RowIndex >= 0 && datagridview.Columns[e.ColumnIndex].Name == "BeliTiket")
            {
                string judul = datagridview.Rows[e.RowIndex].Cells["Judul"].Value.ToString();
                string genre = datagridview.Rows[e.RowIndex].Cells["Genre"].Value.ToString();
                decimal harga = Convert.ToDecimal(datagridview.Rows[e.RowIndex].Cells["Harga_tiket"].Value);
                DateTime tanggal = Convert.ToDateTime(datagridview.Rows[e.RowIndex].Cells["Tanggal_mulai"].Value);
                string jam = datagridview.Rows[e.RowIndex].Cells["Jam_mulai"].Value.ToString();

                FormBeliTiket formBeli = new FormBeliTiket(judul, genre, harga, tanggal, jam);
                formBeli.ShowDialog();
            }
*/        }

        private void datagridview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
