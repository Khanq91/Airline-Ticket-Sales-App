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
    }
}
