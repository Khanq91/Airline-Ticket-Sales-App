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
    public partial class frmNhapTT : Form
    {
        public frmNhapTT()
        {
            InitializeComponent();
        }

        private void frmNhapTT_Load(object sender, EventArgs e)
        {
            txtHo.Focus();
            dateTimePickerNgaySinh.MaxDate = DateTime.Now;
            cboQuocGia.SelectedItem = "Vietnam";
            cboQuocGia.MaxDropDownItems = 5;
        }
    }
}
