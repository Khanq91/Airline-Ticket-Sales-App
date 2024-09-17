using System.Drawing;

namespace BanVeMayBay
{
    partial class frmDangNhap
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
            this.txtMatKhau_DN = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan_DN = new System.Windows.Forms.TextBox();
            this.picDangNhap = new System.Windows.Forms.PictureBox();
            this.erpTKMK = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangKi = new System.Windows.Forms.Button();
            this.picNenDN = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.elipseTool1 = new BanVeMayBay.Tool.ElipseTool();
            this.picMayBay = new System.Windows.Forms.PictureBox();
            this.picThoat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDangNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTKMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNenDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMayBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThoat)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatKhau_DN
            // 
            this.txtMatKhau_DN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau_DN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau_DN.Location = new System.Drawing.Point(1035, 476);
            this.txtMatKhau_DN.Name = "txtMatKhau_DN";
            this.txtMatKhau_DN.Size = new System.Drawing.Size(334, 32);
            this.txtMatKhau_DN.TabIndex = 2;
            this.txtMatKhau_DN.UseSystemPasswordChar = true;
            this.txtMatKhau_DN.Leave += new System.EventHandler(this.txtMatKhau_Leave);
            // 
            // txtTaiKhoan_DN
            // 
            this.txtTaiKhoan_DN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan_DN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan_DN.Location = new System.Drawing.Point(1035, 339);
            this.txtTaiKhoan_DN.Name = "txtTaiKhoan_DN";
            this.txtTaiKhoan_DN.Size = new System.Drawing.Size(334, 32);
            this.txtTaiKhoan_DN.TabIndex = 1;
            this.txtTaiKhoan_DN.Leave += new System.EventHandler(this.txtTaiKhoan_Leave);
            // 
            // picDangNhap
            // 
            this.picDangNhap.BackColor = System.Drawing.Color.DimGray;
            this.picDangNhap.Image = global::BanVeMayBay.Properties.Resources.frmDangNhap_final;
            this.picDangNhap.Location = new System.Drawing.Point(882, 0);
            this.picDangNhap.Name = "picDangNhap";
            this.picDangNhap.Size = new System.Drawing.Size(642, 980);
            this.picDangNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDangNhap.TabIndex = 0;
            this.picDangNhap.TabStop = false;
            // 
            // erpTKMK
            // 
            this.erpTKMK.ContainerControl = this;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(1018, 584);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(369, 85);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKi
            // 
            this.btnDangKi.BackColor = System.Drawing.Color.Lime;
            this.btnDangKi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKi.ForeColor = System.Drawing.Color.White;
            this.btnDangKi.Location = new System.Drawing.Point(1063, 719);
            this.btnDangKi.Name = "btnDangKi";
            this.btnDangKi.Size = new System.Drawing.Size(279, 85);
            this.btnDangKi.TabIndex = 4;
            this.btnDangKi.Text = "Đăng kí tài khoản";
            this.btnDangKi.UseVisualStyleBackColor = false;
            this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
            // 
            // picNenDN
            // 
            this.picNenDN.BackColor = System.Drawing.Color.DarkCyan;
            this.picNenDN.Image = global::BanVeMayBay.Properties.Resources.cloudPicture1;
            this.picNenDN.Location = new System.Drawing.Point(0, 0);
            this.picNenDN.Name = "picNenDN";
            this.picNenDN.Size = new System.Drawing.Size(885, 980);
            this.picNenDN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picNenDN.TabIndex = 5;
            this.picNenDN.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 44F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(43, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(822, 348);
            this.label1.TabIndex = 6;
            this.label1.Text = "HỆ THỐNG\r\nBÁN VÉ MÁY BAY\r\nDuoKT_Jet\r\n";
            // 
            // elipseTool1
            // 
            this.elipseTool1.CornerRadius = 40;
            this.elipseTool1.TargetControl = this;
            // 
            // picMayBay
            // 
            this.picMayBay.BackColor = System.Drawing.Color.DarkCyan;
            this.picMayBay.Image = global::BanVeMayBay.Properties.Resources.airplane_pic;
            this.picMayBay.Location = new System.Drawing.Point(78, 496);
            this.picMayBay.Name = "picMayBay";
            this.picMayBay.Size = new System.Drawing.Size(737, 250);
            this.picMayBay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMayBay.TabIndex = 9;
            this.picMayBay.TabStop = false;
            // 
            // picThoat
            // 
            this.picThoat.Image = global::BanVeMayBay.Properties.Resources.close;
            this.picThoat.Location = new System.Drawing.Point(1471, 9);
            this.picThoat.Name = "picThoat";
            this.picThoat.Size = new System.Drawing.Size(40, 40);
            this.picThoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThoat.TabIndex = 10;
            this.picThoat.TabStop = false;
            this.picThoat.Click += new System.EventHandler(this.picThoat_Click);
            this.picThoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picThoat_MouseMove);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1520, 980);
            this.Controls.Add(this.picThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.picMayBay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDangKi);
            this.Controls.Add(this.txtMatKhau_DN);
            this.Controls.Add(this.txtTaiKhoan_DN);
            this.Controls.Add(this.picDangNhap);
            this.Controls.Add(this.picNenDN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDangNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTKMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNenDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMayBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThoat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Tool.ElipseTool elipseTool1;
        private System.Windows.Forms.TextBox txtMatKhau_DN;
        private System.Windows.Forms.TextBox txtTaiKhoan_DN;
        private System.Windows.Forms.PictureBox picDangNhap;
        private System.Windows.Forms.ErrorProvider erpTKMK;
        private System.Windows.Forms.Button btnDangKi;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.PictureBox picNenDN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picMayBay;
        private System.Windows.Forms.PictureBox picThoat;
    }
}