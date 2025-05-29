using BanVeMayBay.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmThanhToan : Form
    {
        string _TamTinh;
        string _HinhThucThanhToan;
        string _TrangThaiHoaDon;
        string _TenNganHang;
        public bool checkClick = false;
        List<Label> labels = new List<Label>();
        public string TamTinh { get => _TamTinh; set => _TamTinh = value; }
        public string HinhThucThanhToan { get => _HinhThucThanhToan; set => _HinhThucThanhToan = value; }
        public string TrangThaiHoaDon { get => _TrangThaiHoaDon; set => _TrangThaiHoaDon = value; }
        public string TenNganHang { get => _TenNganHang; set => _TenNganHang = value; }

        public frmThanhToan(string tamtinh)
        {
            InitializeComponent();
            labels.AddRange(new[] {
                lbl_LineMB, lbl_LineSacombank, lbl_LineAgribank,
                lbl_LineVietcombank, lbl_LineVietinbank, lbl_LineACB,
                lbl_LineBIDV, lbl_LineTechcombank, lbl_LineOCB,
                lbl_LineTienMat
            });

            this.TamTinh = tamtinh;
        }
        #region Xử lý giao diện
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblTamTinh.Text = TamTinh;
        }
        private void pnlMB_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineMB);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "MB";
            checkClick = true;
        }

        private void pnlSacombank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineSacombank);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "Sacombank";
            checkClick = true;
        }

        private void pnlAgribank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineAgribank);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "Agribank";
            checkClick = true;
        }

        private void pnlVietcombank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineVietcombank);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "Vietcombank";
            checkClick = true;
        }

        private void pnlVietinbank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineVietinbank);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "Vietinbank";
            checkClick = true;
        }

        private void pnlACB_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineACB);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "ACB";
            checkClick = true;
        }

        private void pnlBIDV_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineBIDV);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "BIDV";
            checkClick = true;
        }

        private void pnlTechcombank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineTechcombank);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "Techcombank";
            checkClick = true;
        }

        private void pnlOCB_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineOCB);
            setTrangThaiHD_HinhThucTT("Chuyển khoản", "Đã thanh toán");
            this.TenNganHang = "OCB";
            checkClick = true;
        }


        private void pnlTienMat_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineTienMat);
            setTrangThaiHD_HinhThucTT("Trả tiền mặt", "Đã thanh toán");
            checkClick = true;
        }
        public void XulyLine(object sender)
        {
            Label lbl_click = sender as Label;
            foreach (Label item in labels)
            {
                item.Visible = false;
            }
            lbl_click.Visible = true;
        }
        #endregion
        #region Phương thức chức năng
        public void ThanhTien()
        {
            #region Vì là không có giảm giá gì cả, nên không tính nhá
            //float tamtinh = float.Parse(TamTinh.Replace(".", ""));
            //float giamgia = float.Parse(lblKhuyenMai.Text.Replace(".", ""));
            //float tongtien = tamtinh - giamgia;
            //lblTongTien.Text = string.Format("{0:n0}", tongtien);
            //lblTongTien.Text = string.Format("{0:n0}", tamtinh);
            #endregion

            lblTongTien.Text = TamTinh;
        }
        private void setTrangThaiHD_HinhThucTT(string __HinhThucThanhToan, string __TrangThaiHoaDon)
        {
            HinhThucThanhToan = __HinhThucThanhToan;
            TrangThaiHoaDon = __TrangThaiHoaDon;
        }
        public string getHinhThucTT()
        {
            return HinhThucThanhToan;
        }
        public string getTenNganHang()
        {
            return TenNganHang;
        }
        #endregion
    }
}
