using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmNhapTT_NguoiLon : Form
    {
        public TTNguoiLon KhachHangData { get; private set; }
        public frmNhapTT_NguoiLon()
        {
            InitializeComponent();
            KhachHangData = new TTNguoiLon();
        }
        private void frmNhapTT_Load(object sender, EventArgs e)
        {
            txtHo_NL.Focus();
            dateTimePickerNgaySinh_NL.MaxDate = DateTime.Now;
        }

        private void txtHo_NL_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtHo_NL.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy nhập họ của hành khách!");
            else
                this.erpNhapTT.Clear();
        }

        private void txtTenDemvaTen_NL_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtTenDemvaTen_NL.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy nhập tên và tên đệm của hành khách!");
            else
                this.erpNhapTT.Clear();
        }

        private void cboQuocGia_NL_Leave(object sender, EventArgs e)
        {
        }

        private void txtSDT_NL_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtSDT_NL.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy nhập SĐT của hành khách!");
            else
                this.erpNhapTT.Clear();
        }

        private void txtEmail_NL_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtHo_NL.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy nhập Email của hành khách!");
            else
                this.erpNhapTT.Clear();
        }
        private void dateTimePickerNgaySinh_NL_Validating(object sender, CancelEventArgs e)
        {
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtHo_NL.Text) // Kiểm tra rỗng hoặc chỉ có khoảng trắng
                || string.IsNullOrWhiteSpace(txtTenDemvaTen_NL.Text)
                || string.IsNullOrWhiteSpace(txtCCCD.Text)
                || string.IsNullOrWhiteSpace(txtEmail_NL.Text)
               )
            {
                return false; // Một trong các trường thông tin trống
            }
            if (txtSDT_NL.Text.Length <= 9 || string.IsNullOrWhiteSpace(txtSDT_NL.Text))
            {
                lbl_SDT.Text = "Số điện thoại không hợp lệ";
                return false;
            }
            if (!IsValidEmail(txtEmail_NL.Text))
            {
                lblEmail.Text = "Email không hợp lệ";
                return false;
            }
            //if (!IsAgeValid())
            //{
            //    lbl_NgaySinh.Text = "Ngày sinh không hợp lệ";
            //    return false;
            //}
            // Nếu tất cả các trường đều hợp lệ
            return true;
        }
        public TTNguoiLon GetKhachHang()
        {
            if (!IsValid())
            {
                return null;
            }
            TTNguoiLon tt =new TTNguoiLon();
            if (rdoGioiTinhNam_NL.Checked)
            {
                tt.Gioitinh = rdoGioiTinhKhac_NL.Text;
            }
            else if (rdoGioiTinhNu_NL.Checked)
            {
                tt.Gioitinh = rdoGioiTinhNu_NL.Text;
            }
            else
            {
                tt.Gioitinh = rdoGioiTinhKhac_NL.Text;
            }
            tt.TenKH=txtHo_NL.Text +txtTenDemvaTen_NL.Text;
            tt.NgaySinh = dateTimePickerNgaySinh_NL.Value;
            tt.SDT = txtSDT_NL.Text;
            tt.DiaChi = txtNoiO_NL.Text;
            tt.CCCD=txtCCCD.Text;
            return tt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TTKhachHang khachHang = GetKhachHang();
            MessageBox.Show(khachHang.TenKH); // Display customer information
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSDT_NL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự này được nhập
            }
        }
    }
}


     
