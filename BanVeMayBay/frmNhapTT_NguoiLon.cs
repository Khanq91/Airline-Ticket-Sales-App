using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private void mtxtNgaySinh_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (mtxtNgaySinh.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy nhập ngày sinh của hành khách!");
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
            if (txtSDT_NL.Text.Length <=9 && txtSDT_NL.Text.Length >=11 || string.IsNullOrWhiteSpace(txtSDT_NL.Text))
            {
                lbl_SDT.Visible = true;
                return false;
            }
            if (!IsValidEmail(txtEmail_NL.Text))
            {
                lbl_Email.Visible = true;
                return false;
            }
            if (txtCCCD.Text.Length != 12)
            {
                lbl_CCCD.Visible = true;
                return false;
            }
            else if (!ktraTuoi())
            {
                lblNgaySinh.Visible = true;
                return false;
            }
            lbl_SDT.Visible = false;
            lbl_Email.Visible = false;
            lbl_CCCD.Visible = false;
            lblNgaySinh.Visible = false;
            return true;
        }
        bool ktraTuoi()
        {
            string dateString = mtxtNgaySinh.Text;
            DateTime dateValue;
            DateTime ngaysinh;
            int nam = 0;
            int thang = 0;

            if (DateTime.TryParse(dateString, out dateValue))
            {
                ngaysinh = dateValue;
                nam = ngaysinh.Year;
                thang = ngaysinh.Month;

                int age = DateTime.Now.Year - nam;
                if (ngaysinh > DateTime.Now.AddYears(-age)) age--;

                if (age > 12)
                {
                    return true;
                }
            }
            return false;
        }
        public TTNguoiLon GetKhachHang()
        {
            if (!IsValid())
            {
                return null;
            }
            lbl_SDT.Text = "";
            lblEmail.Text = "";
            lbl_CCCD.Text = "";
            lblNgaySinh.Text = "";
            TTNguoiLon tt =new TTNguoiLon();
            if (rdoGioiTinhNam_NL.Checked)
            {
                tt.Gioitinh = "Nam";
            }
            else if (rdoGioiTinhNu_NL.Checked)
            {
                tt.Gioitinh = "Nữ";
            }
            tt.TenKH = txtHo_NL.Text + " " + txtTenDemvaTen_NL.Text;

            string dateString = mtxtNgaySinh.Text;
            DateTime dateValue;
            try
            {
                if (DateTime.TryParse(dateString, out dateValue))
                {
                    tt.NgaySinh = dateValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển đổi ngày sinh" + ex.Message);
            }
            //if ((tt.NgaySinh.Year - DateTime.Now.Year) <= 12)
            //{

            //}    
            //tt.NgaySinh = mtxtNgaySinh.Text.ToString("yyyy-MM-dd");
            tt.Email = txtEmail_NL.Text;
            tt.SDT = txtSDT_NL.Text;
            tt.DiaChi = txtNoiO_NL.Text;
            tt.CCCD=txtCCCD.Text;
            return tt;
        }

        private void txtSDT_NL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự này được nhập
            }
        }

        private void lblThongTin_NL_Click(object sender, EventArgs e)
        {

        }
    }
}


     
