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
    public partial class TiketSaya : Form
    {
        int iduser;
        string nama;
        TicketDbEntities1 db;

        public TiketSaya(int iduser, string nm)
        {
            InitializeComponent();
            db = new TicketDbEntities1();
            this.iduser = iduser;
            nama = nm;
            SetDataSource();
        }

        void SetDataSource()
        {
            try
            {
                var grid = db.tickets.Join(db.customers,
                                        t => t.Id_pelanggan,
                                        c => c.Id,
                                        (t, c) => new { t, c })
                                      .Join(db.movies,
                                        tc => tc.t.Id_film,
                                        m => m.Id,
                                        (tc, m) => new { tc, m })
                                      .AsEnumerable()
                                      .Where(x => x.tc.t.Id_pelanggan == iduser)
                                      .Select(item => new
                                      {
                                          item.tc.t.Id,
                                          item.tc.t.Id_film,
                                          item.tc.c.Nama,
                                          item.tc.c.Email,
                                          item.m.Judul,
                                          item.m.Genre,
                                          item.m.Tanggal_mulai,
                                          item.m.Jam_mulai,
                                          item.m.Harga_tiket,
                                          item.tc.t.Jumlah_tiket,
                                          item.tc.t.Status_pembayaran
                                      }).ToList();

                dataGridView1.DataSource = grid;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name != "Judul" && column.Name != "Genre" && column.Name != "Tanggal_mulai" && column.Name != "Jam_mulai" && column.Name != "Status_pembayaran" && column.Name != "Action")
                    {
                        column.Visible = false;
                    }
                }

                // Tambahkan tombol "Bayar" jika belum ada
                if (!dataGridView1.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn bayarButton = new DataGridViewButtonColumn();
                    bayarButton.Name = "Action";
                    bayarButton.Text = "Bayar";
                    bayarButton.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(bayarButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TiketSaya_Load(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Lobby loby = new Lobby(iduser, nama);
            loby.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                string statusPembayaran = dataGridView1.Rows[e.RowIndex].Cells["Status_pembayaran"].Value.ToString();

                if (statusPembayaran == "Belum Lunas")
                {
                    // Ambil data dari DataGridView
                    int idTiket = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    int idFilm = (int)dataGridView1.Rows[e.RowIndex].Cells["Id_film"].Value;
                    string nama = dataGridView1.Rows[e.RowIndex].Cells["Nama"].Value.ToString();
                    string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    string judul = dataGridView1.Rows[e.RowIndex].Cells["Judul"].Value.ToString();
                    string genre = dataGridView1.Rows[e.RowIndex].Cells["Genre"].Value.ToString();
                    double hargaPerTiket = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Harga_tiket"].Value);
                    DateTime tanggalMulai = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["Tanggal_mulai"].Value;
                    string jamMulai = dataGridView1.Rows[e.RowIndex].Cells["Jam_mulai"].Value.ToString();
                    int jumlahTiket = (int)dataGridView1.Rows[e.RowIndex].Cells["Jumlah_tiket"].Value;

                   
                    using (FormBeliTiket beliTiket = new FormBeliTiket(idTiket, iduser, idFilm, nama, email, judul, genre, hargaPerTiket, tanggalMulai, jamMulai, jumlahTiket))
                    {
                        this.Hide();
                        beliTiket.ShowDialog();
                        this.Show();
                        SetDataSource(); // Refresh Data Setelah Form Ditutup
                    }
                }
                else
                {
                    MessageBox.Show("Tiket sudah lunas!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}