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
using System.CodeDom;
using Microsoft.Office.Interop.Excel;
using System.Security.Policy;
using System.Data.SqlTypes;

namespace BanVeMayBay
{
    public partial class frmQuanLi : Form
    {
        string tennguoidung;
        string role;
        string caulenh;
        bool ThemChangBay = false;
        DB_Connet db = new DB_Connet();
        System.Data.DataTable dt_SanBay = new System.Data.DataTable();
        System.Data.DataTable dt_DiemKH = new System.Data.DataTable();
        System.Data.DataTable dt_DiemDen = new System.Data.DataTable();
        System.Data.DataTable dt_Ve = new System.Data.DataTable();
        System.Data.DataTable dt_HoaDon = new System.Data.DataTable();
        System.Data.DataTable dt_CTHoaDon = new System.Data.DataTable();
        System.Data.DataTable dt_TaiKhoan = new System.Data.DataTable();

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
            Load_TaiKhoan();
            cboLoaiTK.SelectedIndex = 1;
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
            
            dateTimePickerNgayKhoiHanh.MinDate = DateTime.Now;
            pnlQL_Ve.Visible = true;
                
        }
        #region Xử lý giao diện
        private void btnQL_Ve_Click(object sender, EventArgs e)
        {
            if(pnlQL_Ve.Visible == false)
            {
                pnlQL_Ve.Visible = true;
                UICLICKtoOFF();
                btnQL_Ve.BackColor = Color.WhiteSmoke;
                btnQL_Ve.ForeColor = Color.ForestGreen;

                //btnQL_SanBay.BackColor = Color.ForestGreen;
                //btnQL_HoaDon.BackColor = Color.ForestGreen;
                //btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                //btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }  
            else
            {
                UICLICKtoOFF();
                //btnQL_SanBay.BackColor = Color.ForestGreen;
                //btnQL_HoaDon.BackColor = Color.ForestGreen;
                //btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                //btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            pnlQL_SanBay.Visible = false;
            pnlQL_HD.Visible = false;
            pnlQL_TaiKhoan.Visible = false;
        }
        private void btnQL_SanBay_Click(object sender, EventArgs e)
        {
            if (pnlQL_SanBay.Visible == false)
            {
                pnlQL_SanBay.Visible = true;
                UICLICKtoOFF();
                btnQL_SanBay.BackColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.ForestGreen;

                //btnQL_Ve.BackColor = Color.ForestGreen;
                //btnQL_Ve.ForeColor = Color.WhiteSmoke;
                //btnQL_HoaDon.BackColor = Color.ForestGreen;
                //btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                //btnQL_Ve.BackColor = Color.ForestGreen;
                //btnQL_HoaDon.BackColor = Color.ForestGreen;
                //btnQL_Ve.ForeColor = Color.WhiteSmoke;
                //btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }

            pnlQL_Ve.Visible = false;
            pnlQL_HD.Visible = false;
            pnlQL_TaiKhoan.Visible = false;
        }
        private void btnQL_HoaDon_Click(object sender, EventArgs e)
        {
            if(pnlQL_HD.Visible == false)
            {
                pnlQL_HD.Visible = true;
                UICLICKtoOFF();
                btnQL_HoaDon.BackColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.ForestGreen;

                //btnQL_Ve.BackColor = Color.ForestGreen;
                //btnQL_Ve.ForeColor = Color.WhiteSmoke;
                //btnQL_SanBay.BackColor = Color.ForestGreen;
                //btnQL_SanBay.ForeColor = Color.WhiteSmoke;

            }
            else
            {
                UICLICKtoOFF();
                //btnQL_Ve.BackColor = Color.ForestGreen;
                //btnQL_SanBay.BackColor = Color.ForestGreen;
                //btnQL_Ve.ForeColor = Color.WhiteSmoke;
                //btnQL_SanBay.ForeColor = Color.WhiteSmoke;
            }
            pnlQL_Ve.Visible = false;
            pnlQL_SanBay.Visible = false;
            pnlQL_TaiKhoan.Visible = false;
        }
        private void btnQL_TaiKhoan_Click(object sender, EventArgs e)
        {
            if (pnlQL_TaiKhoan.Visible == false)
            {
                pnlQL_TaiKhoan.Visible = true;
                UICLICKtoOFF();
                btnQL_TaiKhoan.BackColor = Color.WhiteSmoke;
                btnQL_TaiKhoan.ForeColor = Color.ForestGreen;
            }    
            else UICLICKtoOFF();
            pnlQL_Ve.Visible = false;
            pnlQL_HD.Visible = false;
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
            System.Windows.Forms.Application.Exit();
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
                        Load_Ve();
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
            if (e.RowIndex >= 0 && e.RowIndex < dataGrV_Ve.Rows.Count - 1)
            {
                string caulenh;
                btnXoa_QLVe.Enabled = true;
                btnSua_QLVe.Enabled = true;
                DataGridViewRow row = dataGrV_Ve.Rows[e.RowIndex];
                MaTB = row.Cells["MaTuyenBay"].Value.ToString();
                MaCB = row.Cells["IDChangBay"].Value.ToString();
                string[] splitStrings = MaCB.Split(new string[] { " - " }, StringSplitOptions.None); 
                string diemKH = splitStrings[0]; 
                string diemDen = splitStrings[1];

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

                //caulenh = "select DiaDiem from CHANGBAY ChB, TUYENBAY TnB, SANBAY SBdi where ChB.ID = TnB.IDChangBay and ChB.IDSanBaydi = SBdi.ID and IDChangBay = " + MaCB + ""; //Tìm sân bay đi
                //cboDiemKhoiHanh.Text = (string)db.GetExecuteScalar(caulenh);
                //caulenh = "select DiaDiem from CHANGBAY ChB, TUYENBAY TnB, SANBAY SBden where ChB.ID = TnB.IDChangBay and ChB.IDSanBayden = SBden.ID and IDChangBay = " + MaCB + ""; //Tìm sân bay đến
                //cboDiemDen.Text = (string)db.GetExecuteScalar(caulenh);

                cboDiemKhoiHanh.Text = diemKH;
                cboDiemDen.Text = diemDen;

            }

        }
        #endregion

        #region Quản lý Tài khoản
        private void btnThemQL_TK_Click(object sender, EventArgs e)
        {
            string tentk;
            string tendn;
            string matkhau;
            string loaiTK;
            string sqlCheckTK = "SELECT COUNT(*) FROM QLTaiKhoan WHERE TenDangNhap = '" + txtTenDN.Text + "'";
            int countTaiKhoan = (int)db.GetExecuteScalar(sqlCheckTK);
            if (countTaiKhoan > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng tạo mã tài khoản trước khi thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                tentk = txtTenTK.Text;
            }

            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                tendn = txtTenDN.Text;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                matkhau = txtMatKhau.Text;
            }

            if (cboLoaiTK.SelectedIndex != -1)
            {
                loaiTK = cboLoaiTK.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản cho tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn thêm tài khoản có mã là '" + txtMaTK.Text + "'", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string caulenh = "INSERT INTO QLTaiKhoan (TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES (N'" + tentk + "', '" + tendn + "', '" + matkhau + "', N'" + loaiTK + "')";
                try
                {
                    var kq = db.GetExecuteNonQuery(caulenh);
                    if (kq != 0)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!");
                        Load_TaiKhoan();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm tài khoản!\nLỗi: " + ex.Message);
                    return;
                }
            }
            else return;            
        }

        private void btnSuaQL_TK_Click(object sender, EventArgs e)
        {
            string caulenh;
            if (dataGrV_TaiKhoan.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin của tài khoản '" + txtMaTK.Text + "' !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    caulenh = "SELECT COUNT(MaTaiKhoan) FROM QLTaiKhoan WHERE MaTaiKhoan = '" + txtMaTK.Text + "'";
                    int ktra = (int)db.GetExecuteScalar(caulenh);
                    if (ktra <= 0)
                    {
                        MessageBox.Show("Vui lòng chọn lại dữ liệu muốn sửa!");
                        return;
                    }
                    caulenh = "UPDATE QLTaiKhoan " +
                                "SET TenTaiKhoan = '" + txtTenTK.Text + "', " +
                                "TenDangNhap = '" + txtTenDN.Text + "', " +
                                "MatKhau = '" + txtMatKhau.Text + "', " +
                                "LoaiTaiKhoan = '" + cboLoaiTK.SelectedItem.ToString() + "' " +
                                "WHERE MaTaiKhoan = '" + txtMaTK.Text + "'";
                    try
                    {
                        db.GetExecuteNonQuery(caulenh);
                        Load_TaiKhoan();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể cập nhật thông tin của tài khoản '" + txtMaTK.Text + "'\nLỗi: " + ex.Message);
                        return;
                    }
                }
                else return;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu trong bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnXoaQL_TK_Click(object sender, EventArgs e)
        {
            if(dataGrV_TaiKhoan.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản có mã là '" + txtMaTK.Text + "' không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    string caulenh = "DELETE QLTaiKhoan WHERE MaTaiKhoan = '" + txtMaTK.Text + "'";
                    db.GetExecuteNonQuery(caulenh);
                    Load_TaiKhoan(); clearTaiKhoan();
                    return;
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu trong bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAutoMaTK_Click(object sender, EventArgs e)
        {
            string nam = DateTime.Now.Year.ToString();
            string thang = DateTime.Now.Month.ToString();
            string ktraMa = "TK" + nam + thang;
            string caulenh = "SELECT MAX(CAST(SUBSTRING(MaTaiKhoan, 9, 3) AS INT)) " +
                "FROM QLTaiKhoan " +
                "WHERE MaTaiKhoan LIKE 'TK202412%'";
            int KTRAmaTK;
            var result = db.GetExecuteScalar(caulenh);
            if (result != DBNull.Value)
            {
                KTRAmaTK = Convert.ToInt32(result) + 1;
            }
            else
            {
                KTRAmaTK = 1;
            }
            string maTK = ktraMa + $"{KTRAmaTK:D3}";
            txtMaTK.Text = maTK;
        }
        private void dataGrV_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < dataGrV_TaiKhoan.Rows.Count - 1)
            {
                DataGridViewRow row = dataGrV_TaiKhoan.Rows[e.RowIndex];
                txtMaTK.Text = row.Cells["MaTaiKhoan"].Value.ToString();
                txtTenTK.Text = row.Cells["TenTaiKhoan"].Value.ToString();
                txtTenDN.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                string loaitk = row.Cells["LoaiTaiKhoan"].Value.ToString();
                int index = cboLoaiTK.FindStringExact(loaitk);
                if (index != -1)
                    cboLoaiTK.SelectedIndex = index;
                else cboLoaiTK.SelectedIndex = -1;
                cboLoaiTK.Refresh();
                btnXoaQL_TK.Enabled = true;
                btnSuaQL_TK.Enabled = true;
                return;
            }    
        }
        private void btnShow_QLTK_Click(object sender, EventArgs e)
        {
            if (!txtMatKhau.UseSystemPasswordChar)
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
            else txtMatKhau.UseSystemPasswordChar = false;
        }
        #endregion

        #region Quản lí Sân bay
        private void dataGrV_SanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGrV_SanBay.Rows.Count - 1)
            {
                DataGridViewRow row = dataGrV_SanBay.Rows[e.RowIndex];
                txtMaSanBay.Text = row.Cells["MaSanBay"].Value.ToString();
                txtTenSanBay.Text = row.Cells["TenSanBay"].Value.ToString();
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
                MessageBox.Show("Vui lòng tạo hoặc nhập mã sân bay trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                    string caulenh;
                    caulenh = "select count(*) from SANBAY where MaSanBay = '" + txtMaSanBay.Text + "'";
                    int ktTrungMaSB = (int)db.GetExecuteScalar(caulenh);
                    if(ktTrungMaSB > 0)
                    {
                        MessageBox.Show("Đã tồn tại mã sân bay!\nVui lòng tạo lại mã.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaSanBay.Clear();
                        txtTenSanBay.Clear();
                        txtTenSanBay.Focus();
                        cboViTri.Text = "";
                        return;
                    }
                    else
                    {
                        caulenh = "insert into SANBAY(MaSanBay, TenSanBay, DiaDiem) values (" +
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
                                cboViTri.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm thất bại! \nLỗi:" + ex.Message);
                            return;
                        }
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
                            "TenSanBay = N'" + txtTenSanBay.Text + "' " +
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
            ExportFile(dt_HoaDon, "DanhSach", "Danh sách Hóa đơn");
            //SaveFileDialog saveFiledialog = new SaveFileDialog();
            //saveFiledialog.Title = "Xuất file Excel";
            //saveFiledialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            //if (saveFiledialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        XuatExcel(saveFiledialog.FileName);
            //        MessageBox.Show("Xuất file thành công!");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Xuất file thất bại!\nLỗi:" + ex.Message);
            //    }
            //}
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

        public void ExportFile(System.Data.DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;
            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã Hóa đơn";
            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Ngày lập";
            cl2.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Tổng tiền";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Hình thức thanh toán";
            cl4.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Trạng thái";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable
            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range dateColumn = oSheet.get_Range("B4", "B" + rowEnd);
            dateColumn.NumberFormat = "dd/MM/yyyy";
        }
        private void cboLocDuLieu_QLHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter_DSHD();
        }
        private void dataGrV_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < dataGrV_HoaDon.Rows.Count -1)
            {
                DataGridViewRow selectedRow = dataGrV_HoaDon.Rows[e.RowIndex];
                string maHD = selectedRow.Cells["MaHoaDon"].Value.ToString();
                Load_CTHoaDon(maHD);
            }    
        }
        #endregion

        #region Phương thức chức năng
        void UICLICKtoOFF()
        {
            btnQL_TaiKhoan.BackColor = Color.ForestGreen;
            btnQL_TaiKhoan.ForeColor = Color.WhiteSmoke;
            btnQL_Ve.BackColor = Color.ForestGreen;
            btnQL_Ve.ForeColor = Color.WhiteSmoke;
            btnQL_SanBay.BackColor = Color.ForestGreen;
            btnQL_HoaDon.BackColor = Color.ForestGreen;
            btnQL_SanBay.ForeColor = Color.WhiteSmoke;
            btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
        }
        void clearTaiKhoan()
        {
            txtMaTK.Clear();
            txtTenTK.Clear();
            txtTenDN.Clear();
            txtMatKhau.Clear();
            cboLoaiTK.SelectedIndex = 0;
            txtTenTK.Focus();
        }
        private void Filter_DSHD()
        {
            //(none)
            //Theo ngày gần nhất
            //Giảm dần theo tổng tiền
            //Tăng dần theo tổng tiền

            DataView dataView = new DataView(dt_HoaDon);
            if(cboLocDuLieu_QLHD.SelectedItem.ToString() == "(none)")
            {
                Load_HoaDon();
            }    
            else if(cboLocDuLieu_QLHD.SelectedItem.ToString() == "Theo ngày gần nhất")
            {
                dataView.Sort = "NgayLapHoaDon DESC";
                dataGrV_HoaDon.DataSource = dataView.ToTable();
            }
            else if(cboLocDuLieu_QLHD.SelectedItem.ToString() == "Tăng dần theo tổng tiền")
            {
                dataView.Sort = "TongTien ASC";
                dataGrV_HoaDon.DataSource = dataView.ToTable();
            }
            else if (cboLocDuLieu_QLHD.SelectedItem.ToString() == "Giảm dần theo tổng tiền")
            {
                dataView.Sort = "TongTien DESC";
                dataGrV_HoaDon.DataSource = dataView.ToTable();
            }
        }
        private void Load_Ve()
        {
            dt_Ve = db.GetDataTable("select MaTuyenBay, NgayBay, GioBay, GioDen, SoVeConLai, SoVeDaBan, TrangThaiTuyenBay, LoaiMayBay AS IDMayBay, CONCAT(SBDi.DiaDiem, ' - ', SBDen.DiaDiem) AS IDChangBay from TUYENBAY TB, MAYBAY MB, CHANGBAY CB, SANBAY SBDi, SANBAY SBDen where TB.IDMayBay = MB.ID and TB.IDChangBay = CB.ID and CB.IDSanBaydi = SBDi.ID and CB.IDSanBayden = SBDen.ID");
            dataGrV_Ve.DataSource = dt_Ve;
        }
        private void Load_SanBay()
        {
            dt_SanBay = db.GetDataTable("select MaSanBay, TenSanBay, DiaDiem from SANBAY");
            dataGrV_SanBay.DataSource = dt_SanBay;
        }
        private void Load_HoaDon()
        {
            dt_HoaDon = db.GetDataTable("select MaHoaDon, NgayLapHoaDon, TongTien, HinhThucThanhToan, TrangThaiHoaDon from HOADON");
            dataGrV_HoaDon.DataSource = dt_HoaDon;
        }
        private void Load_CTHoaDon(string maHD)
        {
            string caulenh = "select VE, PhuPhiHeThong, PhuPhiAnNinh, Ghe, HanhLy, KM_ThanhVienLauNam, KM_MaKhuyenMai, Thue, TenNhanVienTruc from CHITIETHOADON where MaHoaDon = '"+ maHD + "'";
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
        private void Load_TaiKhoan()
        {
            string caulenh = "SELECT MaTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan FROM QLTaiKhoan WHERE LoaiTaiKhoan != N'Quản lý'";
            dt_TaiKhoan = db.GetDataTable(caulenh);
            dataGrV_TaiKhoan.DataSource = dt_TaiKhoan;
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
