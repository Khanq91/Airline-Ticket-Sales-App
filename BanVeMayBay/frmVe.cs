using BanVeMayBay.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;

namespace BanVeMayBay
{
    public partial class frmVe : Form
    {
        string _tienve;
        string _tg_di;
        string _tg_den;
        string _ma_chuyenbay;
        string _ma_maybay;
        string _loai_maybay;
        string _diem_kh;
        string _diem_den;
        string _ngay_kh;
        string _Hangve;
        private frmMain ParentForm;
        //bool checkClick();
        DB_Connet db = new DB_Connet();
        public string Hangve { get => _Hangve; set => _Hangve = value; }
        public string Tienve { get => _tienve; set => _tienve = value; }
        public string tg_di { get => _tg_di; set => _tg_di = value; }
        public string tg_den { get => _tg_den; set => _tg_den = value; }
        public string ma_chuyenbay { get => _ma_chuyenbay; set => _ma_chuyenbay = value; }
        public string ma_maybay { get => _ma_maybay; set => _ma_maybay = value; }
        public string loai_maybay { get => _loai_maybay; set => _loai_maybay = value; }
        public string diem_kh { get => _diem_kh; set => _diem_kh = value; }
        public string diem_den { get => _diem_den; set => _diem_den = value; }
        public string ngay_kh { get => _ngay_kh; set => _ngay_kh = value; }

        public frmVe(string diemkhoihanh, string diemden, string ngaykhoihanh, string ThoiGianDi, string ThoiGianDen, string MaChuyenBay, string MaMayBay, string LoaiMB)
        {
            InitializeComponent();
            this.tg_di = ThoiGianDi;
            this.tg_den = ThoiGianDen;
            this.ma_chuyenbay = MaChuyenBay;
            this.ma_maybay = MaMayBay;
            this.loai_maybay = LoaiMB;
            this.diem_kh = diemkhoihanh;
            this.diem_den = diemden;
            this.ngay_kh = ngaykhoihanh;
            //Đây là form thông tin của 1 vé
            //Thời gian đi
            lblTG_Di.Text = tg_di;
            lblTG_Den.Text = tg_den;
            lblMaChuyenBay.Text = ma_chuyenbay;
            lblMCB.Text = ma_chuyenbay;
            lblTG.Text = ngay_kh + " | " + tg_di + " - " + tg_den;
            lblMaMayBay.Text = ma_maybay;
            lblMMB.Text = ma_maybay + " - " + loai_maybay;
            lblDiemKhoiHanh.Text = diem_kh;
            lblDiemDen.Text = diem_den;
        }
        public frmVe ()
        {
            InitializeComponent();
        }
        public void SetParentForm(frmMain parent)
        {
            ParentForm = parent;
        }

        private void frmVe_Load(object sender, EventArgs e)
        {
            this.Height = 160;
            Tienve = "";
            //VD: giá của hạng vé 1 = 1000000 thì lblGiaHV1.Text bằng 1.000
            lblGiaHV1.Text = "500";
            lblGiaHV4.Text = "1.500";
        }
        public bool ktraClick()
        {
            if (picCTVe1.Image == Resources.arrow_up && picCTVe4.Image == Resources.arrow_up)
            {
                return false;
            }
            else return true;
        }
        #region Hàm xử lý giao diện
        //Các hàm xuất thông tin các dịch vụ trên frm
        public void lblDichVu1(bool kq, string KLDV1, string KLDV2)
        {
            //lblDichVu3_4(false, "null", "null");
            lblKhoiLuongDV1.Visible = kq;
            lblKhoiLuongDV1.Text = KLDV1; //Khối lượng cho hành lý xách tay ở dịch vụ 1
            lblKhoiLuongDV2.Visible = kq;
            lblKhoiLuongDV2.Text = KLDV2; //Khối lượng cho hành lý ký gửi ở dịch vụ 1
            lblDV1.Visible = kq;
            lblDV2.Visible = kq;

            picDV1.Visible = kq;
            picDV2.Visible = kq;

            //Dịch vụ không bao gồm
            lblDVcBG.Visible = kq;
            lblDV10.Visible = kq;
            lblDV11.Visible = kq;
            lblDV12.Visible = kq;

            picDV10.Visible = kq;
            picDV11.Visible = kq;
            picDV12.Visible = kq;
            if(kq)
            {
                picDV1.BackColor = Color.PaleTurquoise;
                picDV2.BackColor = Color.PaleTurquoise;
                picDV10.BackColor = Color.PaleTurquoise;
                picDV11.BackColor = Color.PaleTurquoise;
                picDV12.BackColor = Color.PaleTurquoise;
            }
            else
            {
                picDV1.BackColor = Color.White;
                picDV2.BackColor = Color.White;
                picDV10.BackColor = Color.White;
                picDV11.BackColor = Color.White;
                picDV12.BackColor = Color.White;
            }
        }
        public void lblDichVu2(bool kq, string KLDV1, string KLDV2)
        {
            //lblDichVu1(false, "null", "null");
            lblKhoiLuongDV1.Visible = kq;
            lblKhoiLuongDV1.Text = KLDV1; //Khối lượng cho hành lý xách tay ở dịch vụ 1
            lblKhoiLuongDV2.Visible = kq;
            lblKhoiLuongDV2.Text = KLDV2; //Khối lượng cho hành lý ký gửi ở dịch vụ 2
            lblDV1.Visible = kq;
            lblDV2.Visible = kq;
            lblDV3.Visible = kq;
            lblDV4.Visible = kq;

            picDV1.Visible = kq;
            picDV2.Visible = kq;
            picDV3.Visible = kq;
            picDV4.Visible = kq;
            if(kq)
            {
                picDV1.BackColor = Color.PeachPuff;
                picDV2.BackColor = Color.PeachPuff;
                picDV3.BackColor = Color.PeachPuff;
                picDV4.BackColor = Color.PeachPuff;
            }
            else
            {
                picDV1.BackColor = Color.White;
                picDV2.BackColor = Color.White;
                picDV3.BackColor = Color.White;
                picDV4.BackColor = Color.White;
            }
        }
        public void lblDichVu3_4(bool kq, string KLDV1, string KLDV2, int dv)
        {
            //lblDichVu1(false, "null", "null");
            lblKhoiLuongDV1.Visible = kq;
            lblKhoiLuongDV1.Text = KLDV1; //Khối lượng cho hành lý xách tay ở dịch vụ 3 hoặc 4
            lblKhoiLuongDV2.Visible = kq;
            lblKhoiLuongDV2.Text = KLDV2; //Khối lượng cho hành lý ký gửi ở dịch vụ 3 hoặc 4
            lblDV1.Visible = kq;
            lblDV2.Visible = kq;
            lblDV3.Visible = kq;
            lblDV4.Visible = kq;
            lblDV5.Visible = kq;
            lblDV6.Visible = kq;
            lblDV7.Visible = kq;
            lblDV8.Visible = kq;
            lblDV9.Visible = kq;

            picDV1.Visible = kq;
            picDV2.Visible = kq;
            picDV3.Visible = kq;
            picDV4.Visible = kq;
            picDV5.Visible = kq;
            picDV6.Visible = kq;
            picDV7.Visible = kq;
            picDV8.Visible = kq;
            picDV9.Visible = kq;
            if(kq)
            {
                if (dv == 3)
                {
                    picDV1.BackColor = Color.LightSalmon;
                    picDV2.BackColor = Color.LightSalmon;
                    picDV3.BackColor = Color.LightSalmon;
                    picDV4.BackColor = Color.LightSalmon;
                    picDV5.BackColor = Color.LightSalmon;
                    picDV6.BackColor = Color.LightSalmon;
                    picDV7.BackColor = Color.LightSalmon;
                    picDV8.BackColor = Color.LightSalmon;
                    picDV9.BackColor = Color.LightSalmon;
                }
                else if (dv == 4)
                {
                    picDV1.BackColor = Color.Wheat;
                    picDV2.BackColor = Color.Wheat;
                    picDV3.BackColor = Color.Wheat;
                    picDV4.BackColor = Color.Wheat;
                    picDV5.BackColor = Color.Wheat;
                    picDV6.BackColor = Color.Wheat;
                    picDV7.BackColor = Color.Wheat;
                    picDV8.BackColor = Color.Wheat;
                    picDV9.BackColor = Color.Wheat;
                }
            }
            else
            {

                picDV1.BackColor = Color.White;
                picDV2.BackColor = Color.White;
                picDV3.BackColor = Color.White;
                picDV4.BackColor = Color.White;
                picDV5.BackColor = Color.White;
                picDV6.BackColor = Color.White;
                picDV7.BackColor = Color.White;
                picDV8.BackColor = Color.White;
                picDV9.BackColor = Color.White;
            }
        }
        public void lblTTCB(bool kq)
        {
            label0.Visible = kq;
            label1.Visible = kq;
            label2.Visible = kq;
            label3.Visible = kq;
            label4.Visible = kq;

            lblMCB.Visible = kq;
            lblMMB.Visible = kq;
            lblTG.Visible = kq;
            lblDiemKhoiHanh.Visible = kq;
            lblDiemDen.Visible = kq;
        }
        public void XuLy()
        {
            pnlHangVe1.BackColor = Color.White;
            picCTVe1.BackColor = Color.White;
            pnlHangVe2.BackColor = Color.White;
            picCTVe2.BackColor = Color.White;
            pnlHangVe3.BackColor = Color.White;
            picCTVe3.BackColor = Color.White;
            pnlHangVe4.BackColor = Color.White;
            picCTVe4.BackColor = Color.White;
        }
        //Hàm xuất thông tin trên frm
        public void showDV(bool kq, int DV)
        {
            if (kq)
            {
                pnlChiTiet.Visible = kq;
                if (DV == 1)
                {
                    lblDVBG.Visible = kq;
                    pnlChiTiet.Height = 283;
                    this.Height = 364;
                    picCTCB.Image = Resources.arrow_down;
                    lblDichVu3_4(false, "null", "null", 3);
                    lblTTCB(false);
                    //"7kg" là khối lượng cho hành lý xách tay ở dịch vụ 1
                    //"5kg" là khối lượng cho hành lý kí gửi ở dịch vụ 1
                    lblDichVu1(true, "7kg", "5kg");
                }
                else if (DV == 2)
                {
                    lblDVBG.Visible = kq;
                    pnlChiTiet.Height = 145;
                    this.Height = 310;
                    picCTCB.Image = Resources.arrow_down;
                    lblDichVu1(false, "null", "null");
                    lblTTCB(false);
                    //"7kg" là khối lượng cho hành lý xách tay ở dịch vụ 2
                    //"20kg" là khối lượng cho hành lý kí gửi ở dịch vụ 2
                    lblDichVu2(true, "7kg", "20kg");
                }
                else if (DV == 3)
                {
                    lblDVBG.Visible = kq;
                    pnlChiTiet.Height = 283;
                    this.Height = 449;
                    picCTCB.Image = Resources.arrow_down;
                    lblDichVu1(false, "null", "null");
                    lblTTCB(false);
                    //"10kg" là khối lượng cho hành lý xách tay ở dịch vụ 3
                    //"30kg + 1 bộ dụng cụ chơi golf" là khối lượng và dv thêm cho hành lý ký gửi ở dịch vụ 3
                    lblDichVu3_4(true, "10kg", "30kg + 1 bộ dụng cụ chơi golf", 3);
                }
                else if (DV == 4)
                {
                    lblDVBG.Visible = kq;
                    pnlChiTiet.Height = 283;
                    this.Height = 449;
                    picCTCB.Image = Resources.arrow_down;
                    lblTTCB(false);
                    lblDichVu1(false, "null", "null");
                    //"18kg" là khối lượng cho hành lý xách tay ở dịch vụ 4
                    //"40kg + 1 bộ dụng cụ chơi golf" là khối lượng và dv thêm cho hành lý ký gửi ở dịch vụ 4
                    lblDichVu3_4(true, "18kg", "40kg + 1 bộ dụng cụ chơi golf", 4);
                }
                else if (DV == 0)
                {
                    pnlChiTiet.Height = 146;
                    this.Height = 313;
                    lblDichVu1(false, "null", "null");
                    lblDichVu3_4(false, "null", "null", 4);
                    lblTTCB(true);
                }
            }
            else
            {
                lblTTCB(false);
                lblDichVu3_4(false, "", "", 3);
                this.Height = 160;
                pnlChiTiet.Visible = kq;
                picCTCB.Image = Resources.arrow_up;

            }
        }
        public void resetForm()
        {
            showDV(false, 0);
            XuLy();
            picCTCB.Image = Resources.arrow_down;
            co = 0;
            pnlHangVe1.BackColor = Color.White;
            pnlHangVe2.BackColor = Color.White;
            pnlHangVe3.BackColor = Color.White;
            pnlHangVe4.BackColor = Color.White;

            picCTVe1.BackColor = Color.White;
            picCTVe2.BackColor = Color.White;
            picCTVe3.BackColor = Color.White;
            picCTVe4.BackColor = Color.White;
        }
        #endregion

        #region Phương thức của form
        //Phương thức click cho mỗi hạng vé
        private void pnlHangVe1_Click(object sender, EventArgs e)
        {
            ParentForm.resetAllform();
            if(pnlHangVe1.BackColor == Color.White)
            {
                pnlHangVe1.BackColor = Color.PaleTurquoise;
                pnlChiTiet.BackColor = Color.PaleTurquoise;
                picCTVe1.BackColor = Color.PaleTurquoise;
                showDV(true, 1);

                pnlHangVe4.BackColor = Color.White;
                picCTVe4.BackColor = Color.White;
                pnlHangVe3.BackColor = Color.White;
                picCTVe3.BackColor = Color.White;
                pnlHangVe2.BackColor = Color.White;
                picCTVe2.BackColor = Color.White;
            }
            else
            {
                pnlChiTiet.BackColor = Color.White;
                showDV(false, 1);
                showDV(false, 0);
                XuLy();
            }
            Tienve = lblGiaHV1.Text + ".000";
            Hangve = "HV001";
            ParentForm.HandleButtonClick(this, Hangve, Tienve, tg_di, tg_den, ma_chuyenbay);
        }
        private void pnlHangVe2_Click(object sender, EventArgs e)
        {
            ParentForm.resetAllform();
            if (pnlHangVe2.BackColor == Color.White)
            {
                pnlHangVe2.BackColor = Color.PeachPuff;
                pnlChiTiet.BackColor = Color.PeachPuff;
                picCTVe2.BackColor = Color.PeachPuff;
                showDV(true, 2);

                pnlHangVe4.BackColor = Color.White;
                picCTVe4.BackColor = Color.White;
                pnlHangVe3.BackColor = Color.White;
                picCTVe3.BackColor = Color.White;
                pnlHangVe1.BackColor = Color.White;
                picCTVe1.BackColor = Color.White;
            }
            else
            {
                pnlChiTiet.BackColor = Color.White;
                showDV(false, 2);
                showDV(false, 0);
                XuLy();
            }
            Tienve = lblGiaHV2.Text + ".000";
            Hangve = "HV002";
            ParentForm.HandleButtonClick(this, Hangve, Tienve, tg_di, tg_den, ma_chuyenbay);
        }
        private void pnlHangVe3_Click(object sender, EventArgs e)
        {
            ParentForm.resetAllform();
            if (pnlHangVe3.BackColor == Color.White)
            {
                pnlHangVe3.BackColor = Color.LightSalmon;
                pnlChiTiet.BackColor = Color.LightSalmon;
                picCTVe3.BackColor = Color.LightSalmon;
                showDV(true, 3);

                pnlHangVe4.BackColor = Color.White;
                picCTVe4.BackColor = Color.White;
                pnlHangVe2.BackColor = Color.White;
                picCTVe2.BackColor = Color.White;
                pnlHangVe1.BackColor = Color.White;
                picCTVe1.BackColor = Color.White;
            }
            else
            {
                pnlChiTiet.BackColor = Color.White;
                showDV(false, 3);
                showDV(false, 0);
                XuLy();
            }
            Tienve = lblGiaHV3.Text + ".000";
            Hangve = "HV003";
            ParentForm.HandleButtonClick(this, Hangve, Tienve, tg_di, tg_den, ma_chuyenbay);
        }
        private void pnlHangVe4_Click(object sender, EventArgs e)
        {
            ParentForm.resetAllform();
            if (pnlHangVe4.BackColor == Color.White)
            {
                pnlHangVe4.BackColor = Color.Wheat;
                pnlChiTiet.BackColor = Color.Wheat;
                picCTVe4.BackColor = Color.Wheat;
                showDV(true, 4);

                pnlHangVe3.BackColor = Color.White;
                picCTVe3.BackColor = Color.White;
                pnlHangVe2.BackColor = Color.White;
                picCTVe2.BackColor = Color.White;
                pnlHangVe1.BackColor = Color.White;
                picCTVe1.BackColor = Color.White;
            }
            else
            {
                pnlChiTiet.BackColor = Color.White;
                showDV(false, 4);
                showDV(false, 0);
                XuLy();
            }
            Tienve = lblGiaHV4.Text + ".000";
            Hangve = "HV004";
            ParentForm.HandleButtonClick(this, Hangve, Tienve, tg_di, tg_den, ma_chuyenbay);
        }
        int co = 0;
        private void pnlTTCB_Click(object sender, EventArgs e)
        {
            //if (pnlChiTiet.BackColor == Color.ForestGreen)
            //{
            //    pnlChiTiet.BackColor = Color.GreenYellow;
            //}
            //pnlsize 931, 146
            //frmsize 939, 313
            if(co == 0)
            {
                showDV(true,0);
                picCTCB.Image = Resources.arrow_up;
                pnlChiTiet.BackColor = Color.PaleGreen;
                co += 1;

                pnlHangVe4.BackColor = Color.White;
                picCTVe4.BackColor = Color.White;
                pnlHangVe3.BackColor = Color.White;
                picCTVe3.BackColor = Color.White;
                pnlHangVe2.BackColor = Color.White;
                picCTVe2.BackColor = Color.White;
                pnlHangVe1.BackColor = Color.White;
                picCTVe1.BackColor = Color.White;
            }
            else
            {
                showDV(false, 0);
                picCTCB.Image = Resources.arrow_down;
                co -= 1;
                pnlChiTiet.BackColor = Color.White;

                pnlHangVe4.BackColor = Color.White;
                picCTVe4.BackColor = Color.White;
                pnlHangVe3.BackColor = Color.White;
                picCTVe3.BackColor = Color.White;
                pnlHangVe2.BackColor = Color.White;
                picCTVe2.BackColor = Color.White;
                pnlHangVe1.BackColor = Color.White;
                picCTVe1.BackColor = Color.White;
            }
        }
        #endregion
    }
}
