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
        #region Khai báo các Data
        DB_Connet DB = new DB_Connet();
        TTNguoiLon DBNL = new TTNguoiLon();
        TTTreEm DBTE = new TTTreEm();
        TTEmBe DBEB = new TTEmBe();
        TTCHUYENBAY dbCB=new TTCHUYENBAY();


        List<TTNguoiLon> lstNguoiLon = new List<TTNguoiLon>();
        List<TTEmBe> lstEmBe = new List<TTEmBe>();
        List<TTTreEm> lstTreEm = new List<TTTreEm>();
        List<TTCHUYENBAY> lstCB=new List<TTCHUYENBAY>();

        frmNhapTT_NguoiLon frmNL;
        frmNhapTT_TreEm frmTreEm;
        frmNhapTT_EmBe frmEmBe;
        public List<TTNguoiLon> ListNguoiLon { get; private set; } = new List<TTNguoiLon>();
        public List<TTEmBe> ListEmBe { get; private set; } = new List<TTEmBe>();
        public List<TTTreEm> ListTreEm { get; private set; } = new List<TTTreEm>();
        public List<frmVe> frmVes = new List<frmVe>();
        #endregion

        string idtaikhoan;
        string tennguoidung;
        public frmMain(string TenNguoiDung, string idtaikhoan)
        {
            this.tennguoidung = TenNguoiDung;
            this.idtaikhoan = idtaikhoan;
            InitializeComponent();
            lblChaoNguoiDung.Text = "Xin Chào" + tennguoidung;
        }


       
        private void frmMain_Load(object sender, EventArgs e)
        {
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
            Form frmm = new frmMain(tennguoidung, idtaikhoan);
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
        public void GetLstDSVe(string diemkhoihanh, string diemden, string ngaybay)
        {
            lstCB = dbCB.GetLSTChuyenBay(diemkhoihanh, diemden, ngaybay);

        }
        private void loadd_DSfrmVe(int sl)
        {
            foreach (var item in lstCB)
            {
                frmVe frmv = new frmVe(item.DIemKhoiHanh, item.DiemDen, __ngaybay, item.ThoiGianDi.ToString(), item.ThoiGianDen.ToString(), item.MaChuyenBay, item.MaMayBay);
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
                GetLstDSVe(__diemkhoihanh, __diemden, __ngaybay);
                flowLayoutPnlThanGianDien.Controls.Clear();
                flowLayoutPnlThanGianDien.Padding = new Padding(0, 0, 0, 0);
                pnlThanGiaoDien.Location = new Point(312, 285);
                pnlThanGiaoDien.Height -= 50;
                lblHangVe1.Visible = true;
                lblHangVe2.Visible = true;
                lblHangVe3.Visible = true;
                lblHangVe4.Visible = true;
                loadd_DSfrmVe(lstCB.Count());

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
        #region Lấy dữ liệu khách hàng
        bool check = true;
        public void NhapKhachHang()
        {
            foreach (Control control in flowLayoutPnlThanGianDien.Controls) // Lặp qua các điều khiển trong flowLayoutPanelTT
            {
                if (control is frmNhapTT_NguoiLon frmNL)
                {
                    TTNguoiLon nl = new TTNguoiLon();
                    nl = frmNL.GetKhachHang(); // Gọi phương thức GetKhachHang để lấy thông tin
                    if (nl == null)
                    {
                        check = false;
                        MessageBox.Show("Thông tin người lớn không hợp lệ."); // Hiển thị thông báo lỗi
                        return; // Dừng quá trình nếu thông tin là null
                    }
                    lstNguoiLon.Add(nl); // Thêm vào danh sách
                }
                else if (control is frmNhapTT_TreEm frmTE)
                {
                    TTTreEm trem = frmTE.GetKhachHang(); // Gọi phương thức GetKhachHang để lấy thông tin
                    if (trem == null)
                    {
                        check = false;
                        MessageBox.Show("Thông tin trẻ em không hợp lệ."); // Hiển thị thông báo lỗi
                        return; // Dừng quá trình nếu thông tin là null
                    }
                    lstTreEm.Add(trem); // Thêm vào danh sách
                }
                else if (control is frmNhapTT_EmBe frmEB)
                {
                    TTEmBe EMBE = frmEB.GetKhachHang(); // Gọi phương thức GetKhachHang để lấy thông tin
                    if (EMBE == null)
                    {
                        check = false;
                        MessageBox.Show("Thông tin em bé không hợp lệ."); // Hiển thị thông báo lỗi
                        return; // Dừng quá trình nếu thông tin là null
                    }
                    lstEmBe.Add(EMBE); // Thêm vào danh sách
                }
            }
        }
        public void AddTTKhachHangVaoSql()
        {
            if (lstNguoiLon.Count > 0)
            {
                foreach (TTNguoiLon nl in lstNguoiLon)
                {

                    int result = DBNL.ThemTaiKHoan(nl, idtaikhoan);
                    if (result == 0)
                    {
                        MessageBox.Show("Thêm thất bại", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                foreach (TTTreEm treem in lstTreEm)
                {
                    int result = DBTE.ThemTaiKHoan(treem, idtaikhoan);
                    if (result == 0)
                    {
                        MessageBox.Show("Thêm thất bại", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                foreach (TTEmBe embe in lstEmBe)
                {
                    int result = DBEB.ThemTaiKHoan(embe, idtaikhoan);
                    if (result == 0)
                    {
                        MessageBox.Show("Thêm thất bại", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion
        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            NhapKhachHang();
            if (check)
            {
                AddTTKhachHangVaoSql();
                flowLayoutPnlThanGianDien.Controls.Clear();
                frmChonDV frmDV = new frmChonDV();
                frmDV.TopLevel = false;
                XuLy_btnDiTiep(flag);   
            }
             lstNguoiLon.Clear();
            lstTreEm.Clear();
            lstEmBe.Clear();
        }
    }
}
