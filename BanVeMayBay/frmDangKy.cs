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
    public partial class frmDangKy : Form
    {
        DangKi db_Dk = new DangKi();
        public frmDangKy()
        {
            InitializeComponent(); 
            
            var a = this.PointToScreen(btnDangKi.Location);
            a = picDangKi.PointToClient(a);

            LamTrongSuotNenChu(label1, picNenDK);
            LamTrongSuotNenChu(picMayBay, picNenDK);
            LamTrongSuotNenChu(picThoat, picDangKi);
        }
        void LamTrongSuotNenChu(Control x, PictureBox nenX) //x là textbox, nenX là pictureBox nằm dưới textbox
        {
            var a = this.PointToScreen(x.Location);
            a = nenX.PointToClient(a);
            x.Parent = nenX;
            x.Location = a;
            x.BackColor = Color.Transparent;

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

        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaiKhoan_DK.Text.Length <= 0 || txtMatKhau_DK.Text.Length <= 0 || txtNhapLaiMatKhau_DK.Text.Length <= 0)
                {
                    lbl_ThongBao.Text = "Hãy nhập đầy đủ thông tin";
                    return;
                }
                if (txtMatKhau_DK.Text != txtNhapLaiMatKhau_DK.Text)
                {
                    lbl_ThongBao.Text = "Mật khẩu không chính xác";
                    return;

                }
                if (db_Dk.KTTaiKhoan(txtTaiKhoan_DK.Text))
                {
                    int kq = db_Dk.ThemTaiKHoan(txtTaiKhoan_DK.Text, txtMatKhau_DK.Text);
                    if (kq > 0)
                    {
                        lbl_ThongBao.Text = "Đăng kí tài khoản thành công";
                        lbl_ThongBao.ForeColor = Color.Green;
                        return;

                    }
                }
                else
                {
                    lbl_ThongBao.Text = "Tài khoản đã tồn tại";
                    return;

                }
            }
            catch (Exception ex)
            {
                lbl_ThongBao.Text = "Thêm  thất bại";
                return;

            }
        }
        private void txtTaiKhoan_DK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
    }
}
