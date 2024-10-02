using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmTTVeDat : Form
    {
        public frmTTVeDat()
        {
            InitializeComponent();
        }
        //size frm ban đầu 550, 536, khi ấn nút dịch vụ 550, 622
        //pnlDuoiGiaoDien khi chưa bấm nút 0, 473, sau khi ấn nút dịch vụ 0, 559
        //pnlDuoiGiaoDien ở cuối frm 0, 571 ,  frm moi 0, 637
        //btnGiaVe vị trí ban đầu 13, 214
        //btnThuePhi sau khi thông tin vé xuất hiện 13, 334, vị trí ban đầu 13, 300
        //btnDichVu sau khi thông tin thuế phí 13, 445, vị trí ban đầu 13, 386
        public void TTGiaVe(bool kq)
        {
            lblHangVeDuoi.Visible = kq;
            lblVATGiaVe.Visible = kq;

            lblTienVe.Visible = kq;
            lblTienVATVe.Visible = kq;
        }
        public void TTThuePhi(bool kq)
        {
            lblPhuPhiHeThong.Visible = kq;
            lblPhiAnNinh.Visible = kq;
            lblVATPhi.Visible = kq;

            lblTienPPHT.Visible = kq;
            lblTienPAN.Visible = kq;
            lblTienVATTP.Visible = kq;
        }
        public void TTDichVu(bool kq)
        {
            lblChonGhe.Visible = kq;
            lblHanhLy.Visible = kq;

            lblGhe.Visible = kq;
            lblTienGhe.Visible = kq;
            lblGoiHanhLy.Visible = kq;
            lblTienHL.Visible = kq;
            lblGachNgang.Visible = kq;

        }


        private void btnGiaVe_Click(object sender, EventArgs e)
        {
            if (lblHangVeDuoi.Visible == false)
            {
                TTGiaVe(true);
                //lblTienVe.Text = số tiền của vé từ csdl
                //lblTienVATVe.Text = số tiền thuế 10% của giá vé

                btnThuePhi.Location = new Point(13, 334);
                btnDichVu.Location = new Point(13, 420);
                pnlDuoiGiaoDien.Location = new Point(0, 507);

                this.Size = new Size(550, 571);

                TTThuePhi(false);
                TTDichVu(false);
            }
            else
            {
                TTGiaVe(false);

                btnThuePhi.Location = new Point(13, 300);
                int y = btnThuePhi.Location.Y;
                y += 86;
                btnDichVu.Location = new Point(13, y);
                y += 87;
                pnlDuoiGiaoDien.Location = new Point(0, y);

                this.Size = new Size(550, 536);

                TTThuePhi(false);
                TTDichVu(false);
            }    
        }

        private void btnThuePhi_Click(object sender, EventArgs e)
        {
            Point ViTriBanDau = new Point(13, 300);
            if (btnThuePhi.Location != ViTriBanDau)
                btnThuePhi.Location = ViTriBanDau;
            if (lblPhuPhiHeThong.Visible == false)
            {
                TTThuePhi(true);

                lblTienPPHT.Text = "215.000"; //cho phí hệ thống cố định z luôn nha
                lblTienPAN.Text = "99.000"; //cho phí an ninh cố định z luôn nha
                lblTienVATTP.Text = "15.700"; //cho phí VAT này cố định z luôn nha

                btnDichVu.Location = new Point(13, 445);
                pnlDuoiGiaoDien.Location = new Point(0, 531);

                this.Size = new Size(550, 595);

                TTGiaVe(false);
                TTDichVu(false);
            }
            else
            {
                TTThuePhi(false);

                btnDichVu.Location = new Point(13, 386);
                pnlDuoiGiaoDien.Location = new Point(0, 472);

                this.Size = new Size(550, 536);

                TTGiaVe(false);
                TTDichVu(false);
            }
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            lblGoiHanhLy.Location = new Point(58, 533);
            lblTienHL.Location = new Point(419, 533);
            Point ViTriBanDau = new Point(13, 386);
            if (btnDichVu.Location != ViTriBanDau)
                btnDichVu.Location = ViTriBanDau;

            if (lblChonGhe.Visible == false)
            {
                TTDichVu(true);

                //lblGhe.Text = mã vị trí ghế
                //lblTienGhe.Text = giá của mã vị trí ghế trên
                //lblGoiHanhLy.Text = tên của gói hành lý (VD: 30kg)
                //lblTienHL.Text = giá của của gói hành lý trên

                btnThuePhi.Location = new Point(13, 300);
                this.Size = new Size(550, 622);
                pnlDuoiGiaoDien.Location = new Point(0, 559);

                TTGiaVe(false);
                TTThuePhi(false);
            }
            else
            {
                TTDichVu(false);

                btnThuePhi.Location = new Point(13, 300);
                this.Size = new Size(550, 536);
                pnlDuoiGiaoDien.Location = new Point(0, 473);

                TTGiaVe(false);
                TTThuePhi(false);
            }
        }

        private void frmTTVeDat_Load(object sender, EventArgs e)
        {
            lblDiemKhoiHanh.Text = "TP. Hồ Chí Minh ( SGN )";//load gì đó được người dùng chọn từ csdl
            lblDiemDen.Text = "Hà Nội ( HAN )";//load gì đó được người dùng chọn từ csdl
            lblNgayBay.Text = "30/4/1975" + " |"; //load thông tin ngày bay sau khi người dùng chọn vé từ csdl
            lblTGBay_Den.Text = "9:00 - 12:00" + " |";//load thông tin giờ bay sau khi người dùng chọn vé từ csdl
            lblMaCB.Text = "CB001" + " |";//load mã của người dùng chọn lúc vé từ csdl
            lblHangVeTren.Text = "BUSSINESS1";//hạng vé được người dùng chọn
        }
    }
}
