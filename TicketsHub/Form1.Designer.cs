namespace TicketsHub
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new ReaLTaiizor.Controls.HopeButton();
            this.txtbPw = new System.Windows.Forms.TextBox();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.airCheckBox1 = new ReaLTaiizor.Controls.AirCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-13, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1039, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnLogin.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnLogin.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogin.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnLogin.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnLogin.Location = new System.Drawing.Point(465, 436);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PrimaryColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.Size = new System.Drawing.Size(115, 49);
            this.btnLogin.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            // 
            // txtbPw
            // 
            this.txtbPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbPw.Location = new System.Drawing.Point(403, 361);
            this.txtbPw.Name = "txtbPw";
            this.txtbPw.Size = new System.Drawing.Size(284, 22);
            this.txtbPw.TabIndex = 5;
            this.txtbPw.Text = "Password";
            this.txtbPw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtbPw_MouseClick);
            this.txtbPw.TextChanged += new System.EventHandler(this.txtbPw_TextChanged);
            this.txtbPw.MouseEnter += new System.EventHandler(this.txtbPw_MouseEnter);
            // 
            // txtbEmail
            // 
            this.txtbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbEmail.Location = new System.Drawing.Point(403, 296);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(284, 22);
            this.txtbEmail.TabIndex = 5;
            this.txtbEmail.Text = "Email";
            this.txtbEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtbEmail_MouseClick);
            // 
            // airCheckBox1
            // 
            this.airCheckBox1.Checked = false;
            this.airCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airCheckBox1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8=";
            this.airCheckBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airCheckBox1.Image = null;
            this.airCheckBox1.Location = new System.Drawing.Point(557, 404);
            this.airCheckBox1.Name = "airCheckBox1";
            this.airCheckBox1.NoRounding = false;
            this.airCheckBox1.Size = new System.Drawing.Size(130, 17);
            this.airCheckBox1.TabIndex = 6;
            this.airCheckBox1.Text = "Show Password";
            this.airCheckBox1.Transparent = false;
            this.airCheckBox1.CheckedChanged += new ReaLTaiizor.Controls.AirCheckBox.CheckedChangedEventHandler(this.airCheckBox1_CheckedChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 563);
            this.Controls.Add(this.airCheckBox1);
            this.Controls.Add(this.txtbEmail);
            this.Controls.Add(this.txtbPw);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticketshub - Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.HopeButton btnLogin;
        private System.Windows.Forms.TextBox txtbPw;
        private System.Windows.Forms.TextBox txtbEmail;
        private ReaLTaiizor.Controls.AirCheckBox airCheckBox1;
    }
}

