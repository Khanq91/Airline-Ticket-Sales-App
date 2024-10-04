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
    public partial class frmNhapTT_TreEm : Form
    {
        public frmNhapTT_TreEm()
        {
            InitializeComponent();
        }

        private void frmNhapTT_TreEm_Load(object sender, EventArgs e)
        {
            txtHo_TE.Focus();
            dateTimePickerNgaySinh_TE.MaxDate = DateTime.Now;
        }

        private void txtHo_TE_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtHo_TE.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn phải họ cho trẻ!");
            else
                this.erpNhapTT.Clear();
        }

        private void txtTenDemvaTen_TE_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtTenDemvaTen_TE.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn phải tên và tên đệm cho trẻ!");
            else
                this.erpNhapTT.Clear();
        }

        private void cboGioiTinh_TE_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (cboGioiTinh_TE.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn chọn giới tính cho trẻ!");
            else
                this.erpNhapTT.Clear();
        }
    }
}
