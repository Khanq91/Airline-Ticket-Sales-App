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
    public partial class frmNhapTT_EmBe : Form
    {
        public frmNhapTT_EmBe()
        {
            InitializeComponent();
        }

        private void frmNhapTT_EmBe_Load(object sender, EventArgs e)
        {
            txtBayCung_EB.Focus();
            dateTimePickerNgaySinh_EB.MaxDate = DateTime.Now;
        }
    }
}
