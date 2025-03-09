using System;
using System.Linq;
using System.Windows.Forms;

namespace TicketsHub
{
    public partial class MainMenu : Form
    {
        string nm;
        public MainMenu(string nama)
        {
            InitializeComponent();
            IsMdiContainer = true;
            nm = nama;
            bigLabel1.Text = $"Welcome, {nm}";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Apakah kamu ingin keluar?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(res == DialogResult.Yes)
            {
                new FormLogin().Show();
                MessageBox.Show("Berhasil keluar", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            
        }

        private void OpenChildForm<T>() where T : Form, new()
        {
            var existingForm = MdiChildren.OfType<T>().FirstOrDefault();
            if (existingForm != null)
            {
                existingForm.BringToFront();
            }
            else
            {
                var form = new T { MdiParent = this, Dock = DockStyle.Fill };
                form.FormClosed += ChildFormClosed; // ⬅️ Tambahkan event saat form ditutup
                form.Show();
            }

            // 🔥 Kosongkan label saat ada form yang terbuka
            bigLabel1.Text = "";
        }

        private void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            // 🔥 Jika tidak ada form lain yang terbuka, tampilkan kembali label
            if (MdiChildren.Length == 1)
            {
                bigLabel1.Text = $"Welcome, {nm}";
            }
        }

        private void kelolaTiketToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<FormTicketadm>();

        private void kelolaPelangganToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<FormCustomers>();

        private void kelolaFilmToolStripMenuItem_Click(object sender, EventArgs e) => OpenChildForm<FormMovie>();

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // 🔥 Saat pertama kali form dibuka, pastikan label muncul
            bigLabel1.Text = $"Welcome, {nm}";
        }
    }
}
