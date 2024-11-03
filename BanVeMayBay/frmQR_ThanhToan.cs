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
    public partial class frmQR_ThanhToan : Form
    {
        string _TenNganHang;
        string _SoTienThanhToan;
        public string TenNganHang { get => _TenNganHang; set => _TenNganHang = value; }
        public string SoTienThanhToan { get => _SoTienThanhToan; set => _SoTienThanhToan = value; }
        public frmQR_ThanhToan(string tenNganHang, string soTienTT)
        {
            InitializeComponent();
            this.TenNganHang = tenNganHang;
            this.SoTienThanhToan = soTienTT;
        }

        private void frmQR_ThanhToan_Load(object sender, EventArgs e)
        {
            lblTenNganHang.Text = this.TenNganHang;
            lblSoTienTT.Text = this.SoTienThanhToan;
        }

        private void lblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
