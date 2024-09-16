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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            txtTaiKhoan_DK.Clear();
            txtMatKhau_DK.Clear();
            txtNhapLaiMatKhau_DK.Clear();
        }

        private void picTroLaiDN_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap fdn = new frmDangNhap();
            fdn.Show();
        }

        private void picTroLaiDN_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void txtTaiKhoan_DK_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtTaiKhoan_DK.Text.Trim().Length == 0)
                this.erpTKMK.SetError(ctr, "Bạn phải nhập tài khoản!");
            else
                this.erpTKMK.Clear();
        }

        private void txtMatKhau_DK_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtMatKhau_DK.Text.Trim().Length == 0)
                this.erpTKMK.SetError(ctr, "Bạn phải nhập mật khẩu!");
            else
                this.erpTKMK.Clear();
        }

        private void txtNhapLaiMatKhau_DK_Leave(object sender, EventArgs e)
        {

            Control ctr = (Control)sender;
            if (txtNhapLaiMatKhau_DK.Text.Trim().Length == 0)
                this.erpTKMK.SetError(ctr, "Bạn phải nhập lại mật khẩu!");
            else
                this.erpTKMK.Clear();
        }
    }
}
