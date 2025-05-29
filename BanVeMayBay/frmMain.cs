using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BanVeMayBay.frmChonDV;

namespace BanVeMayBay
{
    public partial class frmMain : Form
    {
        #region Khai báo

        public string TongTien = string.Empty;
        string __PhuongThucTT = "null";
        string __TenNganHang = "NHnull";
        int flag = 1;
        frmThanhToan frmthanhtoan;
        public string __ngaybay;
        public string __diemkhoihanh;
        public string __diemden;
        public string __slTTND;
        string tenDiaDiemKhoiHanh;
        string tenDiaDiemDen;
        TTCHUYENBAY ttcb = new TTCHUYENBAY();
        public string __Hangve;
        public string __TienVe;
        public string __tgdi;
        public string __tgden;
        public string __machuyenbay;
        public string __ViTriGhe;
        public string __TienViTriGhe;
        public string __GoiHanhLy;
        public string __TienGoiHanhLy;

        DB_Connet DB = new DB_Connet();
        TTNguoiLon DBNL = new TTNguoiLon();
        TTTreEm DBTE = new TTTreEm();
        TTEmBe DBEB = new TTEmBe();
        TTCHUYENBAY dbCB = new TTCHUYENBAY();

        List<TTNguoiLon> lstNguoiLon = new List<TTNguoiLon>();
        List<TTEmBe> lstEmBe = new List<TTEmBe>();
        List<TTTreEm> lstTreEm = new List<TTTreEm>();
        List<TTCHUYENBAY> lstCB = new List<TTCHUYENBAY>();

        public List<TTNguoiLon> ListNguoiLon { get; private set; } = new List<TTNguoiLon>();
        public List<TTEmBe> ListEmBe { get; private set; } = new List<TTEmBe>();
        public List<TTTreEm> ListTreEm { get; private set; } = new List<TTTreEm>();
        public List<frmVe> frmVes = new List<frmVe>();
        #endregion

        private frmChonDV frmDVInstance;
        bool checkClick = false;
        string tennguoidung;
        public frmMain(string TenNguoiDung)
        {
            InitializeComponent();
            this.tennguoidung = TenNguoiDung;
            lblChaoNguoiDung.Text = "Xin Chào " + tennguoidung;
            frmDVInstance = new frmChonDV();
            frmDVInstance.LabelTextChanged += FrmDVInstance_LabelTextChanged;
        }

        #region Xử lý trên giao diện
        private void frmMain_Load(object sender, EventArgs e)
        {
            firstLoad();
        }
        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void picReset_Click(object sender, EventArgs e)
        {
            getResetClick();
        }
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
            return;
        }
        #endregion

        #region Phương thức xử lý thông tin
        void firstLoad()
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
        private string getDiaDiemSanBay(string maSanBay)
        {
            string caulenh = "select DiaDiem from SANBAY where MaSanBay = '" + maSanBay + "'";
            string kq = (string)DB.GetExecuteScalar(caulenh);
            return kq;
        }
        private void XuLy_btnDiTiep(int index)
        {
            frmTTVeDat frmttvd;
            frmDVInstance.LabelTextChanged += FrmDVInstance_LabelTextChanged;
            if (index == 1)
            {
                getDanhSachVe(__diemkhoihanh.Trim(), __diemden.Trim(), __ngaybay);
                flowLayoutPnlThanGianDien.Controls.Clear();
                flowLayoutPnlThanGianDien.Padding = new Padding(0, 0, 0, 0);
                pnlThanGiaoDien.Location = new Point(312, 285);
                pnlThanGiaoDien.Height -= 50;
                lblHangVe1.Visible = true;
                lblHangVe4.Visible = true;
                loadDanhSachtoFrmVe(lstCB.Count());

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmttvd = new frmTTVeDat(__slTTND,__TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, tenDiaDiemKhoiHanh, tenDiaDiemDen, "0", "0", "0", "0");
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                lblTongTien.Text = frmttvd.GetThanhTien() + " VND";
                frmttvd.Show();

                flag = 2;
            }
            if (index == 2)
            {
                if(!checkClick)
                {
                    MessageBox.Show("Vui lòng chọn vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    getDanhSachVe(__diemkhoihanh.Trim(), __diemden.Trim(), __ngaybay);
                    loadDanhSachtoFrmVe(lstCB.Count());
                    return;
                }    
                lblHangVe1.Visible = false;
                lblHangVe4.Visible = false;

                pnlThanGiaoDien.Location = new Point(0, 229);
                pnlThanGiaoDien.Height += 50;
                flowLayoutPnlThanGianDien.Controls.Clear();
                frmDVInstance.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmDVInstance);
                frmDVInstance.Show();

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmttvd = new frmTTVeDat(__slTTND, __TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, tenDiaDiemKhoiHanh, tenDiaDiemDen, "0", "0", "0", "0");
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                frmttvd.TinhThanhTien(__TienVe, "0", "0");
                lblTongTien.Text = frmttvd.GetThanhTien() + " VND";
                frmttvd.Show();

                flag = 3;
            }
            if (index == 3)
            {
                __ViTriGhe = frmDVInstance.lblMaGhe.Text;
                __TienViTriGhe = frmDVInstance.lblTienGhe.Text;
                __GoiHanhLy = frmDVInstance.lblGoiHanhLy.Text;
                __TienGoiHanhLy = frmDVInstance.lblTienHL.Text;

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmttvd = new frmTTVeDat(__slTTND, __TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, tenDiaDiemKhoiHanh, tenDiaDiemDen, __ViTriGhe, __TienViTriGhe, __GoiHanhLy, __TienGoiHanhLy);
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                frmttvd.TinhThanhTien(__TienVe, __TienViTriGhe, __TienGoiHanhLy);
                lblTongTien.Text = frmttvd.GetThanhTien() + " VND";
                TongTien = frmttvd.GetThanhTien();
                frmttvd.Show();

                pnlThanGiaoDien.Location = new Point(25, 229);
                flowLayoutPnlThanGianDien.Controls.Clear();

                btnDiTiep.BackColor = Color.Gold;
                btnDiTiep.Text = "Thanh Toán";
                btnDiTiep.ForeColor = Color.Black;
                btnDiTiep.Font = new Font(btnDiTiep.Font, FontStyle.Bold | FontStyle.Italic);

                frmthanhtoan = new frmThanhToan(TongTien);
                frmthanhtoan.ThanhTien();
                frmthanhtoan.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmthanhtoan);
                frmthanhtoan.Show();

                //if (!frmthanhtoan.checkClick)
                //{
                //    MessageBox.Show("Vui lòng chọn phương thức thanh toán trước!");
                //    return;
                //}
                //else
                flag = 4;
            }
            if (index == 4)
            {
                //string tongtienstr = TongTien.ToString("N0");
                __PhuongThucTT = frmthanhtoan.getHinhThucTT();
                frmHoaDon_ThanhToan frmHDTT = new frmHoaDon_ThanhToan(tennguoidung, __slTTND, __TienVe, __TienViTriGhe, __TienGoiHanhLy, TongTien);
                __TenNganHang = frmthanhtoan.getTenNganHang();
                frmQR_ThanhToan frmQRTT = new frmQR_ThanhToan(__TenNganHang, TongTien);
                string caulenh;
                Random rd = new Random();
                int countid = (int)DB.GetExecuteScalar("SELECT COUNT(ID) FROM HANHKHACH");
                int randID = rd.Next(1, countid);
                if (__PhuongThucTT == "Chuyển khoản")
                {
                    frmQRTT.Show();
                    caulenh = "INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) VALUES (GETDATE(), " + TongTien.Replace(".", "") + ", N'" + __PhuongThucTT + "', N'Ðã thanh toán', " + randID + ")";
                }//INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) VALUES (GETDATE(), 10000000, N'Chuyển khoản', N'Ðã thanh toán', 1)
                else caulenh = "INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) VALUES (GETDATE(), " + TongTien.Replace(".", "") + ", N'" + __PhuongThucTT + "', N'Chưa thanh toán', " + randID + ")";

                try
                {
                    var kq = DB.GetExecuteNonQuery(caulenh);
                    if(kq != 0)
                    {
                        caulenh = "UPDATE TUYENBAY SET SoVeDaBan = SoVeDaBan + 1, SoVeConLai = SoVeConLai - 1 WHERE MaTuyenBay = '" + __machuyenbay + "'";
                        DB.GetExecuteNonQuery(caulenh);
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm hóa đơn thất bại\nLỗi: " + ex.Message);
                }

                frmHDTT.Show();
                //getResetClick();
                //frmHDTT.TopLevel = true;
                flag = 5;
            }
        }

        public void ShowTTCB(int slNL, int slTE, int slEB, string ngaybay, string diemkhoihanh, string diemden)
        {
            int sl = slNL + slTE + slEB;
            __slTTND = sl.ToString();

            string TTHK = "1 NGƯỜI LỚN";
            if(slNL != 1)
            {
                TTHK = slNL.ToString() + " NGƯỜI LỚN";
            }   
            if(slTE != 0)
            {
                TTHK += ", " + slTE.ToString() + " TRẺ EM";
            }    
            if(slEB != 0)
            {
                TTHK += ", " + slTE.ToString() + " EM BÉ";
            }
            lblChuyenBayKHMC.Text = "CHUYẾN BAY MỘT CHIỀU | " + TTHK;

            __ngaybay = ngaybay;
            //__diemkhoihanh = ttcb.TenSanBay(diemkhoihanh);
            //__diemden = ttcb.TenSanBay(diemden);
            __diemkhoihanh = diemkhoihanh;
            __diemden = diemden;

            tenDiaDiemKhoiHanh = getDiaDiemSanBay(__diemkhoihanh);
            tenDiaDiemDen = getDiaDiemSanBay(__diemden);

            pnlTTCB.Visible = true;
            pnlTTCB.Location = new Point(0, 144);
            lblDiemKhoiHanh.Text = tenDiaDiemKhoiHanh;
            lblDiemDen.Text = tenDiaDiemDen;
            pnlThanGiaoDien.Location = new Point(0, 229);
                                               
            //xuất hiện footer chứa nút đi tiếp
            pnlThanGiaoDien.Height -= 171;
            pnlDuoiGiaoDien.Visible = true;

            pnlThanGiaoDien.Width -= 555;
            flowLayoutPnlThanGianDien.Width -= 555;
            pnlTTVeDat.Visible = true;
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
        public void getDanhSachVe(string diemkhoihanh, string diemden, string ngaybay)
        {
            lstCB = dbCB.GetLSTChuyenBay(diemkhoihanh, diemden, ngaybay);

        }
        private void loadDanhSachtoFrmVe(int sl)
        {
            foreach (var item in lstCB)
            {
                frmVe frmv = new frmVe(item.DiemKhoiHanh, item.DiemDen, __ngaybay, item.ThoiGianDi.ToString(), item.ThoiGianDen.ToString(), item.MaChuyenBay, item.MaMayBay, item.LoaiMB);
                frmv.SetParentForm(this);
                frmv.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmv);
                frmVes.Add(frmv);
                frmv.Show();
            }
        }
        private void getResetClick()
        {
            this.Hide();
            Form frmm = new frmMain(tennguoidung);
            frmm.FormClosed += (s, args) => this.Close();
            frmm.Show();
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
                    checkClick = true;
                }
            }
        }
        #endregion

        #region Nhận dữ liệu từ formDV
        private void FrmDVInstance_LabelTextChanged(object sender, LabelDataEventArgs e)
        {
            // Xử lý khi giá trị của các label trong frmDV thay đổi
            string Event_TenViTriGhe = e.Event_TenViTriGhe;
            string Event_GiaViTriGhe = e.Event_GiaViTriGhe;
            string Event_TenGoi = e.Event_TenGoi;
            string Event_GiaGoi = e.Event_GiaGoi;
        }
        #endregion

        #region Xử lý dữ liệu khách hàng
        bool check = true;
        public void NhapKhachHang()
        {
            check = true;
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
                        flag = 1;
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
                        flag = 1;
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
                        flag = 1;
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
                    try
                    {
                        int result = DBNL.ThemKH_NguoiLon(nl);
                        if (result == 0)
                        {
                            MessageBox.Show("Thêm thông tin khách hàng[NL] thất bại!", "Thông Báo", MessageBoxButtons.OK);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thông tin khách hàng[NL] thất bại!\nLỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    }
                }
                foreach (TTTreEm treem in lstTreEm)
                {
                    try
                    {
                        int result = DBTE.ThemKH_TreEm(treem);
                        if (result == 0)
                        {
                            MessageBox.Show("Thêm thông tin khách hàng[TE] thất bại!", "Thông Báo", MessageBoxButtons.OK);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thông tin khách hàng[TE] thất bại!\nLỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    }
                }
                foreach (TTEmBe embe in lstEmBe)
                {
                    try
                    {
                        int result = DBEB.ThemKH_EmBe(embe);
                        if (result == 0)
                        {
                            MessageBox.Show("Thêm thất bại", "Thông Báo", MessageBoxButtons.OK);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thông tin khách hàng[EB] thất bại!\nLỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            frmTTVeDat frmttvd;
            int index = flag;
            if (index == 2)
            {
                NhapKhachHang();
                if (check)
                {
                    //AddTTKhachHangVaoSql();
                    flowLayoutPnlThanGianDien.Controls.Clear();
                    frmChonDV frmDV = new frmChonDV();
                    frmDV.TopLevel = false;
                    XuLy_btnDiTiep(flag);
                }
                lstNguoiLon.Clear();
                lstTreEm.Clear();
                lstEmBe.Clear();
                return;
            }
            else if(index == 3) 
            {            
                getDanhSachVe(__diemkhoihanh.Trim(), __diemden.Trim(), __ngaybay);
                flowLayoutPnlThanGianDien.Controls.Clear();
                flowLayoutPnlThanGianDien.Padding = new Padding(0, 0, 0, 0);
                pnlThanGiaoDien.Location = new Point(312, 285);
                pnlThanGiaoDien.Height -= 50;
                lblHangVe1.Visible = true;
                lblHangVe4.Visible = true;
                loadDanhSachtoFrmVe(lstCB.Count());

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmttvd = new frmTTVeDat(__slTTND, __TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, tenDiaDiemKhoiHanh, tenDiaDiemDen, "0", "0", "0", "0");
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                lblTongTien.Text = frmttvd.GetThanhTien() + " VND";
                frmttvd.Show();
                return;
            }
            else if(index == 4)
            {
                __ViTriGhe = frmDVInstance.lblMaGhe.Text;
                __TienViTriGhe = frmDVInstance.lblTienGhe.Text;
                __GoiHanhLy = frmDVInstance.lblGoiHanhLy.Text;
                __TienGoiHanhLy = frmDVInstance.lblTienHL.Text;

                flowLayoutPanelTTVeDat.Controls.Clear();
                frmttvd = new frmTTVeDat(__slTTND, __TienVe, __ngaybay, __tgdi, __tgden, __machuyenbay, __Hangve, tenDiaDiemKhoiHanh, tenDiaDiemDen, __ViTriGhe, __TienViTriGhe, __GoiHanhLy, __TienGoiHanhLy);
                frmttvd.TopLevel = false;
                flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
                frmttvd.TinhThanhTien(__TienVe, __TienViTriGhe, __TienGoiHanhLy);
                lblTongTien.Text = frmttvd.GetThanhTien() + " VND";
                TongTien = frmttvd.GetThanhTien();
                frmttvd.Show();

                pnlThanGiaoDien.Location = new Point(25, 229);
                flowLayoutPnlThanGianDien.Controls.Clear();

                btnDiTiep.BackColor = Color.Gold;
                btnDiTiep.Text = "Thanh Toán";
                btnDiTiep.ForeColor = Color.Black;
                btnDiTiep.Font = new Font(btnDiTiep.Font, FontStyle.Bold | FontStyle.Italic);

                frmthanhtoan = new frmThanhToan(TongTien);
                frmthanhtoan.ThanhTien();
                frmthanhtoan.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmthanhtoan);
                frmthanhtoan.Show();
            }
            //else if(index == 5)
            //{
            //    //string tongtienstr = TongTien.ToString("N0");
            //    __PhuongThucTT = frmthanhtoan.getHinhThucTT();
            //    frmHoaDon_ThanhToan frmHDTT = new frmHoaDon_ThanhToan(tennguoidung, __slTTND, __TienVe, __TienViTriGhe, __TienGoiHanhLy, TongTien);
            //    __TenNganHang = frmthanhtoan.getTenNganHang();
            //    frmQR_ThanhToan frmQRTT = new frmQR_ThanhToan(__TenNganHang, TongTien);
            //    string caulenh;
            //    Random rd = new Random();
            //    int countid = (int)DB.GetExecuteScalar("SELECT COUNT(ID) FROM HANHKHACH");
            //    int randID = rd.Next(1, countid);
            //    if (__PhuongThucTT == "Chuyển khoản")
            //    {
            //        frmQRTT.Show();
            //        caulenh = "INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) VALUES (GETDATE(), " + TongTien.Replace(".", "") + ", N'" + __PhuongThucTT + "', N'Ðã thanh toán', " + randID + ")";
            //    }//INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) VALUES (GETDATE(), 10000000, N'Chuyển khoản', N'Ðã thanh toán', 1)
            //    else caulenh = "INSERT INTO HOADON(NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon, IDHanhKhach) VALUES (GETDATE(), " + TongTien.Replace(".", "") + ", N'" + __PhuongThucTT + "', N'Chưa thanh toán', " + randID + ")";

            //    try
            //    {
            //        var kq = DB.GetExecuteNonQuery(caulenh);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Thêm hóa đơn thất bại\nLỗi: " + ex.Message);
            //    }

            //    frmHDTT.Show();
            //    getResetClick();
            //}    

        }
    }
}
