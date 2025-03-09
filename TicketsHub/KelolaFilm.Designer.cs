namespace TicketsHub
{
    partial class KelolaTiket
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtbSearch = new ReaLTaiizor.Controls.AloneTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.cmbxGenre = new ReaLTaiizor.Controls.AloneComboBox();
            this.txtbJudul = new System.Windows.Forms.TextBox();
            this.txtbHargaTiket = new System.Windows.Forms.TextBox();
            this.numericStockTiket = new System.Windows.Forms.NumericUpDown();
            this.jam_mulai = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTambah = new ReaLTaiizor.Controls.Button();
            this.btnEdit = new ReaLTaiizor.Controls.Button();
            this.comboboxgenre = new System.Windows.Forms.ComboBox();
            this.tanggal_mulai = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStockTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(62, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(969, 295);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtbSearch
            // 
            this.txtbSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtbSearch.EnabledCalc = true;
            this.txtbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.txtbSearch.Location = new System.Drawing.Point(818, 154);
            this.txtbSearch.MaxLength = 32767;
            this.txtbSearch.MultiLine = false;
            this.txtbSearch.Name = "txtbSearch";
            this.txtbSearch.ReadOnly = false;
            this.txtbSearch.Size = new System.Drawing.Size(213, 33);
            this.txtbSearch.TabIndex = 2;
            this.txtbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtbSearch.UseSystemPasswordChar = false;
            this.txtbSearch.TextChanged += new System.EventHandler(this.txtbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Genre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(728, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.Black;
            this.bigLabel1.Location = new System.Drawing.Point(395, 46);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(237, 57);
            this.bigLabel1.TabIndex = 4;
            this.bigLabel1.Text = "Kelola Tiket";
            // 
            // cmbxGenre
            // 
            this.cmbxGenre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbxGenre.DisplayMember = "Id";
            this.cmbxGenre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxGenre.EnabledCalc = true;
            this.cmbxGenre.FormattingEnabled = true;
            this.cmbxGenre.ItemHeight = 20;
            this.cmbxGenre.Location = new System.Drawing.Point(132, 161);
            this.cmbxGenre.Name = "cmbxGenre";
            this.cmbxGenre.Size = new System.Drawing.Size(182, 26);
            this.cmbxGenre.TabIndex = 5;
            this.cmbxGenre.ValueMember = "Id";
            this.cmbxGenre.SelectedIndexChanged += new System.EventHandler(this.cmbxGenre_SelectedIndexChanged);
            // 
            // txtbJudul
            // 
            this.txtbJudul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbJudul.Location = new System.Drawing.Point(152, 522);
            this.txtbJudul.Name = "txtbJudul";
            this.txtbJudul.Size = new System.Drawing.Size(239, 22);
            this.txtbJudul.TabIndex = 6;
            // 
            // txtbHargaTiket
            // 
            this.txtbHargaTiket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbHargaTiket.Location = new System.Drawing.Point(150, 625);
            this.txtbHargaTiket.Name = "txtbHargaTiket";
            this.txtbHargaTiket.Size = new System.Drawing.Size(239, 22);
            this.txtbHargaTiket.TabIndex = 6;
            // 
            // numericStockTiket
            // 
            this.numericStockTiket.Location = new System.Drawing.Point(573, 522);
            this.numericStockTiket.Name = "numericStockTiket";
            this.numericStockTiket.Size = new System.Drawing.Size(238, 22);
            this.numericStockTiket.TabIndex = 7;
            // 
            // jam_mulai
            // 
            this.jam_mulai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.jam_mulai.Location = new System.Drawing.Point(573, 576);
            this.jam_mulai.Name = "jam_mulai";
            this.jam_mulai.ShowUpDown = true;
            this.jam_mulai.Size = new System.Drawing.Size(238, 22);
            this.jam_mulai.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 581);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Genre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Judul";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 631);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Harga Tiket";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(451, 581);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Jam Mulai";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 527);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Stok Tiket";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(451, 631);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tanggal Mulai";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Transparent;
            this.btnTambah.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambah.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTambah.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.Image = null;
            this.btnTambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTambah.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnTambah.Location = new System.Drawing.Point(924, 530);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTambah.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnTambah.Size = new System.Drawing.Size(92, 42);
            this.btnTambah.TabIndex = 10;
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
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = null;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEdit.Location = new System.Drawing.Point(924, 578);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEdit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEdit.Size = new System.Drawing.Size(92, 42);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit Data";
            this.btnEdit.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // comboboxgenre
            // 
            this.comboboxgenre.FormattingEnabled = true;
            this.comboboxgenre.Location = new System.Drawing.Point(150, 578);
            this.comboboxgenre.Name = "comboboxgenre";
            this.comboboxgenre.Size = new System.Drawing.Size(241, 24);
            this.comboboxgenre.TabIndex = 11;
            this.comboboxgenre.SelectedIndexChanged += new System.EventHandler(this.comboboxgenre_SelectedIndexChanged);
            // 
            // tanggal_mulai
            // 
            this.tanggal_mulai.Location = new System.Drawing.Point(570, 632);
            this.tanggal_mulai.Name = "tanggal_mulai";
            this.tanggal_mulai.Size = new System.Drawing.Size(240, 22);
            this.tanggal_mulai.TabIndex = 12;
            // 
            // KelolaTiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 780);
            this.Controls.Add(this.tanggal_mulai);
            this.Controls.Add(this.comboboxgenre);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jam_mulai);
            this.Controls.Add(this.numericStockTiket);
            this.Controls.Add(this.txtbHargaTiket);
            this.Controls.Add(this.txtbJudul);
            this.Controls.Add(this.cmbxGenre);
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbSearch);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KelolaTiket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KelolaTiket";
            this.Load += new System.EventHandler(this.KelolaTiket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStockTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private ReaLTaiizor.Controls.AloneTextBox txtbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.AloneComboBox cmbxGenre;
        private System.Windows.Forms.TextBox txtbJudul;
        private System.Windows.Forms.TextBox txtbHargaTiket;
        private System.Windows.Forms.NumericUpDown numericStockTiket;
        private System.Windows.Forms.DateTimePicker jam_mulai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ReaLTaiizor.Controls.Button btnTambah;
        private ReaLTaiizor.Controls.Button btnEdit;
        private System.Windows.Forms.ComboBox comboboxgenre;
        private System.Windows.Forms.DateTimePicker tanggal_mulai;
    }
}