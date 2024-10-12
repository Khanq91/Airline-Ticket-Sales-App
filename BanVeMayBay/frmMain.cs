using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmMain : Form
    {
        public List<TTNguoiLon> ListNguoiLon { get; private set; } = new List<TTNguoiLon>();
        public List<TTEmBe> ListEmBe { get; private set; } = new List<TTEmBe>();
        public List<TTTreEm> ListTreEm { get; private set; } = new List<TTTreEm>();
        public List<frmVe> frmVes = new List<frmVe> ();

        string tennguoidung;
        public frmMain(string TenNguoiDung)
        {
            this.tennguoidung = TenNguoiDung;
            InitializeComponent();
            lblChaoNguoiDung.Text = "Xin Chào" + tennguoidung;
        }


        //void LamTrongSuotNenChu(Control x, PictureBox nenX) //x là textbox, nenX là pictureBox nằm dưới textbox
        //{
        //    var a = this.PointToScreen(x.Location);
        //    a = nenX.PointToClient(a);
        //    x.Parent = nenX;
        //    x.Location = a;
        //    x.BackColor = Color.Transparent;
        //}
        private void frmMain_Load(object sender, EventArgs e)
        {
            //nếu phân quyền là admin thì nút quản lý dữ liệu xuất hiện
            //btnQuanLy.Visible = true;
            pnlTTCB.Visible = false;
            pnlThanGiaoDien.Location = new Point(0, 140);
            frmDangNhap frmdn = new frmDangNhap();
            frmdn.Close();
            pnlDuoiGiaoDien.Visible = false;
            pnlThanGiaoDien.Height += 171;


            frmChonDiaDiemDatVe frmCDDDV = new frmChonDiaDiemDatVe();
            frmCDDDV.TopLevel = false;
            flowLayoutPnlThanGianDien.Controls.Add(frmCDDDV);
            frmCDDDV.Show();
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void picReset_Click(object sender, EventArgs e)
        {
            //phương thức reset form khi ấn nút reset
            this.Hide();
            Form frmm = new frmMain(tennguoidung);
            frmm.FormClosed += (s, args) => this.Close();
            frmm.Show();
        }
        #region Phương xử lý thông tin
        public string __ngaybay;
        public string __diemkhoihanh;
        public string __diemden;
        public void ShowTTCB(int slNL, int slTE, int slEB, string ngaybay, string diemkhoihanh, string diemden)
        {
            __ngaybay = ngaybay;
            __diemkhoihanh = diemkhoihanh;
            __diemden = diemden;
            pnlTTCB.Visible = true;
            pnlTTCB.Location = new Point(0, 144);
            pnlThanGiaoDien.Location = new Point(0, 229);
            //pnlThanGiaoDien.Height -= 200;
            //pnlThanGiaoDien.Height -= 84;

            //xuất hiện footer chứa nút đi tiếp
            pnlThanGiaoDien.Height -= 171;
            pnlDuoiGiaoDien.Visible = true;

            pnlThanGiaoDien.Width -= 555;
            flowLayoutPnlThanGianDien.Width -= 555;
            pnlTTVeDat.Visible = true;
            //flowLayoutPanelTTVeDat.Visible = true;
            //pnlThanGiaoDien.Size = new Size(1322, 602);
            flowLayoutPnlThanGianDien.Padding = new Padding(20, 20, 20, 20);
            xuatDSTTHK(slNL, slTE, slEB);
        }
        public void xuatDSTTHK(int slNL, int slTE, int slEB)
        {
            int i;
            for (i = 0; i < slNL; i++)
            {
                frmNhapTT_NguoiLon frmNL = new frmNhapTT_NguoiLon();
                frmNL.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmNL);
                frmNL.Show();
            }
            for (i = 0; i < slTE; i++)
            {
                frmNhapTT_TreEm frmTE = new frmNhapTT_TreEm();
                frmTE.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmTE);
                frmTE.Show();
            }
            for (i = 0; i < slEB; i++)
            {
                frmNhapTT_EmBe frmEB = new frmNhapTT_EmBe();
                frmEB.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmEB);
                frmEB.Show();
            }
            //btnNhapTTHK.Visible = true;
        }
        public void NhapKhachHang(List<TTNguoiLon> nguoiLon, List<TTEmBe> emBe, List<TTTreEm> treEm)
        {
            ListNguoiLon = nguoiLon;
            ListEmBe = emBe;
            ListTreEm = treEm;

            // Có thể hiển thị thông tin hoặc xử lý dữ liệu ở đây

            StringBuilder sb = new StringBuilder();
            foreach (var khachHang in ListNguoiLon)
            {
                sb.AppendLine($"Tên: {khachHang.TenKH}\nGiới tính: {khachHang.Gioitinh}\nNgày sinh: {khachHang.NgaySinh.ToShortDateString()}\n");
            }
            //MessageBox.Show(sb.ToString(), "Thông tin khách hàng");
        }
        //thêm thông tin vé tại đây
        private void loadd_DSfrmVe(int soluong)
        {
            //thông tin test cho các vé máy bay trong 1 ngày
            string[] diemkh_test = { "TP. HCM", "Cần Thơ", "Trà Vinh", "Hà Nội", "Vĩnh Long", "Nha Trang", "Huế", "Hải Phòng", "Cao Bằng", "Phú Quốc" };
            string[] diemden_test = { "Phú Quốc", "Cao Bằng", "Hải Phòng", "Huế", "Nha Trang", "Vĩnh Long", "Hà Nội", "Trà Vinh", "Cần Thơ", "TP. HCM" };
            string ngaykh_test = "9/1/2004";
            string[] tgdi_test = { "8:30", "9:30", "10:30", "11:30", "12:30", "13:30", "14:30", "15:30", "16:30", "17:30" };
            string[] tgden_test = { "11:30", "12:30", "13:30", "14:30", "15:30", "16:30", "17:30", "18:30", "19:30", "20:30" };
            string[] macb_test = { "CBDuo01", "CBDuo02", "CBDuo03", "CBDuo04", "CBDuo05", "CBDuo06", "CBDuo07", "CBDuo08", "CBDuo09", "CBDuo10", };
            string[] mamb_test = { "MBDuo01", "MBDuo02", "MBDuo03", "MBDuo04", "MBDuo05", "MBDuo06", "MBDuo07", "MBDuo08", "MBDuo09", "MBDuo10", };
            //Nhập số lượng vé từ sql vào n
            //còn thông tin của vé nhập bên form frmVe
            int n = soluong; //tỏng số lượng vé sẽ xuất hiện trên form
            for (int i = 0; i < n; i++)
            {
                //Truyền thông tin của vé vào (thời gian đi, thời gian đến, mã chuyến bay, mã máy bay)
                frmVe frmv = new frmVe(diemkh_test[i], diemden_test[i], ngaykh_test, tgdi_test[i], tgden_test[i], macb_test[i], mamb_test[i]);
                frmv.SetParentForm(this);
                frmv.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmv);
                frmVes.Add(frmv);
                frmv.Show();
            }
        }
        public void resetAllform()
        {
            foreach (Control crtl in flowLayoutPnlThanGianDien.Controls)
            {
                if (crtl is frmVe)
                {
                    frmVe frmv = (frmVe)crtl;
                    frmv.resetForm();
                }
            }
        }
        public string __Hangve;
        public string __TienVe;
        public string __tgdi;
        public string __tgden;
        public string __machuyenbay;
        public string __ViTriGhe;
        public string __TienViTriGhe;
        public string __GoiHanhLy;
        public string __TienGoiHanhLy;

        //kiểm tra xem form vé nào được click, lấy thông tin hạng vé và tiền vé
        public void HandleButtonClick(frmVe clickedForm, string hangve, string tienve, string tgdi, string tgden, string machuyenbay)
        {
            foreach (var item in frmVes)
            {
                if (item == clickedForm)
                {
                    __Hangve = hangve;
                    __TienVe = tienve;
                    __tgdi = tgdi;
                    __tgden = tgden;
                    __machuyenbay = machuyenbay;
                }
            }
        }
        #endregion

        int flag = 1;
        private void XuLy_btnDiTiep(int index)
        {
            if (index == 1)
            {
                flowLayoutPnlThanGianDien.Controls.Clear();
                flowLayoutPnlThanGianDien.Padding = new Padding(0, 0, 0, 0);
                pnlThanGiaoDien.Location = new Point(312, 285);
                pnlThanGiaoDien.Height -= 50;
                lblHangVe1.Visible = true;
                lblHangVe2.Visible = true;
                lblHangVe3.Visible = true;
                lblHangVe4.Visible = true;
                loadd_DSfrmVe(10);

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmTTVeDat frmttvd = new frmTTVeDat(__TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, __diemkhoihanh, __diemden, "0", "0", "0", "0");
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                frmttvd.Show();

                flag = 2;
            }
            if (index == 2)
            {
                lblHangVe1.Visible = false;
                lblHangVe2.Visible = false;
                lblHangVe3.Visible = false;
                lblHangVe4.Visible = false;

                pnlThanGiaoDien.Location = new Point(0, 229);
                pnlThanGiaoDien.Height += 50;
                flowLayoutPnlThanGianDien.Controls.Clear();
                frmChonDV frmDV = new frmChonDV();
                frmDV.TopLevel = false;
                __ViTriGhe = frmDV.TenViTriGhe;
                __TienViTriGhe = frmDV.GiaViTriGhe;
                __GoiHanhLy = frmDV.TenGoi;
                __TienGoiHanhLy = frmDV.GiaGoi;
                flowLayoutPnlThanGianDien.Controls.Add(frmDV);
                frmDV.Show();

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmTTVeDat frmttvd = new frmTTVeDat(__TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, __diemkhoihanh, __diemden, "0", "0", "0", "0");
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                frmttvd.Show();

                flag = 3;
            }
            if(index == 3)
            {
                flowLayoutPanelTTVeDat.Controls.Clear();
                frmTTVeDat frmttvd = new frmTTVeDat(__TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, __diemkhoihanh, __diemden, __ViTriGhe, __TienViTriGhe, __GoiHanhLy, __TienGoiHanhLy);
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                frmttvd.Show();

                flag = 4;
            }
        }
        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            NhapKhachHang(ListNguoiLon, ListEmBe, ListTreEm);
            XuLy_btnDiTiep(flag);
        }
    }
}
