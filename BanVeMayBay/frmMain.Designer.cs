namespace BanVeMayBay
{
    partial class frmMain
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
            this.pnlThanGiaoDien = new System.Windows.Forms.Panel();
            this.flowLayoutPnlThanGianDien = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDauGiaoDien = new System.Windows.Forms.Panel();
            this.picReset = new System.Windows.Forms.PictureBox();
            this.picThoat = new System.Windows.Forms.PictureBox();
            this.lblChaoNguoiDung = new System.Windows.Forms.Label();
            this.lblDuoKTJet = new System.Windows.Forms.Label();
            this.pnlDuoiGiaoDien = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.btnDiTiep = new System.Windows.Forms.Button();
            this.elipseTool1 = new BanVeMayBay.Tool.ElipseTool();
            this.pnlThanGiaoDien.SuspendLayout();
            this.pnlDauGiaoDien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThoat)).BeginInit();
            this.pnlDuoiGiaoDien.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlThanGiaoDien
            // 
            this.pnlThanGiaoDien.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlThanGiaoDien.Controls.Add(this.flowLayoutPnlThanGianDien);
            this.pnlThanGiaoDien.Location = new System.Drawing.Point(-1, 138);
            this.pnlThanGiaoDien.Name = "pnlThanGiaoDien";
            this.pnlThanGiaoDien.Size = new System.Drawing.Size(1900, 702);
            this.pnlThanGiaoDien.TabIndex = 0;
            // 
            // flowLayoutPnlThanGianDien
            // 
            this.flowLayoutPnlThanGianDien.AutoScroll = true;
            this.flowLayoutPnlThanGianDien.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPnlThanGianDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPnlThanGianDien.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPnlThanGianDien.Name = "flowLayoutPnlThanGianDien";
            this.flowLayoutPnlThanGianDien.Size = new System.Drawing.Size(1900, 702);
            this.flowLayoutPnlThanGianDien.TabIndex = 0;
            // 
            // pnlDauGiaoDien
            // 
            this.pnlDauGiaoDien.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlDauGiaoDien.Controls.Add(this.picReset);
            this.pnlDauGiaoDien.Controls.Add(this.picThoat);
            this.pnlDauGiaoDien.Controls.Add(this.lblChaoNguoiDung);
            this.pnlDauGiaoDien.Controls.Add(this.lblDuoKTJet);
            this.pnlDauGiaoDien.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDauGiaoDien.Location = new System.Drawing.Point(0, 0);
            this.pnlDauGiaoDien.Name = "pnlDauGiaoDien";
            this.pnlDauGiaoDien.Size = new System.Drawing.Size(1898, 144);
            this.pnlDauGiaoDien.TabIndex = 1;
            // 
            // picReset
            // 
            this.picReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReset.Image = global::BanVeMayBay.Properties.Resources.refresh;
            this.picReset.Location = new System.Drawing.Point(1800, 9);
            this.picReset.Name = "picReset";
            this.picReset.Size = new System.Drawing.Size(40, 40);
            this.picReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReset.TabIndex = 12;
            this.picReset.TabStop = false;
            this.picReset.Click += new System.EventHandler(this.picReset_Click);
            // 
            // picThoat
            // 
            this.picThoat.Image = global::BanVeMayBay.Properties.Resources.circle_cross;
            this.picThoat.Location = new System.Drawing.Point(1846, 9);
            this.picThoat.Name = "picThoat";
            this.picThoat.Size = new System.Drawing.Size(40, 40);
            this.picThoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThoat.TabIndex = 11;
            this.picThoat.TabStop = false;
            this.picThoat.Click += new System.EventHandler(this.picThoat_Click);
            this.picThoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picThoat_MouseMove);
            // 
            // lblChaoNguoiDung
            // 
            this.lblChaoNguoiDung.AutoSize = true;
            this.lblChaoNguoiDung.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaoNguoiDung.ForeColor = System.Drawing.Color.White;
            this.lblChaoNguoiDung.Location = new System.Drawing.Point(1393, 50);
            this.lblChaoNguoiDung.Name = "lblChaoNguoiDung";
            this.lblChaoNguoiDung.Size = new System.Drawing.Size(103, 45);
            this.lblChaoNguoiDung.TabIndex = 2;
            this.lblChaoNguoiDung.Text = "label1";
            // 
            // lblDuoKTJet
            // 
            this.lblDuoKTJet.AutoSize = true;
            this.lblDuoKTJet.Font = new System.Drawing.Font("Segoe UI Black", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuoKTJet.ForeColor = System.Drawing.Color.White;
            this.lblDuoKTJet.Location = new System.Drawing.Point(6, 7);
            this.lblDuoKTJet.Name = "lblDuoKTJet";
            this.lblDuoKTJet.Size = new System.Drawing.Size(554, 128);
            this.lblDuoKTJet.TabIndex = 0;
            this.lblDuoKTJet.Text = "DuoKT_Jet";
            // 
            // pnlDuoiGiaoDien
            // 
            this.pnlDuoiGiaoDien.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlDuoiGiaoDien.Controls.Add(this.lblTongTien);
            this.pnlDuoiGiaoDien.Controls.Add(this.lbl);
            this.pnlDuoiGiaoDien.Controls.Add(this.btnDiTiep);
            this.pnlDuoiGiaoDien.Location = new System.Drawing.Point(0, 839);
            this.pnlDuoiGiaoDien.Name = "pnlDuoiGiaoDien";
            this.pnlDuoiGiaoDien.Size = new System.Drawing.Size(1898, 87);
            this.pnlDuoiGiaoDien.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(1289, 23);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 38);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "0 VND";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(1162, 28);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(100, 28);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Tổng tiền";
            // 
            // btnDiTiep
            // 
            this.btnDiTiep.FlatAppearance.BorderSize = 0;
            this.btnDiTiep.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiTiep.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnDiTiep.Location = new System.Drawing.Point(1657, 7);
            this.btnDiTiep.Name = "btnDiTiep";
            this.btnDiTiep.Size = new System.Drawing.Size(196, 71);
            this.btnDiTiep.TabIndex = 0;
            this.btnDiTiep.Text = "Đi tiếp";
            this.btnDiTiep.UseVisualStyleBackColor = true;
            // 
            // elipseTool1
            // 
            this.elipseTool1.CornerRadius = 40;
            this.elipseTool1.TargetControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1898, 924);
            this.Controls.Add(this.pnlDuoiGiaoDien);
            this.Controls.Add(this.pnlDauGiaoDien);
            this.Controls.Add(this.pnlThanGiaoDien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlThanGiaoDien.ResumeLayout(false);
            this.pnlDauGiaoDien.ResumeLayout(false);
            this.pnlDauGiaoDien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThoat)).EndInit();
            this.pnlDuoiGiaoDien.ResumeLayout(false);
            this.pnlDuoiGiaoDien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tool.ElipseTool elipseTool1;
        private System.Windows.Forms.Panel pnlThanGiaoDien;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPnlThanGianDien;
        private System.Windows.Forms.Panel pnlDauGiaoDien;
        private System.Windows.Forms.Label lblDuoKTJet;
        private System.Windows.Forms.Label lblChaoNguoiDung;
        private System.Windows.Forms.Panel pnlDuoiGiaoDien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnDiTiep;
        private System.Windows.Forms.PictureBox picThoat;
        private System.Windows.Forms.PictureBox picReset;
    }
}

