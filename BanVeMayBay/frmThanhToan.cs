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
    public partial class frmThanhToan : Form
    {
        string _TamTinh;
        public string TamTinh { get => _TamTinh; set => _TamTinh = value; }
        public frmThanhToan(string tamtinh)
        {
            InitializeComponent();
            this.TamTinh = tamtinh;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblTamTinh.Text = TamTinh;
        }
        public void ThanhTien()
        {
            #region Vì là không có giảm giá gì cả, nên không tính nhá
            //float tamtinh = float.Parse(TamTinh.Replace(".", ""));
            //float giamgia = float.Parse(lblKhuyenMai.Text.Replace(".", ""));
            //float tongtien = tamtinh - giamgia;
            //lblTongTien.Text = string.Format("{0:n0}", tongtien);
            //lblTongTien.Text = string.Format("{0:n0}", tamtinh);
            #endregion
            lblTongTien.Text = TamTinh;
        }
    }
}
