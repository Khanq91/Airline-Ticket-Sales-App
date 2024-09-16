using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //Đổi màu theo mã màu Hex
            //lblDangNhap.ForeColor = ColorTranslator.FromHtml("#80ED99");
            txtTaiKhoan_DN.Clear();
            txtMatKhau_DN.Clear();
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtTaiKhoan_DN.Text.Trim().Length == 0)
                this.erpTKMK.SetError(ctr, "Bạn phải nhập tài khoản!");
            else
                this.erpTKMK.Clear();
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtTaiKhoan_DN.Text.Trim().Length == 0)
                this.erpTKMK.SetError(ctr, "Bạn phải nhập mật khẩu!");
            else
                this.erpTKMK.Clear();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangKy fdk = new frmDangKy();
            fdk.Show();
        }
    }
}
