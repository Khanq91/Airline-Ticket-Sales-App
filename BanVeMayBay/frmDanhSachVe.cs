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
    public partial class frmDanhSachVe : Form
    {
        public frmDanhSachVe()
        {
            InitializeComponent();
        }

        private void frmDanhSachVe_Load(object sender, EventArgs e)
        {
            //thông tin test cho các vé máy bay trong 1 ngày
            string[] diemkh_test = { "TP. HCM", "Cần Thơ", "Trà Vinh", "Hà Nội", "Vĩnh Long", "Nha Trang", "Huế", "Hải Phòng", "Cao Bằng", "Phú Quốc" };
            string[] diemden_test = { "Phú Quốc", "Cao Bằng", "Hải Phòng", "Huế", "Nha Trang", "Vĩnh Long", "Hà Nội", "Trà Vinh", "Cần Thơ", "TP. HCM" };
            string ngaykh_test = "9/1/2004";
            string[] tgdi_test = { "8:30", "9:30", "10:30", "11:30", "12:30", "13:30", "14:30", "15:30", "16:30", "17:30" };
            string[] tgden_test = { "11:30", "12:30", "13:30", "14:30", "15:30", "16:30", "17:30", "18:30", "19:30", "20:30" };
            string[] macb_test = { "CBDuo01", "CBDuo02", "CBDuo03", "CBDuo04", "CBDuo05", "CBDuo06", "CBDuo07", "CBDuo08", "CBDuo09", "CBDuo10", };
            string[] mamb_test = { "MBDuo01", "MBDuo02", "MBDuo03", "MBDuo04", "MBDuo05", "MBDuo06", "MBDuo07", "MBDuo08", "MBDuo09", "MBDuo10", };
            //Nhập số lượng vé từ sql vào n
            //còn thông tin của vé nhập bên form frmVe
            int n = 10; //tỏng số lượng vé sẽ xuất hiện trên form
            for(int i = 0; i < n; i++)
            {
                //Truyền thông tin của vé vào (thời gian đi, thời gian đến, mã chuyến bay, mã máy bay)
                frmVe frmv = new frmVe(diemkh_test[i], diemden_test[i], ngaykh_test, tgdi_test[i], tgden_test[i], macb_test[i], mamb_test[i]);
                frmv.TopLevel = false;
                flowLayoutPnlDSVe.Controls.Add(frmv);
                frmv.Show();
            }
        }
    }
}
