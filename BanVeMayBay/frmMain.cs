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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        void LamTrongSuotNenChu(Control x, PictureBox nenX) //x là textbox, nenX là pictureBox nằm dưới textbox
        {
            var a = this.PointToScreen(x.Location);
            a = nenX.PointToClient(a);
            x.Parent = nenX;
            x.Location = a;
            x.BackColor = Color.Transparent;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //nếu phân quyền là admin thì nút quản lý dữ liệu xuất hiện
            //btnQuanLy.Visible = true;
            frmDangNhap frmdn = new frmDangNhap();
            frmdn.Close();
            lblChaoNguoiDung.Text = "Xin chào + tên người dùng";
            pnlDuoiGiaoDien.Visible = false;
            pnlThanGiaoDien.Height += 87;


            frmChonDiaDiemDatVe frmCDDDV = new frmChonDiaDiemDatVe();
            frmCDDDV.TopLevel = false;
            flowLayoutPnlThanGianDien.Controls.Add(frmCDDDV);
            frmCDDDV.Show();
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picThoat_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void picReset_Click(object sender, EventArgs e)
        {
            //phương thức reset form khi ấn nút reset
            this.Hide();
            Form frmm = new frmMain();
            frmm.FormClosed += (s, args) => this.Close();
            frmm.Show();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    frmChonDichVu cdvfrm = new frmChonDichVu();
        //    cdvfrm.TopLevel = false;
        //    flowLayoutPanel1.Controls.Add(cdvfrm);
        //    cdvfrm.Show();
        //}
    }
}
