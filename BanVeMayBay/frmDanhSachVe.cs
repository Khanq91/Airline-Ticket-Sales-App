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
            frmVe frmv = new frmVe();
            frmv.TopLevel = false;
            flowLayoutPnlDSVe.Controls.Add(frmv);
            frmv.Show();
            frmVe frmve = new frmVe();
            frmve.TopLevel = false;
            flowLayoutPnlDSVe.Controls.Add(frmve);
            frmve.Show();
        }
    }
}
