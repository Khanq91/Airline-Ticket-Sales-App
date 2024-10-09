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
    public partial class frmQuanLi : Form
    {
        string tennguoidung;
        public frmQuanLi(string tennguoidung)
        {
            InitializeComponent();
            this.tennguoidung = tennguoidung;
        }
        //startPosition cho thân giao diện (396, 142), Size(1502, 782)
        private void frmQuanLi_Load(object sender, EventArgs e)
        {
            lblChaoNguoiDung.Text = "Xin chào nhân viên: " + tennguoidung;
        }
    }
}
