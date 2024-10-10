namespace BanVeMayBay
{
    partial class frmDangKy
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
            this.components = new System.ComponentModel.Container();
            this.txtTaiKhoan_DK = new System.Windows.Forms.TextBox();
            this.txtMatKhau_DK = new System.Windows.Forms.TextBox();
            this.txtNhapLaiMatKhau_DK = new System.Windows.Forms.TextBox();
            this.btnDangKi = new System.Windows.Forms.Button();
            this.erpTKMK = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ThongBao = new System.Windows.Forms.Label();
            this.txtTenNguoiDung = new System.Windows.Forms.TextBox();
            this.picThoat = new System.Windows.Forms.PictureBox();
            this.picMayBay = new System.Windows.Forms.PictureBox();
            this.picTroLaiDN = new System.Windows.Forms.PictureBox();
            this.picDangKi = new System.Windows.Forms.PictureBox();
            this.picNenDK = new System.Windows.Forms.PictureBox();
            this.elipseTool1 = new BanVeMayBay.Tool.ElipseTool();
            ((System.ComponentModel.ISupportInitialize)(this.erpTKMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMayBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTroLaiDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDangKi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNenDK)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTaiKhoan_DK
            // 
            this.txtTaiKhoan_DK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan_DK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan_DK.Location = new System.Drawing.Point(1036, 385);
            this.txtTaiKhoan_DK.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaiKhoan_DK.Name = "txtTaiKhoan_DK";
            this.txtTaiKhoan_DK.Size = new System.Drawing.Size(329, 32);
            this.txtTaiKhoan_DK.TabIndex = 1;
            this.txtTaiKhoan_DK.Leave += new System.EventHandler(this.txtTaiKhoan_DK_Leave);
            // 
            // txtMatKhau_DK
            // 
            this.txtMatKhau_DK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau_DK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau_DK.Location = new System.Drawing.Point(1036, 509);
            this.txtMatKhau_DK.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatKhau_DK.Name = "txtMatKhau_DK";
            this.txtMatKhau_DK.Size = new System.Drawing.Size(329, 32);
            this.txtMatKhau_DK.TabIndex = 2;
            this.txtMatKhau_DK.UseSystemPasswordChar = true;
            this.txtMatKhau_DK.Leave += new System.EventHandler(this.txtMatKhau_DK_Leave);
            // 
            // txtNhapLaiMatKhau_DK
            // 
            this.txtNhapLaiMatKhau_DK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNhapLaiMatKhau_DK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapLaiMatKhau_DK.Location = new System.Drawing.Point(1036, 633);
            this.txtNhapLaiMatKhau_DK.Margin = new System.Windows.Forms.Padding(2);
            this.txtNhapLaiMatKhau_DK.Name = "txtNhapLaiMatKhau_DK";
            this.txtNhapLaiMatKhau_DK.Size = new System.Drawing.Size(329, 32);
            this.txtNhapLaiMatKhau_DK.TabIndex = 3;
            this.txtNhapLaiMatKhau_DK.UseSystemPasswordChar = true;
            this.txtNhapLaiMatKhau_DK.Leave += new System.EventHandler(this.txtNhapLaiMatKhau_DK_Leave);
            // 
            // btnDangKi
            // 
            this.btnDangKi.BackColor = System.Drawing.Color.Lime;
            this.btnDangKi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKi.ForeColor = System.Drawing.Color.White;
            this.btnDangKi.Location = new System.Drawing.Point(1019, 714);
            this.btnDangKi.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangKi.Name = "btnDangKi";
            this.btnDangKi.Size = new System.Drawing.Size(366, 92);
            this.btnDangKi.TabIndex = 4;
            this.btnDangKi.Text = "Đăng kí";
            this.btnDangKi.UseVisualStyleBackColor = false;
            this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
            // 
            // erpTKMK
            // 
            this.erpTKMK.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 44F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(43, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(822, 348);
            this.label1.TabIndex = 6;
            this.label1.Text = "HỆ THỐNG\r\nBÁN VÉ MÁY BAY\r\nDuoKT_Jet\r\n";
            // 
            // lbl_ThongBao
            // 
            this.lbl_ThongBao.AutoSize = true;
            this.lbl_ThongBao.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_ThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbl_ThongBao.Location = new System.Drawing.Point(1015, 685);
            this.lbl_ThongBao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ThongBao.Name = "lbl_ThongBao";
            this.lbl_ThongBao.Size = new System.Drawing.Size(0, 22);
            this.lbl_ThongBao.TabIndex = 12;
            // 
            // txtTenNguoiDung
            // 
            this.txtTenNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenNguoiDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNguoiDung.Location = new System.Drawing.Point(1036, 263);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.Size = new System.Drawing.Size(329, 32);
            this.txtTenNguoiDung.TabIndex = 0;
            this.txtTenNguoiDung.Leave += new System.EventHandler(this.txtTenNguoiDung_Leave);
            // 
            // picThoat
            // 
            this.picThoat.Image = global::BanVeMayBay.Properties.Resources.close;
            this.picThoat.Location = new System.Drawing.Point(1471, 10);
            this.picThoat.Margin = new System.Windows.Forms.Padding(2);
            this.picThoat.Name = "picThoat";
            this.picThoat.Size = new System.Drawing.Size(40, 40);
            this.picThoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThoat.TabIndex = 11;
            this.picThoat.TabStop = false;
            this.picThoat.Click += new System.EventHandler(this.picThoat_Click);
            // 
            // picMayBay
            // 
            this.picMayBay.BackColor = System.Drawing.Color.DarkCyan;
            this.picMayBay.Image = global::BanVeMayBay.Properties.Resources.airplane_pic;
            this.picMayBay.Location = new System.Drawing.Point(78, 496);
            this.picMayBay.Margin = new System.Windows.Forms.Padding(2);
            this.picMayBay.Name = "picMayBay";
            this.picMayBay.Size = new System.Drawing.Size(737, 250);
            this.picMayBay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMayBay.TabIndex = 10;
            this.picMayBay.TabStop = false;
            // 
            // picTroLaiDN
            // 
            this.picTroLaiDN.BackColor = System.Drawing.Color.White;
            this.picTroLaiDN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTroLaiDN.Image = global::BanVeMayBay.Properties.Resources.angle_left;
            this.picTroLaiDN.Location = new System.Drawing.Point(1002, 119);
            this.picTroLaiDN.Margin = new System.Windows.Forms.Padding(2);
            this.picTroLaiDN.Name = "picTroLaiDN";
            this.picTroLaiDN.Size = new System.Drawing.Size(49, 35);
            this.picTroLaiDN.TabIndex = 5;
            this.picTroLaiDN.TabStop = false;
            this.picTroLaiDN.Click += new System.EventHandler(this.picTroLaiDN_Click);
            // 
            // picDangKi
            // 
            this.picDangKi.BackColor = System.Drawing.Color.DimGray;
            this.picDangKi.Dock = System.Windows.Forms.DockStyle.Right;
            this.picDangKi.Image = global::BanVeMayBay.Properties.Resources.dangkinew2;
            this.picDangKi.Location = new System.Drawing.Point(878, 0);
            this.picDangKi.Margin = new System.Windows.Forms.Padding(2);
            this.picDangKi.Name = "picDangKi";
            this.picDangKi.Size = new System.Drawing.Size(642, 980);
            this.picDangKi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDangKi.TabIndex = 0;
            this.picDangKi.TabStop = false;
            // 
            // picNenDK
            // 
            this.picNenDK.BackColor = System.Drawing.Color.White;
            this.picNenDK.Dock = System.Windows.Forms.DockStyle.Left;
            this.picNenDK.Image = global::BanVeMayBay.Properties.Resources.cloudPicture1;
            this.picNenDK.Location = new System.Drawing.Point(0, 0);
            this.picNenDK.Margin = new System.Windows.Forms.Padding(2);
            this.picNenDK.Name = "picNenDK";
            this.picNenDK.Size = new System.Drawing.Size(886, 980);
            this.picNenDK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picNenDK.TabIndex = 1;
            this.picNenDK.TabStop = false;
            // 
            // elipseTool1
            // 
            this.elipseTool1.CornerRadius = 40;
            this.elipseTool1.TargetControl = this;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1520, 980);
            this.Controls.Add(this.txtTenNguoiDung);
            this.Controls.Add(this.lbl_ThongBao);
            this.Controls.Add(this.picThoat);
            this.Controls.Add(this.picMayBay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picTroLaiDN);
            this.Controls.Add(this.btnDangKi);
            this.Controls.Add(this.txtNhapLaiMatKhau_DK);
            this.Controls.Add(this.txtMatKhau_DK);
            this.Controls.Add(this.txtTaiKhoan_DK);
            this.Controls.Add(this.picDangKi);
            this.Controls.Add(this.picNenDK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangKy";
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpTKMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMayBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTroLaiDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDangKi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNenDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDangKi;
        private System.Windows.Forms.PictureBox picNenDK;
        private Tool.ElipseTool elipseTool1;
        private System.Windows.Forms.Button btnDangKi;
        private System.Windows.Forms.TextBox txtNhapLaiMatKhau_DK;
        private System.Windows.Forms.TextBox txtMatKhau_DK;
        private System.Windows.Forms.TextBox txtTaiKhoan_DK;
        private System.Windows.Forms.PictureBox picTroLaiDN;
        private System.Windows.Forms.ErrorProvider erpTKMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picMayBay;
        private System.Windows.Forms.PictureBox picThoat;
        private System.Windows.Forms.Label lbl_ThongBao;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
    }
}