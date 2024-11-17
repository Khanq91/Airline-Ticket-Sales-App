using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;

namespace BanVeMayBay
{
    public partial class frmHoaDon_ThanhToan : Form
    {
        string _TenNV, _SL_Ve, _GiaVe, _ThueVe, _GiaGhe, _GiaGoiHL, _TongTT;
        DB_Connet db = new DB_Connet();
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public string SL_Ve { get => _SL_Ve; set => _SL_Ve = value; }
        public string GiaVe { get => _GiaVe; set => _GiaVe = value; }
        public string ThueVe { get => _ThueVe; set => _ThueVe = value; }
        public string GiaGhe { get => _GiaGhe; set => _GiaGhe = value; }
        public string GiaGoiHL { get => _GiaGoiHL; set => _GiaGoiHL = value; }
        public string TongTT { get => _TongTT; set => _TongTT = value; }
        bool LoadDuLieu = false;
        public frmHoaDon_ThanhToan(string tenNV, string sl_Ve, string giaVe, string giaGhe, string giaGoiHL, string tongTT)
        {
            InitializeComponent();
            this.TenNV = tenNV;
            this.SL_Ve = sl_Ve;
            this.GiaVe = giaVe;
            this.GiaGhe = giaGhe;
            this.GiaGoiHL = giaGoiHL;
            this.TongTT = tongTT;
            LoadDuLieu = true;
        }
        private void frmHoaDon_ThanhToan_Load(object sender, EventArgs e)
        {
            if(LoadDuLieu)
            {
                Load_MaHD();
                Load_DuLieuHD();
                Add_CTHD();
            }
        }
        private void lblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void trảTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string caulenh = "SELECT MAX(ID) FROM HOADON";
            int KtraID = (int)db.GetExecuteScalar(caulenh);
            caulenh = "update HOADON set TrangThaiHoaDon = N'Đã thanh toán' where ID = " + KtraID;
            //string caulenh = "update HOADON set TrangThaiHoaDon = N'Đã thanh toán' where MaHoaDon = 'HD202411001'";
            try
            {
                var kq = db.GetExecuteNonQuery(caulenh);
                if (kq > 0)
                {
                    MessageBox.Show("Đã thanh toán!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán lỗi!" + ex.Message);
            }
        }
        private void Load_MaHD()
        {
            string NamThang = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();

            string caulenh = "SELECT MAX(CAST(SUBSTRING(MaHoaDon, 9, 3) AS INT)) FROM HOADON WHERE MaHoaDon LIKE 'HD%'";
            int KTRAmaHD;
            var result = db.GetExecuteScalar(caulenh);
            if (result != DBNull.Value)
            {
                KTRAmaHD = Convert.ToInt32(result) + 1;
            }
            else
            {
                KTRAmaHD = 1;
            }
            string maHD = $"{KTRAmaHD:D3}";

            lblMaHD.Text = "HD" + NamThang + maHD;
        }
        private void Load_DuLieuHD()
        {
            lblNgayLapHD.Text = DateTime.Now.ToShortDateString();
            lblTen_NV.Text = TenNV;
            lblSL_Ve.Text = SL_Ve + " x";
            lblGiaVe.Text = GiaVe;
            lblGiaGhe.Text = GiaGhe;
            lblGiaGoiHanhLy.Text = GiaGoiHL;

            float ThueVe = float.Parse(GiaVe) * int.Parse(SL_Ve) * 0.1f;
            lblThue_Ve.Text = ThueVe.ToString("N0");

            lblTongThanhToan.Text = TongTT;
        }
        private void Add_CTHD()
        {
            string __giaGhe = "";
            string __giaHL = "";
            if(lblGiaGhe.Text == "0")
            {
                __giaGhe = "0";
            }    
            else __giaGhe = lblGiaGhe.Text.Replace(".","");
            if (lblGiaGoiHanhLy.Text == "0")
                __giaHL = "0";
            else __giaHL = lblGiaGoiHanhLy.Text.Replace(".", "");

            string caulenh = "SELECT MAX(ID) FROM HOADON";
            int KtraID = (int)db.GetExecuteScalar(caulenh); 
            float TongThue = float.Parse(lblThue_Ve.Text.Replace(".", "")) + float.Parse(lblThue_PhuPhi.Text.Replace(".", ""));
            
            caulenh = "insert into CHITIETHOADON(ID, MaHoaDon, SL_Ve, Ve, Thue, PhuPhiHeThong, PhuPhiAnNinh, Ghe, HanhLy, KM_ThanhVienLauNam, KM_MaKhuyenMai, TenNhanVienTruc) " +
                "values (" + KtraID + ", '" + lblMaHD.Text + "', " + SL_Ve + ", " + lblGiaVe.Text.Replace(".", "") + ", " + TongThue.ToString() + ", 215000, 99000, " + __giaGhe + ", " + __giaHL + ", 0, 0, N'" + lblTen_NV.Text + "')";

            try
            {
                var kq = db.GetExecuteNonQuery(caulenh);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Thêm chi tiết hóa đơn thất bại!\nLỗi: " + ex.Message);
            }

        }

    }
}
