using DB;
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
        public TTTreEm KhachHangData { get; private set; }
        public frmNhapTT_TreEm()
        {
            InitializeComponent();
            KhachHangData = new TTTreEm();

        }

        private void frmNhapTT_TreEm_Load(object sender, EventArgs e)
        {
            txtHo_TE.Focus();
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
        public bool IsValid()
        {
            if (txtHo_TE.Text.Length < 0
               || txtTenDemvaTen_TE.Text.Length < 0
               || string.IsNullOrWhiteSpace(cboGioiTinh_TE.Text)
               )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public TTTreEm GetKhachHang()
        {
            if (!IsValid())
            {
                return null;
            }
            TTTreEm tt = new TTTreEm();
            tt.TenKH = txtHo_TE.Text + txtTenDemvaTen_TE.Text;

            string dateString = mtxtNgaySinh_TE.Text;
            DateTime dateValue;
            try
            {
                if (DateTime.TryParse(dateString, out dateValue))
                {
                    tt.NgaySinh = dateValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển đổi ngày sinh" + ex.Message);
            }

            tt.Gioitinh = cboGioiTinh_TE.Text;
            return tt; 
        }

    }
}
