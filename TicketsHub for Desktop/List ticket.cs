using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TicketsHub_for_Desktop
{
    public partial class List_ticket : Form
    {
        private TicketDbEntities db;
        private string selectedJudul;
        private string selectedGenre;

        public List_ticket(string judul, string genre)
        {
            InitializeComponent();
            db = new TicketDbEntities();
            selectedJudul = judul;
            selectedGenre = genre;
        }

        private void List_ticket_Load(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void LoadMovies()
        {
            var movies = db.movies
                .Where(m => (string.IsNullOrEmpty(selectedJudul) || m.Judul == selectedJudul) &&
                            (string.IsNullOrEmpty(selectedGenre) || m.Genre == selectedGenre))
                .Select(m => new
                {
                    m.Judul,
                    m.Genre,
                    m.Harga_tiket,
                    m.Tanggal_mulai,
                    m.Jam_mulai
                })
                .ToList();

            datagridview.DataSource = movies;

            // Tambahkan tombol "Beli Tiket" jika belum ada
            if (!datagridview.Columns.Contains("BeliTiket"))
            {
                DataGridViewButtonColumn beliButton = new DataGridViewButtonColumn
                {
                    Name = "BeliTiket",
                    HeaderText = "Aksi",
                    Text = "Beli Tiket",
                    UseColumnTextForButtonValue = true
                };
                datagridview.Columns.Add(beliButton);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridview.Columns[e.ColumnIndex].Name == "BeliTiket" && e.RowIndex >= 0)
            {
                string judul = datagridview.Rows[e.RowIndex].Cells["Judul"].Value.ToString();
                string genre = datagridview.Rows[e.RowIndex].Cells["Genre"].Value.ToString();
                decimal harga = Convert.ToDecimal(datagridview.Rows[e.RowIndex].Cells["Harga_tiket"].Value);
                DateTime tanggalMulai = Convert.ToDateTime(datagridview.Rows[e.RowIndex].Cells["Tanggal_mulai"].Value);
                string jamMulai = datagridview.Rows[e.RowIndex].Cells["Jam_mulai"].Value.ToString();

                FormBeliTiket formBeli = new FormBeliTiket(judul, genre, harga, tanggalMulai, jamMulai);
                formBeli.ShowDialog();
            }
        }
    }
}
