using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{

    public partial class frmNhapTT_Main : Form
    {
        List<TTNguoiLon> lstNguoiLon=new List<TTNguoiLon>();
        List<TTEmBe> lstEmBe=new List<TTEmBe>();
        List<TTTreEm> lstTreEm=new List<TTTreEm>();
        frmNhapTT_NguoiLon frmNL;
        frmNhapTT_TreEm frmTreEm;
        frmNhapTT_EmBe frmEmBe;
        public frmNhapTT_Main()
        {
            InitializeComponent();
           
        }

        private void frmNhapTT_Main_Load(object sender, EventArgs e)
        {
        }
        public void ShowTTHK(int slNL, int slTE, int slEB)
        {
            int i;
            for (i = 0; i < 1; i++)
            {
                frmNhapTT_NguoiLon frmNL = new frmNhapTT_NguoiLon();
                frmNL.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmNL);
                frmNL.Show();
            }
            for (i = 0; i < slTE; i++)
            {
                frmNhapTT_TreEm frmTE = new frmNhapTT_TreEm();
                frmTE.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmTE);
                frmTE.Show();
            }
            for (i = 0; i < slEB; i++)
            {
                frmNhapTT_EmBe frmEB = new frmNhapTT_EmBe();
                frmEB.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmEB);
                frmEB.Show();
            }
        }

        public void show()
        {
            int i;
            for (i = 0; i < 1; i++)
            {
                frmNhapTT_NguoiLon frmNL = new frmNhapTT_NguoiLon();
                frmNL.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmNL);
                frmNL.Show();
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TTNguoiLon();
            StringBuilder sb = new StringBuilder();
            foreach (var khachHang in lstNguoiLon)
            {
                sb.AppendLine($"Tên: {khachHang.TenKH}\nGiới tính: {khachHang.Gioitinh}\nNgày sinh: {khachHang.NgaySinh.ToShortDateString()}\n");
            }
            MessageBox.Show(sb.ToString(), "Thông tin khách hàng");
        }
       public void TTTreEm()
        {
            foreach (Control control in flowLayoutPanelTT.Controls)
            {
                if (control is frmNhapTT_EmBe frmEmBE)
                {
                    var khachHang = frmEmBE.GetKhachHang(); // Lấy thông tin
                    if (khachHang != null) // Kiểm tra thông tin có hợp lệ không
                    {
                        lstEmBe.Add(khachHang); // Thêm vào danh sách
                    }
                }
            }
        }
        public void TTNguoiLon()
        {
            foreach (Control control in flowLayoutPanelTT.Controls)
            {
                if (control is frmNhapTT_NguoiLon frmNL)
                {
                    var nguoiLon = frmNL.GetKhachHang(); // Lấy thông tin
                    if (nguoiLon != null) // Kiểm tra thông tin có hợp lệ không
                    {
                        lstNguoiLon.Add(nguoiLon); // Thêm vào danh sách
                    }
                }
            }
        }
        public void TTEmBe()
        {
            foreach (Control control in flowLayoutPanelTT.Controls)
            {
                if (control is frmNhapTT_TreEm frmtreem)
                {
                    var khachHang = frmtreem.GetKhachHang(); // Lấy thông tin
                    if (khachHang != null) // Kiểm tra thông tin có hợp lệ không
                    {
                        lstTreEm.Add(khachHang); // Thêm vào danh sách
                    }
                }
            }
        }
        public void LayTatCaThongTinKhachHang()
        {
            TTNguoiLon();
            TTEmBe();
            TTTreEm();

            // Gọi phương thức từ Form 1 để truyền dữ liệu
            frmMain mainForm = (frmMain)this.Owner; // Lấy tham chiếu đến Form 1
            mainForm.NhapKhachHang(lstNguoiLon, lstEmBe, lstTreEm);
        }
    }
}
