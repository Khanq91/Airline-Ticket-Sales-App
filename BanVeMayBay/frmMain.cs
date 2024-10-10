using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmMain : Form
    {
        public List<TTNguoiLon> ListNguoiLon { get; private set; } = new List<TTNguoiLon>();
        public List<TTEmBe> ListEmBe { get; private set; } = new List<TTEmBe>();
        public List<TTTreEm> ListTreEm { get; private set; } = new List<TTTreEm>();

        string tennguoidung;
        public frmMain(string TenNguoiDung)
        {
            this.tennguoidung = TenNguoiDung;
            InitializeComponent();
            lblChaoNguoiDung.Text = "Xin Chào" + tennguoidung;
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


        private void picReset_Click(object sender, EventArgs e)
        {
            //phương thức reset form khi ấn nút reset
            this.Hide();
            Form frmm = new frmMain(tennguoidung);
            frmm.FormClosed += (s, args) => this.Close();
            frmm.Show();
        }
        public void ShowTTCB(int slNL, int slTE, int slEB, string ngaybay, string diemkhoihanh, string diemden)
        {
            pnlTTCB.Visible = true;
            pnlTTCB.Location = new Point(0, 144);
            //pnlThanGiaoDien.Location = new Point(0, 229);
            pnlThanGiaoDien.Location = new Point(0, 313);
            //pnlThanGiaoDien.Height -= 200;
            //pnlThanGiaoDien.Height -= 84;

            //xuất hiện footer chứa nút đi tiếp
            pnlThanGiaoDien.Height -= 171;
            pnlDuoiGiaoDien.Visible = true;

            pnlThanGiaoDien.Width -= 555;
            flowLayoutPnlThanGianDien.Width -= 555;
            pnlTTVeDat.Visible = true;
            flowLayoutPanelTTVeDat.Visible = true;
            //pnlThanGiaoDien.Size = new Size(1322, 602);
            flowLayoutPnlThanGianDien.Padding = new Padding(20, 20, 20, 20);
            xuatDSTTHK(slNL, slTE, slEB);




            //frmTTDatVe xuất hiện
            //string tvv, string ngaybay, string tgdi, string tgden,
            //string machuyenbay, string hangve, string diemkhoihanh, string diemden
            frmTTVeDat frmttvd = new frmTTVeDat("", ngaybay, "", "", "", "BUSINESS1", diemkhoihanh, diemden);
            frmttvd.TopLevel = false;
            flowLayoutPanelTTVeDat.Controls.Add(frmttvd);
            frmttvd.Show();

            //flowLayoutPnlThanGianDien.Size = new Size(920, 610);
            //pnlThanGiaoDien.Size = new Size(920, 610);
            //flowLayoutPnlThanGianDien.Location = new Point(0, 300);

            //frmNhapTT_Main frmtt = new frmNhapTT_Main();
            //frmtt.TopLevel = false;
            //flowLayoutPnlThanGianDien.Controls.Add(frmtt);
            //frmtt.Show();
            //frmtt.ShowTTHK(slNL, slTE, slEB);
        }

        public void xuatDSTTHK(int slNL, int slTE, int slEB)
        {
            int i;
            for (i = 0; i < slNL; i++)
            {
                frmNhapTT_NguoiLon frmNL = new frmNhapTT_NguoiLon();
                frmNL.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmNL);
                frmNL.Show();
            }
            for (i = 0; i < slTE; i++)
            {
                frmNhapTT_TreEm frmTE = new frmNhapTT_TreEm();
                frmTE.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmTE);
                frmTE.Show();
            }
            for (i = 0; i < slEB; i++)
            {
                frmNhapTT_EmBe frmEB = new frmNhapTT_EmBe();
                frmEB.TopLevel = false;
                flowLayoutPnlThanGianDien.Controls.Add(frmEB);
                frmEB.Show();
            }
            btnNhapTTHK.Visible = true;
        }

        public void NhapKhachHang(List<TTNguoiLon> nguoiLon, List<TTEmBe> emBe, List<TTTreEm> treEm)
        {
            ListNguoiLon = nguoiLon;
            ListEmBe = emBe;
            ListTreEm = treEm;

            // Có thể hiển thị thông tin hoặc xử lý dữ liệu ở đây

            StringBuilder sb = new StringBuilder();
            foreach (var khachHang in ListNguoiLon)
            {
                sb.AppendLine($"Tên: {khachHang.TenKH}\nGiới tính: {khachHang.Gioitinh}\nNgày sinh: {khachHang.NgaySinh.ToShortDateString()}\n");
            }
            MessageBox.Show(sb.ToString(), "Thông tin khách hàng");
        }
        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            NhapKhachHang(ListNguoiLon, ListEmBe,ListTreEm );
            flowLayoutPnlThanGianDien.Controls.Clear();
            //frmChonDV frmDV = new frmChonDV();
            //frmDV.TopLevel = false;

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
