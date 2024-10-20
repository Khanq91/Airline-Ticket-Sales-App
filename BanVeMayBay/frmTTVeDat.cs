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
        string _GiaVe;
        string _VAT1;
        string _VAT2;
        string _TienPPHT;
        string _TienPAN;

        string _TienVeVao, _tg_di, _tg_den, _ma_cb, _hangve, _Ngaybay, _DiemKH, _DiemDen, _ViTriGhe, _TienViTriGhe, _GoiHanhLy, _TienGoiHanhLy;//Được truyền từ frmVe vào

        public string GiaVe { get => _GiaVe; set => _GiaVe = value; }
        public string TienVeVao { get => _TienVeVao; set => _TienVeVao = value; }
        public string VAT1 { get => _VAT1; set => _VAT1 = value; }
        public string VAT2 { get => _VAT2; set => _VAT2 = value; }
        public string TienPPHT { get => _TienPPHT; set => _TienPPHT = value; }
        public string TienPAN { get => _TienPAN; set => _TienPAN = value; }
        public string tg_di { get => _tg_di; set => _tg_di = value; }
        public string tg_den { get => _tg_den; set => _tg_den = value; }
        public string ma_cb { get => _ma_cb; set => _ma_cb = value; }
        public string Hangve { get => _hangve; set => _hangve = value; }
        public string Ngaybay { get => _Ngaybay; set => _Ngaybay = value; }
        public string DiemKH { get => _DiemKH; set => _DiemKH = value; }
        public string DiemDen { get => _DiemDen; set => _DiemDen = value; }
        public string ViTriGhe { get => _ViTriGhe; set => _ViTriGhe = value; }
        public string TienViTriGhe { get => _TienViTriGhe; set => _TienViTriGhe = value; }
        public string GoiHanhLy { get => _GoiHanhLy; set => _GoiHanhLy = value; }
        public string TienGoiHanhLy { get => _TienGoiHanhLy; set => _TienGoiHanhLy = value; }

        public frmTTVeDat(string tvv, string ngaybay, string tgdi, string tgden, string machuyenbay, string hangve, string diemkhoihanh, string diemden, string viTriGhe, string tienViTriGhe, string goiHanhLy, string tienGoiHanhLy)
        {
            InitializeComponent();
            this.TienVeVao = tvv;
            this.tg_di = tgdi;
            this.tg_den = tgden;
            this.ma_cb = machuyenbay;
            this.Hangve = hangve;
            this.Ngaybay = ngaybay;
            this.DiemKH = diemkhoihanh;
            this.DiemDen = diemden;
            //load thông tin điểm khởi hành được người dùng chọn từ csdl
            lblDiemKhoiHanh.Text = DiemKH;
            //load thông tin điểm đến được người dùng chọn từ csdl
            lblDiemDen.Text = DiemDen;
            //load thông tin ngày bay sau khi người dùng chọn vé từ csdl
            lblNgayBay.Text = Ngaybay + "  |  " + tg_di + " - " + tg_den + "  |  " + ma_cb + "  |  " + Hangve + "  |";//"30/4/1975" + " |";
            //load thông tin giờ bay sau khi người dùng chọn vé từ csdl
            //lblTGBay_Den.Text = ; //"9:00 - 12:00" + " |";
            ////load mã chuyến bay từ vé mà người dùng chọn từ csdl
            //lblMaCB.Text = ;//"CB001" + " |";
            ////hạng vé được người dùng chọn từ vé
            //lblHangVeTren.Text = ;//"BUSSINESS1";
            this.ViTriGhe = viTriGhe;
            this.TienViTriGhe = tienViTriGhe;
            this.GoiHanhLy = goiHanhLy;
            this.TienGoiHanhLy = tienGoiHanhLy;

            lblGhe.Text = ViTriGhe;
            lblTienGhe.Text = TienViTriGhe;
            this.TienViTriGhe = lblTienGhe.Text.Replace(".", "");
            lblGoiHanhLy.Text = GoiHanhLy;
            lblTienHL.Text = TienGoiHanhLy;
            this.TienGoiHanhLy = lblTienHL.Text.Replace(".", "");
            if (TienViTriGhe != "0" && TienViTriGhe != "") 
            {
                lblGhe.Visible = true;
                lblTienGhe.Visible = true;
                lblGoiHanhLy.Visible = true;
                lblTienHL.Visible = true;
            }    
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
            Point ViTriBanDau = new Point(13, 386);
            if (lblGhe.Text != "Không chọn")
            { 
                lblGoiHanhLy.Location = new Point(58, 533);
                lblTienHL.Location = new Point(419, 533);
                if (btnDichVu.Location != ViTriBanDau)
                    btnDichVu.Location = ViTriBanDau;

                if (lblGhe.Visible == false)
                {
                    TTDichVu(true);

                    //lblGhe.Text = ViTriGhe;//mã vị trí ghế
                    //lblTienGhe.Text = TienViTriGhe;//giá của mã vị trí ghế trên
                    //lblGoiHanhLy.Text = GoiHanhLy;//tên của gói hành lý(VD: 30kg)
                    //lblTienHL.Text = TienGoiHanhLy;//giá của của gói hành lý trên

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
            else
                TTDichVu(false);
        }

        private void frmTTVeDat_Load(object sender, EventArgs e)
        {        

            //----------------------------------------------------------------------
            //      Tiền vé và thuế 10% của tiền vé
            //----------------------------------------------------------------------
            if(TienVeVao == null)
            { 
                lblTienVe.Visible = false;
                lblTienVATVe.Visible = false;
            }    
            else
            {
                lblTienVe.Text = TienVeVao;   //số tiền của vé được truyền frmVe
                string temp = lblTienVe.Text.Replace(".", "");
                float tienve = float.Parse(temp);
                GiaVe = tienve.ToString();  //dùng để truyền dữ liệu qua form khác
                float vat10 = float.Parse(GiaVe) * 0.1f;
                float vat10xuathien = vat10 / 1000;
                VAT1 = vat10.ToString();    //Lấy thông tin số tiền VAT của vé
                lblTienVATVe.Text = vat10xuathien.ToString() + ".000";  // số tiền thuế 10% của giá vé
            }    

            //----------------------------------------------------------------------
            //      Các loại phụ phí cố định và thuế phụ phí
            //----------------------------------------------------------------------
            lblTienPPHT.Text = "215.000"; //cho phí hệ thống cố định z luôn nha
                                          //Lấy thông tin từ Tiền phụ phí hệ thống
            TienPPHT = lblTienPPHT.Text.Replace(".", "");    //215.000 => 215000

            lblTienPAN.Text = "99.000"; //cho phí an ninh cố định z luôn nha
                                        //Lấy thông tin từ Tiền phí an ninh
            TienPAN = lblTienPAN.Text.Replace(".", "");    //99.000 => 99000
            lblTienVATTP.Text = "15.700"; //cho phí VAT này cố định z luôn nha

            //Lấy thông tin từ Tiền VAT của các loại thuế phí riêng
            VAT2 = lblTienVATTP.Text.Replace(".", "");
        }
        public void TinhThanhTien(string ___GiaVe, string ___TienViTriGhe, string ___TienGoiHL)
        {
            float thanhtien = 0;
            float GiaVe_ = float.Parse(___GiaVe.Replace(".", ""));
            float GiaGhe_, GiaHL_;

            if (___TienViTriGhe != "0" && ___TienViTriGhe != "")
            {
                GiaGhe_ = float.Parse(___TienViTriGhe.Replace(".", ""));
            }
            else GiaGhe_ = 0;
            if (___TienGoiHL != "0" && ___TienGoiHL != "")
            {
                GiaHL_ = float.Parse(___TienGoiHL.Replace(".", ""));
            }
            else GiaHL_ = 0;

            float VAT1_ = GiaVe_ * 0.1f;
            //Tiền vé và thuế 10% của vé
            thanhtien += GiaVe_ + VAT1_;
            //Các loại phụ phí riêng và VAT của phụ phí (không tính vé)
            thanhtien += 329700;
            //Tiền ghế và hành lý(nếu có)
            thanhtien += GiaGhe_ + GiaHL_;
            if (thanhtien < 1000000)
            { 
                //thanhtien /= 1000;
                //lblTongTien.Text = thanhtien.ToString() + ".000"; 
                lblTongTien.Text = string.Format("{0:n0}", thanhtien);
            }
            else
            {
                //thanhtien /= 1000000;
                //lblTongTien.Text = thanhtien.ToString() + ".000.000";
                lblTongTien.Text = string.Format("{0:n0}", thanhtien);
            }
        }
        public string GetThanhTien()
        {
            return lblTongTien.Text;
        }
    }
}
