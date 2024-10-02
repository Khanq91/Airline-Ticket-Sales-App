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
            pnlTTCB.Visible = false;
            pnlThanGiaoDien.Location = new Point(0, 140);
            frmDangNhap frmdn = new frmDangNhap();
            frmdn.Close();
            lblChaoNguoiDung.Text = "Xin chào + tên người dùng";
            pnlDuoiGiaoDien.Visible = false;
            pnlThanGiaoDien.Height += 171;


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
        public void ShowTTCB()
        {
            pnlTTCB.Visible = true; 
            pnlThanGiaoDien.Location = new Point(0, 229);
            pnlThanGiaoDien.Height -= 171;
            pnlDuoiGiaoDien.Visible = true;

            pnlThanGiaoDien.Width -= 555;
            flowLayoutPnlThanGianDien.Width -= 555;
            pnlTTVeDat.Visible = true;
            flowLayoutPanelTTVeDat.Visible = true;

            //frmTTDatVe xuất hiện
            frmTTVeDat frmttvd = new frmTTVeDat();
            frmttvd.TopLevel = false;
            flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
            frmttvd.Show();
            
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
