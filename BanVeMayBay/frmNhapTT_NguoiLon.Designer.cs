﻿namespace BanVeMayBay
{
    partial class frmNhapTT_NguoiLon
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
            this.rdoGioiTinhNam_NL = new System.Windows.Forms.RadioButton();
            this.rdoGioiTinhNu_NL = new System.Windows.Forms.RadioButton();
            this.txtHo_NL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDemvaTen_NL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSDT_NL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail_NL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoiO_NL = new System.Windows.Forms.TextBox();
            this.chkNhanThongTin_NL = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lbl_CCCD = new System.Windows.Forms.Label();
            this.mtxtNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lbl_SDT = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblThongTin_NL = new System.Windows.Forms.Label();
            this.picNguoi = new System.Windows.Forms.PictureBox();
            this.erpNhapTT = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.elipseTool1 = new BanVeMayBay.Tool.ElipseTool();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpNhapTT)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoGioiTinhNam_NL
            // 
            this.rdoGioiTinhNam_NL.AutoSize = true;
            this.rdoGioiTinhNam_NL.Checked = true;
            this.rdoGioiTinhNam_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGioiTinhNam_NL.Location = new System.Drawing.Point(14, 12);
            this.rdoGioiTinhNam_NL.Margin = new System.Windows.Forms.Padding(2);
            this.rdoGioiTinhNam_NL.Name = "rdoGioiTinhNam_NL";
            this.rdoGioiTinhNam_NL.Size = new System.Drawing.Size(90, 36);
            this.rdoGioiTinhNam_NL.TabIndex = 10;
            this.rdoGioiTinhNam_NL.TabStop = true;
            this.rdoGioiTinhNam_NL.Text = "Nam";
            this.rdoGioiTinhNam_NL.UseVisualStyleBackColor = true;
            // 
            // rdoGioiTinhNu_NL
            // 
            this.rdoGioiTinhNu_NL.AutoSize = true;
            this.rdoGioiTinhNu_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGioiTinhNu_NL.Location = new System.Drawing.Point(150, 12);
            this.rdoGioiTinhNu_NL.Margin = new System.Windows.Forms.Padding(2);
            this.rdoGioiTinhNu_NL.Name = "rdoGioiTinhNu_NL";
            this.rdoGioiTinhNu_NL.Size = new System.Drawing.Size(71, 36);
            this.rdoGioiTinhNu_NL.TabIndex = 10;
            this.rdoGioiTinhNu_NL.Text = "Nữ";
            this.rdoGioiTinhNu_NL.UseVisualStyleBackColor = true;
            // 
            // txtHo_NL
            // 
            this.txtHo_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHo_NL.Location = new System.Drawing.Point(14, 108);
            this.txtHo_NL.Margin = new System.Windows.Forms.Padding(2);
            this.txtHo_NL.Name = "txtHo_NL";
            this.txtHo_NL.Size = new System.Drawing.Size(411, 39);
            this.txtHo_NL.TabIndex = 1;
            this.txtHo_NL.Leave += new System.EventHandler(this.txtHo_NL_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Họ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên đệm và tên";
            // 
            // txtTenDemvaTen_NL
            // 
            this.txtTenDemvaTen_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDemvaTen_NL.Location = new System.Drawing.Point(445, 108);
            this.txtTenDemvaTen_NL.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenDemvaTen_NL.Name = "txtTenDemvaTen_NL";
            this.txtTenDemvaTen_NL.Size = new System.Drawing.Size(411, 39);
            this.txtTenDemvaTen_NL.TabIndex = 2;
            this.txtTenDemvaTen_NL.Leave += new System.EventHandler(this.txtTenDemvaTen_NL_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 262);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số điện thoại";
            // 
            // txtSDT_NL
            // 
            this.txtSDT_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT_NL.Location = new System.Drawing.Point(14, 302);
            this.txtSDT_NL.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT_NL.Name = "txtSDT_NL";
            this.txtSDT_NL.Size = new System.Drawing.Size(411, 39);
            this.txtSDT_NL.TabIndex = 5;
            this.txtSDT_NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_NL_KeyPress);
            this.txtSDT_NL.Leave += new System.EventHandler(this.txtSDT_NL_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(452, 266);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Email";
            // 
            // txtEmail_NL
            // 
            this.txtEmail_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail_NL.Location = new System.Drawing.Point(445, 302);
            this.txtEmail_NL.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail_NL.Name = "txtEmail_NL";
            this.txtEmail_NL.Size = new System.Drawing.Size(411, 39);
            this.txtEmail_NL.TabIndex = 6;
            this.txtEmail_NL.Leave += new System.EventHandler(this.txtEmail_NL_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 362);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 32);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nơi ở hiện tại";
            // 
            // txtNoiO_NL
            // 
            this.txtNoiO_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiO_NL.Location = new System.Drawing.Point(14, 400);
            this.txtNoiO_NL.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoiO_NL.Name = "txtNoiO_NL";
            this.txtNoiO_NL.Size = new System.Drawing.Size(842, 39);
            this.txtNoiO_NL.TabIndex = 7;
            // 
            // chkNhanThongTin_NL
            // 
            this.chkNhanThongTin_NL.AutoSize = true;
            this.chkNhanThongTin_NL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhanThongTin_NL.Location = new System.Drawing.Point(14, 456);
            this.chkNhanThongTin_NL.Margin = new System.Windows.Forms.Padding(2);
            this.chkNhanThongTin_NL.Name = "chkNhanThongTin_NL";
            this.chkNhanThongTin_NL.Size = new System.Drawing.Size(777, 36);
            this.chkNhanThongTin_NL.TabIndex = 8;
            this.chkNhanThongTin_NL.Text = "Chúng tôi muốn nhận thông tin khuyến mại từ DuoJet và các đối tác";
            this.chkNhanThongTin_NL.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblNgaySinh);
            this.panel1.Controls.Add(this.lbl_CCCD);
            this.panel1.Controls.Add(this.mtxtNgaySinh);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lbl_SDT);
            this.panel1.Controls.Add(this.lbl_Email);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCCCD);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.rdoGioiTinhNu_NL);
            this.panel1.Controls.Add(this.chkNhanThongTin_NL);
            this.panel1.Controls.Add(this.rdoGioiTinhNam_NL);
            this.panel1.Controls.Add(this.txtHo_NL);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNoiO_NL);
            this.panel1.Controls.Add(this.txtTenDemvaTen_NL);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEmail_NL);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSDT_NL);
            this.panel1.Location = new System.Drawing.Point(202, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 502);
            this.panel1.TabIndex = 21;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Red;
            this.lblNgaySinh.Location = new System.Drawing.Point(14, 248);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(269, 20);
            this.lblNgaySinh.TabIndex = 33;
            this.lblNgaySinh.Text = "Ngày sinh không phù hợp. Tuổi > 12 !";
            this.lblNgaySinh.Visible = false;
            // 
            // lbl_CCCD
            // 
            this.lbl_CCCD.AutoSize = true;
            this.lbl_CCCD.ForeColor = System.Drawing.Color.Red;
            this.lbl_CCCD.Location = new System.Drawing.Point(451, 248);
            this.lbl_CCCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CCCD.Name = "lbl_CCCD";
            this.lbl_CCCD.Size = new System.Drawing.Size(149, 20);
            this.lbl_CCCD.TabIndex = 32;
            this.lbl_CCCD.Text = "CCCD không hợp lệ";
            this.lbl_CCCD.Visible = false;
            // 
            // mtxtNgaySinh
            // 
            this.mtxtNgaySinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtNgaySinh.Location = new System.Drawing.Point(14, 209);
            this.mtxtNgaySinh.Margin = new System.Windows.Forms.Padding(2);
            this.mtxtNgaySinh.Mask = "00/00/0000";
            this.mtxtNgaySinh.Name = "mtxtNgaySinh";
            this.mtxtNgaySinh.Size = new System.Drawing.Size(411, 39);
            this.mtxtNgaySinh.TabIndex = 3;
            this.mtxtNgaySinh.ValidatingType = typeof(System.DateTime);
            this.mtxtNgaySinh.Leave += new System.EventHandler(this.mtxtNgaySinh_Leave);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.Red;
            this.lblEmail.Location = new System.Drawing.Point(455, 350);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 20);
            this.lblEmail.TabIndex = 31;
            // 
            // lbl_SDT
            // 
            this.lbl_SDT.AutoSize = true;
            this.lbl_SDT.ForeColor = System.Drawing.Color.Red;
            this.lbl_SDT.Location = new System.Drawing.Point(19, 342);
            this.lbl_SDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SDT.Name = "lbl_SDT";
            this.lbl_SDT.Size = new System.Drawing.Size(197, 20);
            this.lbl_SDT.TabIndex = 30;
            this.lbl_SDT.Text = "Số điện thoại không hợp lệ";
            this.lbl_SDT.Visible = false;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.ForeColor = System.Drawing.Color.Red;
            this.lbl_Email.Location = new System.Drawing.Point(451, 342);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(143, 20);
            this.lbl_Email.TabIndex = 29;
            this.lbl_Email.Text = "Email không hợp lệ";
            this.lbl_Email.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(517, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 28);
            this.label4.TabIndex = 28;
            this.label4.Text = "(*)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(451, 168);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 32);
            this.label12.TabIndex = 27;
            this.label12.Text = "CCCD";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCCD.Location = new System.Drawing.Point(451, 209);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(2);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(411, 39);
            this.txtCCCD.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(517, 266);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 28);
            this.label14.TabIndex = 25;
            this.label14.Text = "(*)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(164, 262);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 28);
            this.label13.TabIndex = 24;
            this.label13.Text = "(*)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(126, 170);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 28);
            this.label11.TabIndex = 22;
            this.label11.Text = "(*)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(616, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 28);
            this.label10.TabIndex = 21;
            this.label10.Text = "(*)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(52, 73);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 28);
            this.label9.TabIndex = 20;
            this.label9.Text = "(*)";
            // 
            // lblThongTin_NL
            // 
            this.lblThongTin_NL.AutoSize = true;
            this.lblThongTin_NL.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin_NL.ForeColor = System.Drawing.Color.Black;
            this.lblThongTin_NL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThongTin_NL.Location = new System.Drawing.Point(244, 10);
            this.lblThongTin_NL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThongTin_NL.Name = "lblThongTin_NL";
            this.lblThongTin_NL.Size = new System.Drawing.Size(144, 38);
            this.lblThongTin_NL.TabIndex = 22;
            this.lblThongTin_NL.Text = "Người lớn";
            this.lblThongTin_NL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblThongTin_NL.Click += new System.EventHandler(this.lblThongTin_NL_Click);
            // 
            // picNguoi
            // 
            this.picNguoi.Image = global::BanVeMayBay.Properties.Resources.adult;
            this.picNguoi.Location = new System.Drawing.Point(202, 10);
            this.picNguoi.Margin = new System.Windows.Forms.Padding(2);
            this.picNguoi.Name = "picNguoi";
            this.picNguoi.Size = new System.Drawing.Size(38, 38);
            this.picNguoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNguoi.TabIndex = 23;
            this.picNguoi.TabStop = false;
            // 
            // erpNhapTT
            // 
            this.erpNhapTT.ContainerControl = this;
            // 
            // elipseTool1
            // 
            this.elipseTool1.CornerRadius = 30;
            this.elipseTool1.TargetControl = this;
            // 
            // frmNhapTT_NguoiLon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1280, 570);
            this.Controls.Add(this.picNguoi);
            this.Controls.Add(this.lblThongTin_NL);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNhapTT_NguoiLon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmNhapTT";
            this.Load += new System.EventHandler(this.frmNhapTT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpNhapTT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoGioiTinhNam_NL;
        private System.Windows.Forms.RadioButton rdoGioiTinhNu_NL;
        private System.Windows.Forms.TextBox txtHo_NL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDemvaTen_NL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT_NL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail_NL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNoiO_NL;
        private System.Windows.Forms.CheckBox chkNhanThongTin_NL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblThongTin_NL;
        private System.Windows.Forms.PictureBox picNguoi;
        private Tool.ElipseTool elipseTool1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider erpNhapTT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lbl_SDT;
        private System.Windows.Forms.Label lbl_Email;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MaskedTextBox mtxtNgaySinh;
        private System.Windows.Forms.Label lbl_CCCD;
        private System.Windows.Forms.Label lblNgaySinh;
    }
}