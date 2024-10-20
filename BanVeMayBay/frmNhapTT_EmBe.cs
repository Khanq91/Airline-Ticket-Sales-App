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
    public partial class frmNhapTT_EmBe : Form
    {
        private TTEmBe ttEmBe;

        public TTEmBe TtEmBe { get => ttEmBe; set => ttEmBe = value; }

        public frmNhapTT_EmBe()
        {
            InitializeComponent();
            ttEmBe = new TTEmBe();

        }

        private void frmNhapTT_EmBe_Load(object sender, EventArgs e)
        {
            txtBayCung_EB.Focus();
            //dateTimePickerNgaySinh_EB.MaxDate = DateTime.Now;
        }

        private void txtBayCung_EB_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtBayCung_EB.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy cho biết người bay cùng bé!");
            else
                this.erpNhapTT.Clear();
        }

        private void txtHo_EB_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtHo_EB.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy cho biết họ của bé!");
            else
                this.erpNhapTT.Clear();
        }

        private void txtTenDemvaTen_EB_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (txtTenDemvaTen_EB.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy cho biết tên và tên đệm của bé!");
            else
                this.erpNhapTT.Clear();

        }
        private void cboGioiTinh_EB_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (cboGioiTinh_EB.Text.Trim().Length == 0)
                this.erpNhapTT.SetError(ctr, "Bạn hãy cho biết giới tính của bé!");
            else
                this.erpNhapTT.Clear();
        }
        public bool Isvalid()
        {
            if (txtBayCung_EB.Text.Length < 0
               || txtHo_EB.Text.Length < 0
               || txtTenDemvaTen_EB.Text.Length < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public TTEmBe GetKhachHang()
        {
            if (!Isvalid())
            {
                return null;
            }
            TTEmBe ttembe = new TTEmBe();
            ttembe.NguoiBayCung = txtBayCung_EB.Text;
            ttembe.TenKH = txtHo_EB.Text + txtTenDemvaTen_EB.Text;
            //ttembe.NgaySinh = dateTimePickerNgaySinh_EB.Value;

            string dateString = mtxtNgaySinh_EB.Text;
            DateTime dateValue;
            try
            {
                if (DateTime.TryParse(dateString, out dateValue))
                {
                    ttembe.NgaySinh = dateValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển đổi ngày sinh" + ex.Message);
            }
            ttembe.Gioitinh = cboGioiTinh_EB.Text;

            return ttembe;
        }
    }
}
