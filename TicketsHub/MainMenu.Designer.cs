namespace TicketsHub
{
    partial class MainMenu
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
            this.formMenuStrip1 = new ReaLTaiizor.Controls.FormMenuStrip();
            this.kelolaTiketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kelolaPelangganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kelolaFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.formMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formMenuStrip1
            // 
            this.formMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.formMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kelolaTiketToolStripMenuItem,
            this.kelolaPelangganToolStripMenuItem,
            this.kelolaFilmToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.formMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.formMenuStrip1.Name = "formMenuStrip1";
            this.formMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.formMenuStrip1.Size = new System.Drawing.Size(1132, 30);
            this.formMenuStrip1.TabIndex = 0;
            this.formMenuStrip1.Text = "formMenuStrip1";
            // 
            // kelolaTiketToolStripMenuItem
            // 
            this.kelolaTiketToolStripMenuItem.Name = "kelolaTiketToolStripMenuItem";
            this.kelolaTiketToolStripMenuItem.Size = new System.Drawing.Size(101, 26);
            this.kelolaTiketToolStripMenuItem.Text = "Kelola Tiket";
            this.kelolaTiketToolStripMenuItem.Click += new System.EventHandler(this.kelolaTiketToolStripMenuItem_Click);
            // 
            // kelolaPelangganToolStripMenuItem
            // 
            this.kelolaPelangganToolStripMenuItem.Name = "kelolaPelangganToolStripMenuItem";
            this.kelolaPelangganToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.kelolaPelangganToolStripMenuItem.Text = "Kelola Pelanggan";
            this.kelolaPelangganToolStripMenuItem.Click += new System.EventHandler(this.kelolaPelangganToolStripMenuItem_Click);
            // 
            // kelolaFilmToolStripMenuItem
            // 
            this.kelolaFilmToolStripMenuItem.Name = "kelolaFilmToolStripMenuItem";
            this.kelolaFilmToolStripMenuItem.Size = new System.Drawing.Size(97, 26);
            this.kelolaFilmToolStripMenuItem.Text = "Kelola Film";
            this.kelolaFilmToolStripMenuItem.Click += new System.EventHandler(this.kelolaFilmToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(39, 59);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(196, 57);
            this.bigLabel1.TabIndex = 1;
            this.bigLabel1.Text = "Welcome";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 836);
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.formMenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.formMenuStrip1;
            this.Name = "MainMenu";
            this.Text = "TicketsHub - MainMenu -  Admin";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.formMenuStrip1.ResumeLayout(false);
            this.formMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.FormMenuStrip formMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kelolaTiketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kelolaPelangganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kelolaFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}