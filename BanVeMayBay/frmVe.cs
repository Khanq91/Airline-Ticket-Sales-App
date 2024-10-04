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
    public partial class frmVe : Form
    {
        public frmVe()
        {
            InitializeComponent();
        }

        private void frmVe_Load(object sender, EventArgs e)
        {
            this.Height = 160;
            //VD: giá của hạng vé 1 = 1000000 thì lblGiaHV1.Text bằng 1.000
            lblGiaHV1.Text = "500";
            lblGiaHV2.Text = "1.000";
            lblGiaHV3.Text = "1.500";
            lblGiaHV4.Text = "2.000";
        }

        private void pnlHangVe1_Click(object sender, EventArgs e)
        {
            pnlHangVe1.ForeColor = System.Drawing.Color.Red;
        }

        private void pnlHangVe2_Click(object sender, EventArgs e)
        {

        }

        private void pnlHangVe3_Click(object sender, EventArgs e)
        {

        }
        private void pnlHangVe4_Click(object sender, EventArgs e)
        {

        }

        private void pnlTTCB_Click(object sender, EventArgs e)
        {

        }
    }
}
