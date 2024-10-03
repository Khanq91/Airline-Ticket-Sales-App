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
        string tennguoidung;
        public frmMain(string Tennguoidung)
        {
            InitializeComponent();
            this.tennguoidung = Tennguoidung;
            lblChaoNguoiDung.Text = "Xin chào " + tennguoidung;
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
            Form frmm = new frmMain(tennguoidung);
            frmm.FormClosed += (s, args) => this.Close();
            frmm.Show();
        }
        public void ShowTTCB(int slNL, int slTE, int slEB)
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

            int i;
            //flowLayoutPnlThanGianDien.Size = new Size(920, 610);
            //pnlThanGiaoDien.Size = new Size(920, 610);
            //flowLayoutPnlThanGianDien.Location = new Point(0, 300);
            for (i = 0; i < slNL; i++)
            {
                frmNhapTT_NguoiLon frmTTNL = new frmNhapTT_NguoiLon();
                frmTTNL.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmTTNL);
                frmTTNL.Show();
            }
            for (i = 0; i < slTE; i++)
            {
                frmNhapTT_TreEm frmTTTE = new frmNhapTT_TreEm();
                frmTTTE.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmTTTE);
                frmTTTE.Show();
            }
            for (i = 0; i < slEB; i++)
            {
                frmNhapTT_EmBe frmTTEB = new frmNhapTT_EmBe();
                frmTTEB.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmTTEB);
                frmTTEB.Show();
            }

        }

        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            flowLayoutPnlThanGianDien.Controls.Clear();
            frmChonDV frmDV = new frmChonDV();
            frmDV.TopLevel = false;
            flowLayoutPnlThanGianDien.Controls.Add(frmDV);
            frmDV.Show();
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
