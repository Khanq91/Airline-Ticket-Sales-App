using DB;
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
            cboQuocGia_NL.SelectedItem = "Vietnam";
            cboQuocGia_NL.MaxDropDownItems = 5;
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
            Control ctr = (Control)sender;
            if (cboQuocGia_NL.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy nhập quốc gia của hành khách!");
            else
                this.erpNhapTT.Clear();
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
      
        public TTNguoiLon GetKhachHang()
        {
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
            tt.QuocGia=cboQuocGia_NL.Text;
            tt.SDT = txtSDT_NL.Text;
            tt.DiaChi = txtNoiO_NL.Text;
            tt.MaHoiVien=txtMaHoiVien_NL.Text;
            return tt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TTKhachHang khachHang = GetKhachHang();
            MessageBox.Show(khachHang.TenKH); // Display customer information
        }
    }
}


     
