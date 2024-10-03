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
    public partial class frmNhapTT_NguoiLon : Form
    {
        public frmNhapTT_NguoiLon()
        {
            InitializeComponent();
        }

        private void frmNhapTT_Load(object sender, EventArgs e)
        {
            txtHo_NL.Focus();
            dateTimePickerNgaySinh_NL.MaxDate = DateTime.Now;
            cboQuocGia_NL.SelectedItem = "Vietnam";
            cboQuocGia_NL.MaxDropDownItems = 5;
        }
    }
}
