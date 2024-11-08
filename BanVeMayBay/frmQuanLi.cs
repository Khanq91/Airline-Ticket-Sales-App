using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
//Thư viện cho chức năng xuất file Excel
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml.ConditionalFormatting.Contracts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BanVeMayBay
{
    public partial class frmQuanLi : Form
    {
        string tennguoidung;
        string role;
        string caulenh;
        bool ThemChangBay = false;
        DB_Connet db = new DB_Connet();
        DataTable dt_SanBay = new DataTable();
        DataTable dt_DiemKH = new DataTable();
        DataTable dt_DiemDen = new DataTable();
        DataTable dt_Ve = new DataTable();
        DataTable dt_HoaDon = new DataTable();
        DataTable dt_CTHoaDon = new DataTable();

        bool LoadDuLieu = false;
        public frmQuanLi(string tennguoidung, string role)
        {
            InitializeComponent();
            this.tennguoidung = tennguoidung;
            this.role = role;
            Load_SanBay();
            Load_HoaDon();
            Load_DiemKH(); 
            Load_Ve();
            LoadDuLieu = true;
        }
        //startPosition cho thân giao diện (396, 142), Size(1502, 782)
        //startPosition for panel 707, 65, size 779, 700
        //search 720, 76
        private void frmQuanLi_Load(object sender, EventArgs e)
        {
            //2 role của cấp quản lí:(Quản lý,  Nhân viên đặt vé)

            if (role == "Quản lý")//351, 235//351, 463
            {
                lblRole.Text = "Quản lý";
                lblTenNguoiDung.Text = tennguoidung;
            }    
            if (role == "Nhân viên đặt vé")
            {
                lblRole.Text = "Nhân viên";
                lblTenNguoiDung.Text = tennguoidung;
                btnQL_SanBay.Visible = false;
            }
            dateTimePickerNgayKhoiHanh.MinDate = DateTime.Now;
            pnlQL_Ve.Visible = true;
                
        }
        #region Xử lý giao diện
        private void btnQL_Ve_Click(object sender, EventArgs e)
        {
            if(pnlQL_Ve.Visible == false)
            {
                pnlQL_Ve.Visible = true;
                btnQL_Ve.BackColor = Color.WhiteSmoke;
                btnQL_Ve.ForeColor = Color.ForestGreen;

                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }  
            else
            {
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            pnlQL_SanBay.Visible = false;
            pnlQL_HD.Visible = false;
        }
        private void btnQL_SanBay_Click(object sender, EventArgs e)
        {
            if (pnlQL_SanBay.Visible == false)
            {
                pnlQL_SanBay.Visible = true;
                btnQL_SanBay.BackColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.ForestGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }

            pnlQL_Ve.Visible = false;
            pnlQL_HD.Visible = false;
        }
        private void btnQL_HoaDon_Click(object sender, EventArgs e)
        {
            if(pnlQL_HD.Visible == false)
            {
                pnlQL_HD.Visible = true;
                btnQL_HoaDon.BackColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.ForestGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;

            }
            else
            {
                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
            }
            pnlQL_Ve.Visible = false;
            pnlQL_SanBay.Visible = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQL = new frmQuanLi(tennguoidung, role);
            frmQL.FormClosed += (s, args) => this.Close();
            frmQL.Show();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Quản lý Chuyến bay

        private void cboDiemDen_DropDown(object sender, EventArgs e)
        {
            if (cboDiemKhoiHanh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn điểm khởi hành trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cboDiemKhoiHanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDiemKhoiHanh.SelectedIndex != -1)
            {
                Load_DiemDen(cboDiemKhoiHanh.Text);
            }
        }
        private void btnThem_QLVe_Click(object sender, EventArgs e)
        {
            if (cboDiemKhoiHanh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn 'Điểm khởi hành' cho chuyến bay!", "Thông báo");
            }
            else if (cboDiemDen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn 'Điểm đến' cho chuyến bay!", "Thông báo");
            }
            else if (dateTimePickerNgayKhoiHanh.Value < DateTime.Now.Date.AddDays(1))
            {
                MessageBox.Show("Vui lòng chọn 'Ngày khởi hành' cho chuyến bay!", "Thông báo");
            }
            else if (cboGio_Di.SelectedItem == null || cboPhut_Di.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn 'Thời gian khởi hành' của chuyến bay!", "Thông báo");
            }
            else if (cboGio_Den.SelectedItem == null || cboPhut_Den.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn 'Thời gian đến nơi' của chuyến bay!", "Thông báo");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thêm Chuyến bay " +
                    "\nTừ " + cboDiemKhoiHanh.Text + " - " + cboDiemDen.Text + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Add_ChangBay();
                    if(ThemChangBay)
                    {
                        Add_TuyenBay();
                    }    
                }    
            } 
                
        }
        string MaTB = "null_nha";
        string MaCB = "null_nha";
        string _GioBay;
        string _GioDen;
        private void btnSua_QLVe_Click(object sender, EventArgs e)
        {
            string caulenh;
            if(MaTB != "null_nha")
            {
                caulenh = "select count(*) from CHANGBAY ChB, SANBAY as SBDi, SANBAY as SBDen where ChB.IDSanBaydi = SBDi.ID and ChB.IDSanBayden = SBDen.ID and SBDi.MaSanBay = '" + cboDiemKhoiHanh.SelectedValue.ToString() + "' and SBDen.MaSanBay = '" + cboDiemDen.SelectedValue.ToString() + "'";
                var kq = (int)db.GetExecuteScalar(caulenh);
                if (kq == 1)
                {
                    DateTime NgayBay = dateTimePickerNgayKhoiHanh.Value;
                    string strNgayBay = NgayBay.ToString("yyyy-MM-dd");
                    
                    string tgianbay;
                    string tgianden;
                    if (cboGio_Di.SelectedItem != null && cboPhut_Di.SelectedItem != null) 
                    {
                        string __GioBay = cboGio_Di.SelectedItem.ToString(); 
                        string __PhutBay = cboPhut_Di.SelectedItem.ToString(); 
                        tgianbay = __GioBay + ":" + __PhutBay + ":00"; 
                    } 
                    else 
                    { 
                        tgianbay = _GioBay; 
                    }

                    if (cboGio_Den.SelectedItem != null && cboPhut_Den.SelectedItem != null) 
                    {
                        string __GioDen = cboGio_Den.SelectedItem.ToString(); 
                        string __PhutDen = cboPhut_Den.SelectedItem.ToString(); 
                        tgianden = __GioDen + ":" + __PhutDen + ":00"; 
                    } 
                    else 
                    { 
                        tgianden = _GioDen; 
                    }

                    caulenh = "select ChB.ID from CHANGBAY ChB, SANBAY as SBDi, SANBAY as SBDen where ChB.IDSanBaydi = SBDi.ID and ChB.IDSanBayden = SBDen.ID and SBDi.MaSanBay = '" + cboDiemKhoiHanh.SelectedValue.ToString() + "' and SBDen.MaSanBay = '" + cboDiemDen.SelectedValue.ToString() + "'";
                    int ID_ChB = (int)db.GetExecuteScalar(caulenh);
                    caulenh = "update TUYENBAY set NgayBay = '" + strNgayBay + "', GioBay = '" + tgianbay + "', GioDen = '" + tgianden + "', IDChangBay = " + ID_ChB.ToString() + " where MaTuyenBay = '" + MaTB + "'";
                    int kqSuaDoi = (int)db.GetExecuteNonQuery(caulenh);
                    if(kqSuaDoi > 0)
                    {
                        MessageBox.Show("Sửa thành công Chuyến bay có mã là: " + MaTB);
                        Load_Ve();
                    }    
                }
            }    
        }
        private void btnXoa_QLVe_Click(object sender, EventArgs e)
        {
            if(MaTB != "null_nha")
            {
                string caulenh = "delete from TUYENBAY where MaTuyenBay = '" + MaTB + "'";
                DialogResult result = MessageBox.Show("Bạn có chắn muốn xóa chuyến bay có mã là " + MaTB + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    try
                    {
                        var kq = db.GetExecuteNonQuery(caulenh);
                        Load_Ve();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại!" + ex.Message);
                    }
                }    
            }    
        }
        private void dataGrV_Ve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboDiemKhoiHanh.SelectedIndex = -1;
            cboDiemDen.SelectedIndex = -1;
            cboGio_Di.SelectedIndex = -1;
            cboPhut_Di.SelectedIndex = -1;
            cboGio_Den.SelectedIndex = -1;
            cboPhut_Den.SelectedIndex = -1;
            dateTimePickerNgayKhoiHanh.Value = DateTime.Now;
            if (e.RowIndex >= 0)
            {
                string caulenh;
                btnXoa_QLVe.Enabled = true;
                btnSua_QLVe.Enabled = true;
                DataGridViewRow row = dataGrV_Ve.Rows[e.RowIndex];
                MaTB = row.Cells["MaTuyenBay"].Value.ToString();
                MaCB = row.Cells["IDChangBay"].Value.ToString();
                DateTime NgayBay = DateTime.Parse(row.Cells["NgayBay"].Value.ToString());
                try
                {
                    dateTimePickerNgayKhoiHanh.Value = NgayBay;
                }
                catch 
                {
                    dateTimePickerNgayKhoiHanh.Value = DateTime.Now;
                }

                _GioBay = row.Cells["GioBay"].Value.ToString();
                _GioDen = row.Cells["GioDen"].Value.ToString();
                TimeSpan ThoiGianBay = TimeSpan.Parse(_GioBay);
                TimeSpan ThoiGianDen = TimeSpan.Parse(_GioDen);

                int GioBay_int = ThoiGianBay.Hours;
                int PhutBay_int = ThoiGianBay.Minutes;
                cboGio_Di.Text = GioBay_int.ToString();
                cboPhut_Di.Text = PhutBay_int.ToString();

                int GioDen_int = ThoiGianDen.Hours;
                int PhutDen_int = ThoiGianDen.Minutes;
                cboGio_Den.Text = GioDen_int.ToString();
                cboPhut_Den.Text = PhutDen_int.ToString();

                caulenh = "select DiaDiem from CHANGBAY ChB, TUYENBAY TnB, SANBAY SBdi where ChB.ID = TnB.IDChangBay and ChB.IDSanBaydi = SBdi.ID and IDChangBay = " + MaCB + ""; //Tìm sân bay đi
                cboDiemKhoiHanh.Text = (string)db.GetExecuteScalar(caulenh);

                caulenh = "select DiaDiem from CHANGBAY ChB, TUYENBAY TnB, SANBAY SBden where ChB.ID = TnB.IDChangBay and ChB.IDSanBayden = SBden.ID and IDChangBay = " + MaCB + ""; //Tìm sân bay đến
                cboDiemDen.Text = (string)db.GetExecuteScalar(caulenh);
            }

        }
        #endregion

        #region Quản lý Tài khoản
        private void btnThem_QLTK_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_QLTK_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_QLTK_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Quản lí Sân bay
        private void dataGrV_SanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGrV_SanBay.Rows[e.RowIndex];
                txtMaSanBay.Text = row.Cells["MaSanBay"].Value.ToString();
                txtTenSanBay.Text = row.Cells["TenSB"].Value.ToString();
                string diaDiem = row.Cells["DiaDiem"].Value.ToString();
                int index = cboViTri.FindStringExact(diaDiem);
                if (index != -1)
                    cboViTri.SelectedIndex = index;
                else
                    cboViTri.SelectedIndex = -1;
                cboViTri.Refresh();
                btnXoa_QLSB.Enabled = true;
                return;
            }
        }
        private void txtTaoMaSB_Click(object sender, EventArgs e)
        {
            string caulenh = "SELECT MAX(CAST(SUBSTRING(MaSanBay, 3, 3) AS INT)) " +
                "FROM SANBAY " +
                "WHERE MaSanBay LIKE 'SB%'";    //Kiẻm tra mã sân bay 
            int KTRAmaSB;
            var result = db.GetExecuteScalar(caulenh);
            if (result != DBNull.Value)
            {
                KTRAmaSB = Convert.ToInt32(result) + 1;
            }
            else
            {
                KTRAmaSB = 1;
            }
            string maSB = $"SB{KTRAmaSB:D3}";
            txtMaSanBay.Text = maSB;
        }
        private void btnThem_QLSB_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTenSanBay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sân bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if(string.IsNullOrEmpty(txtMaSanBay.Text))
            {
                MessageBox.Show("Vui lòng tạo mã sân bay trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if(cboViTri.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vị trí của sân bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm \nSân bay: '" + txtTenSanBay.Text + "'\nỞ '" + cboViTri.SelectedItem.ToString() +"'", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string caulenh = "insert into SANBAY(MaSanBay, TenSB, DiaDiem) values (" +
                        "'" + txtMaSanBay.Text +
                        "', N'" + txtTenSanBay.Text +
                        "', N'" + cboViTri.SelectedItem.ToString() + "')";
                    try
                    {
                        int kq = db.GetExecuteNonQuery(caulenh);
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm thành công!");
                            Load_SanBay();
                            txtMaSanBay.Clear();
                            txtTenSanBay.Clear();
                            txtTenSanBay.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thất bại! \nLỗi:" + ex.Message);
                        return;
                    }
                }
                else return;
            }
        }
        private void btnSua_QLSB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSanBay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sân bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (string.IsNullOrEmpty(txtMaSanBay.Text))
            {
                MessageBox.Show("Vui lòng tạo mã sân bay trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (cboViTri.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vị trí của sân bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                if (dataGrV_SanBay.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn sửa lại thông tin của sân bay có mã '" + txtMaSanBay.Text + "'!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string caulenh = "update SANBAY " +
                            "set DiaDiem = N'" + cboViTri.SelectedItem.ToString() + "', " +
                            "TenSB = N'" + txtTenSanBay.Text + "' " +
                            "where MaSanBay = '" + txtMaSanBay.Text + "'";
                        try
                        {
                            var kq = db.GetExecuteNonQuery(caulenh);
                            if (kq > 0)
                            {
                                MessageBox.Show("Sửa thành công!");
                                Load_SanBay();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sửa thất bại!" + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 hàng dữ liệu trong bảng để sửa thông tin!");
                }    
            }    
        }
        private void btnXoa_QLSB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn XÓA sân bay có mã '" + txtMaSanBay.Text + "'", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dataGrV_SanBay.SelectedRows.Count > 0)
                {
                    string caulenh = "delete from SANBAY where MaSanBay = '" + txtMaSanBay.Text + "'";
                    try
                    {
                        var kq = db.GetExecuteNonQuery(caulenh);
                        if (kq > 0)
                        {
                            MessageBox.Show("Xóa thành công sân bay có mã là '" + txtMaSanBay.Text + "'");
                            Load_SanBay();
                            txtMaSanBay.Clear();
                            txtTenSanBay.Clear();
                            cboViTri.Text = "";
                            txtTenSanBay.Focus();
                            btnXoa_QLSB.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại! \nLỗi: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 hàng dữ liệu trong bảng để xóa thông tin!");
                }
            }
            else return;
        }
        #endregion

        #region Quản lý Hóa đơn
        private void btnXuatExcel_QLHD_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFiledialog = new SaveFileDialog();
            saveFiledialog.Title = "Xuất file Excel";
            saveFiledialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if(saveFiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatExcel(saveFiledialog.FileName);
                    MessageBox.Show("Xuất file thành công!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xuất file thất bại!\nLỗi:" + ex.Message);
                }
            }
        }
        //public void XuatExcel(string path)
        //{
        //    Excel.Application ExcApp = new Excel.Application();
        //    ExcApp.Application.Workbooks.Add(Type.Missing);
        //    for(int i =0; i < dataGrV_HoaDon.Columns.Count; i++)
        //    {
        //        ExcApp.Cells[1, i + 1] = dataGrV_HoaDon.Columns[i].HeaderText;
        //    }
        //    for(int i = 0; i < dataGrV_HoaDon.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dataGrV_HoaDon.Columns.Count; j++)
        //        {
        //            ExcApp.Cells[i + 2, j + 1] = dataGrV_HoaDon.Rows[i].Cells[j].Value;
        //        }
        //    }
        //    ExcApp.Columns.AutoFit();
        //    ExcApp.ActiveWorkbook.SaveCopyAs(path);
        //    ExcApp.ActiveWorkbook.Saved = true;
        //}
        public void XuatExcel(string path)
        {
            Excel.Application ExcApp = new Excel.Application();
            Excel.Workbook workbook = ExcApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 0; i < dataGrV_HoaDon.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataGrV_HoaDon.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGrV_HoaDon.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrV_HoaDon.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGrV_HoaDon.Rows[i].Cells[j].Value;
                }
            }
            worksheet.Columns.AutoFit();
            workbook.SaveCopyAs(path);
            workbook.Saved = true;
            workbook.Close();
            ExcApp.Quit();
        }

    private void dataGrV_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGrV_HoaDon.Rows[e.RowIndex];
            string id = selectedRow.Cells["ID"].Value.ToString();
            Load_CTHoaDon(id);
        }
        
        #endregion

        #region Phương thức chức năng
        private void Load_Ve()
        {
            dt_Ve = db.GetDataTable("select MaTuyenBay, NgayBay, GioBay, GioDen, SoVeConLai, SoVeDaBan, TrangThaiTuyenBay, LoaiMB AS IDMayBay, CONCAT(SBDi.DiaDiem, ' - ', SBDen.DiaDiem) AS IDChangBay from TUYENBAY TB, MAYBAY MB, CHANGBAY CB, SANBAY SBDi, SANBAY SBDen where TB.IDMayBay = MB.ID and TB.IDChangBay = CB.ID and CB.IDSanBaydi = SBDi.ID and CB.IDSanBayden = SBDen.ID");
            dataGrV_Ve.DataSource = dt_Ve;
        }
        private void Load_SanBay()
        {
            dt_SanBay = db.GetDataTable("select MaSanBay, TenSB, DiaDiem from SANBAY");
            dataGrV_SanBay.DataSource = dt_SanBay;
        }
        private void Load_HoaDon()
        {
            dt_HoaDon = db.GetDataAdapter("HOADON");
            dataGrV_HoaDon.DataSource = dt_HoaDon;
        }
        private void Load_CTHoaDon(string id)
        {
            string caulenh = "select VE, PhuPhiHeThong, PhuPhiAnNinh, Ghe, HanhLy, KM_ThanhVienLauNam, KM_MaKhuyenMai, Thue, TenNhanVienTruc from CHITIETHOADON where ID = " + id + "";
            dt_CTHoaDon = db.GetDataTable(caulenh);
            dataGrV_CTHoaDon.DataSource = dt_CTHoaDon;
        }
        private void Load_DiemKH()
        {
            string caulenh = "select MaSanBay, DiaDiem from SANBAY";
            dt_DiemKH = db.GetDataTable(caulenh);
            cboDiemKhoiHanh.DataSource = dt_DiemKH;
            cboDiemKhoiHanh.DisplayMember = "DiaDiem";
            cboDiemKhoiHanh.ValueMember = "MaSanBay";
            cboDiemKhoiHanh.SelectedIndex = -1;
        }
        private void Load_DiemDen(string DiaDiemDaChon)
        {
            string caulenh = "select MaSanBay, DiaDiem from SANBAY where DiaDiem != N'" + DiaDiemDaChon + "'";
            dt_DiemDen = db.GetDataTable(caulenh);
            cboDiemDen.DataSource = dt_DiemDen;
            cboDiemDen.DisplayMember = "DiaDiem";
            cboDiemDen.ValueMember = "MaSanBay";
            cboDiemDen.SelectedIndex = -1;
        }
        private void Add_ChangBay()
        {
            string caulenh = "select ID from SANBAY where MaSanBay = '" + cboDiemKhoiHanh.SelectedValue.ToString() + "'";
            int idDiemKH = (int)db.GetExecuteScalar(caulenh);
            caulenh = "select ID from SANBAY where MaSanBay = '" + cboDiemDen.SelectedValue.ToString() + "'";
            int idDiemDen = (int)db.GetExecuteScalar(caulenh);
            caulenh = "insert into CHANGBAY(IDSanBaydi, IDSanBayden)  " +
                "values(" + idDiemKH + "," + idDiemDen + ")";
            try
            {
                var kq = db.GetExecuteNonQuery(caulenh);
                if(kq > 0) ThemChangBay = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được chặng bay!\nLỗi: " + ex.Message);
            }
        }
        private void Add_TuyenBay()
        {
            DateTime NgayBay = dateTimePickerNgayKhoiHanh.Value;
            string strNgayBay = NgayBay.ToString("yyyy-MM-dd");


            string __GioBay = cboGio_Di.SelectedItem.ToString();
            string __PhutBay = cboPhut_Di.SelectedItem.ToString();
            string tgianbay = __GioBay + ":" + __PhutBay + ":00"; 

            string __GioDen = cboGio_Den.SelectedItem.ToString();
            string __PhutDen = cboPhut_Den.SelectedItem.ToString();
            string tgianden = __GioDen + ":" + __PhutDen + ":00";

            Random rd = new Random();
            int randomMayBay = rd.Next(1, 6);
            string caulenh = "select MAX(ID) from CHANGBAY";
            int idChangbay = (int)db.GetExecuteScalar(caulenh);

            caulenh = "insert into TUYENBAY(NgayBay, GioBay, GioDen, SoVeConLai, SoVeDaBan, IDMayBay, IDChangBay) " +
                "values ('" + strNgayBay + "', '" + tgianbay + "', '" + tgianden + "', 100, 0, " + randomMayBay + ", " + idChangbay + ")";
            try
            {
                var kq = db.GetExecuteNonQuery(caulenh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được tuyến bay!\nLỗi: " + ex.Message);
            }

        }
        #endregion

    }
}
