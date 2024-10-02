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
using DB;
namespace BanVeMayBay
{
    public partial class frmDangNhap : Form
    {
        DangNhap db_DN = new DangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
            var a = this.PointToScreen(btnDangKi.Location);
            a = picDangNhap.PointToClient(a);

            LamTrongSuotNenChu(label1, picNenDN);
            LamTrongSuotNenChu(picMayBay, picNenDN);
            LamTrongSuotNenChu(picThoat, picDangNhap);
        }
        void LamTrongSuotNenChu(Control x, PictureBox nenX) //x là textbox, nenX là pictureBox nằm dưới textbox
        {
            var a = this.PointToScreen(x.Location);
            a = nenX.PointToClient(a);
            x.Parent = nenX;
            x.Location = a;
            x.BackColor = Color.Transparent;

            //var a = this.PointToScreen(label1.Location);
            //a = picNenDN.PointToClient(a);
            //label1.Parent = picNenDN;
            //label1.Location = a;
            //label1.BackColor = Color.Transparent;
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

        private void picThoat_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        { 
            string Taikhoan=txtTaiKhoan_DN.Text.Trim();
            string MatKhau=txtMatKhau_DN.Text.Trim();
            string TenNguoiDung = db_DN.KTraTaiKhoan(Taikhoan, MatKhau);
            if (TenNguoiDung != null) {
                this.Hide();
                frmMain frmMain = new frmMain(TenNguoiDung);
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.");
            }
            

        }
    }
}
