namespace TicketsHub
{
    partial class FormTicketadm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbSearch = new ReaLTaiizor.Controls.AloneTextBox();
            this.datagridviewTc = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.txtbNamaCustomer = new System.Windows.Forms.TextBox();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.nudJumlahTiket = new System.Windows.Forms.NumericUpDown();
            this.txtbTotalHarga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTambah = new ReaLTaiizor.Controls.Button();
            this.btnEdit = new ReaLTaiizor.Controls.Button();
            this.cbStatusPembayaran = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewTc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJumlahTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Search";
            // 
            // txtbSearch
            // 
            this.txtbSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtbSearch.EnabledCalc = true;
            this.txtbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtbSearch.Location = new System.Drawing.Point(148, 120);
            this.txtbSearch.MaxLength = 32767;
            this.txtbSearch.MultiLine = false;
            this.txtbSearch.Name = "txtbSearch";
            this.txtbSearch.ReadOnly = false;
            this.txtbSearch.Size = new System.Drawing.Size(264, 38);
            this.txtbSearch.TabIndex = 7;
            this.txtbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtbSearch.UseSystemPasswordChar = false;
            this.txtbSearch.TextChanged += new System.EventHandler(this.txtbSearch_TextChanged);
            // 
            // datagridviewTc
            // 
            this.datagridviewTc.AllowUserToResizeRows = false;
            this.datagridviewTc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridviewTc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridviewTc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagridviewTc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridviewTc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridviewTc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridviewTc.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridviewTc.EnableHeadersVisualStyles = false;
            this.datagridviewTc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.datagridviewTc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagridviewTc.Location = new System.Drawing.Point(41, 164);
            this.datagridviewTc.Name = "datagridviewTc";
            this.datagridviewTc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridviewTc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datagridviewTc.RowHeadersWidth = 51;
            this.datagridviewTc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridviewTc.RowTemplate.Height = 24;
            this.datagridviewTc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewTc.Size = new System.Drawing.Size(992, 385);
            this.datagridviewTc.TabIndex = 6;
            this.datagridviewTc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridviewTc_CellContentClick);
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(420, 26);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(256, 57);
            this.bigLabel1.TabIndex = 9;
            this.bigLabel1.Text = "Kelola Ticket";
            // 
            // txtbNamaCustomer
            // 
            this.txtbNamaCustomer.Location = new System.Drawing.Point(208, 579);
            this.txtbNamaCustomer.Name = "txtbNamaCustomer";
            this.txtbNamaCustomer.Size = new System.Drawing.Size(264, 22);
            this.txtbNamaCustomer.TabIndex = 10;
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(208, 619);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(264, 24);
            this.cbFilm.TabIndex = 11;
            this.cbFilm.SelectedIndexChanged += new System.EventHandler(this.cbFilm_SelectedIndexChanged);
            // 
            // nudJumlahTiket
            // 
            this.nudJumlahTiket.Location = new System.Drawing.Point(208, 671);
            this.nudJumlahTiket.Name = "nudJumlahTiket";
            this.nudJumlahTiket.Size = new System.Drawing.Size(264, 22);
            this.nudJumlahTiket.TabIndex = 12;
            this.nudJumlahTiket.ValueChanged += new System.EventHandler(this.nudJumlahTiket_ValueChanged);
            // 
            // txtbTotalHarga
            // 
            this.txtbTotalHarga.Location = new System.Drawing.Point(636, 579);
            this.txtbTotalHarga.Name = "txtbTotalHarga";
            this.txtbTotalHarga.Size = new System.Drawing.Size(264, 22);
            this.txtbTotalHarga.TabIndex = 10;
            this.txtbTotalHarga.TextChanged += new System.EventHandler(this.txtbTotalHarga_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 627);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Film";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 673);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Jumlah Tiket";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 585);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Total Harga";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Transparent;
            this.btnTambah.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambah.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTambah.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.Image = null;
            this.btnTambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTambah.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTambah.Location = new System.Drawing.Point(953, 579);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTambah.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTambah.Size = new System.Drawing.Size(93, 40);
            this.btnTambah.TabIndex = 14;
            this.btnTambah.Text = "Tambah Data";
            this.btnTambah.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEdit.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = null;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEdit.Location = new System.Drawing.Point(953, 627);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEdit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEdit.Size = new System.Drawing.Size(93, 40);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit Data";
            this.btnEdit.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbStatusPembayaran
            // 
            this.cbStatusPembayaran.FormattingEnabled = true;
            this.cbStatusPembayaran.Items.AddRange(new object[] {
            "Lunas",
            "Belum Lunas"});
            this.cbStatusPembayaran.Location = new System.Drawing.Point(636, 619);
            this.cbStatusPembayaran.Name = "cbStatusPembayaran";
            this.cbStatusPembayaran.Size = new System.Drawing.Size(264, 24);
            this.cbStatusPembayaran.TabIndex = 15;
            this.cbStatusPembayaran.SelectedIndexChanged += new System.EventHandler(this.cbStatusPembayaran_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 622);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status Pembayaran";
            // 
            // FormTicketadm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 749);
            this.Controls.Add(this.cbStatusPembayaran);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudJumlahTiket);
            this.Controls.Add(this.cbFilm);
            this.Controls.Add(this.txtbTotalHarga);
            this.Controls.Add(this.txtbNamaCustomer);
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbSearch);
            this.Controls.Add(this.datagridviewTc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTicketadm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTicketadm";
            this.Load += new System.EventHandler(this.FormTicketadm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewTc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJumlahTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.AloneTextBox txtbSearch;
        private ReaLTaiizor.Controls.PoisonDataGridView datagridviewTc;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private System.Windows.Forms.TextBox txtbNamaCustomer;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.NumericUpDown nudJumlahTiket;
        private System.Windows.Forms.TextBox txtbTotalHarga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.Button btnTambah;
        private ReaLTaiizor.Controls.Button btnEdit;
        private System.Windows.Forms.ComboBox cbStatusPembayaran;
        private System.Windows.Forms.Label label6;
    }
}