namespace BanVeMayBay
{
    partial class frmQR_ThanhToan
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
            this.picQR = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoTienTT = new System.Windows.Forms.Label();
            this.lblTenNganHang = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblThoat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picQR
            // 
            this.picQR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picQR.Image = global::BanVeMayBay.Properties.Resources.QR;
            this.picQR.Location = new System.Drawing.Point(63, 56);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(300, 300);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số tiền thanh toán:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "VND";
            // 
            // lblSoTienTT
            // 
            this.lblSoTienTT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSoTienTT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienTT.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblSoTienTT.Location = new System.Drawing.Point(24, 415);
            this.lblSoTienTT.Name = "lblSoTienTT";
            this.lblSoTienTT.Size = new System.Drawing.Size(324, 32);
            this.lblSoTienTT.TabIndex = 3;
            this.lblSoTienTT.Text = "1.000.000.000";
            this.lblSoTienTT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenNganHang
            // 
            this.lblTenNganHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTenNganHang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNganHang.Location = new System.Drawing.Point(-3, 13);
            this.lblTenNganHang.Name = "lblTenNganHang";
            this.lblTenNganHang.Size = new System.Drawing.Size(433, 32);
            this.lblTenNganHang.TabIndex = 4;
            this.lblTenNganHang.Text = "Tên ngân hàng";
            this.lblTenNganHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblThoat);
            this.panel1.Controls.Add(this.lblTenNganHang);
            this.panel1.Controls.Add(this.lblSoTienTT);
            this.panel1.Controls.Add(this.picQR);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 464);
            this.panel1.TabIndex = 5;
            // 
            // lblThoat
            // 
            this.lblThoat.AutoSize = true;
            this.lblThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblThoat.ForeColor = System.Drawing.Color.Tomato;
            this.lblThoat.Location = new System.Drawing.Point(404, -7);
            this.lblThoat.Name = "lblThoat";
            this.lblThoat.Size = new System.Drawing.Size(25, 32);
            this.lblThoat.TabIndex = 5;
            this.lblThoat.Text = "x";
            this.lblThoat.Click += new System.EventHandler(this.lblThoat_Click);
            // 
            // frmQR_ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(433, 470);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQR_ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQR_ThanhToan";
            this.Load += new System.EventHandler(this.frmQR_ThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoTienTT;
        private System.Windows.Forms.Label lblTenNganHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblThoat;
    }
}