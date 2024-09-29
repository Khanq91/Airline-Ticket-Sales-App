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
    public partial class frmCon_frmChonDiaDiemDatVe : Form
    {

        string _SLnl;
        string _SLte;
        string _SLeb;

        public string SLnl { get => _SLnl; set => _SLnl = value; }
        public string SLte { get => _SLte; set => _SLte = value; }
        public string SLeb { get => _SLeb; set => _SLeb = value; }

        public frmCon_frmChonDiaDiemDatVe()
        {
            InitializeComponent();
        }

        private async void picThemNL_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int sl = int.Parse(lblSLNguoiLon.Text);
                if (sl < 5)
                {
                    sl += 1;
                    lblSLNguoiLon.Invoke((MethodInvoker)(() => lblSLNguoiLon.Text = sl.ToString()));
                }
            });
        }
        private async void picGiamNL_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int sl = int.Parse(lblSLNguoiLon.Text);
                if (sl > 1)
                {
                    sl -= 1;
                    lblSLNguoiLon.Invoke((MethodInvoker)(() => lblSLNguoiLon.Text = sl.ToString()));
                }
            });
        }

        private async void picThemTE_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int sl = int.Parse(lblSLTreEm.Text);
                if (sl < 5)
                {
                    sl += 1;
                    lblSLTreEm.Invoke((MethodInvoker)(() => lblSLTreEm.Text = sl.ToString()));
                }
            });

        }
        private async void picGiamTE_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int sl = int.Parse(lblSLTreEm.Text);
                if (sl > 0)
                {
                    sl -= 1;
                    lblSLTreEm.Invoke((MethodInvoker)(() => lblSLTreEm.Text = sl.ToString()));
                }
            });
        }

        private async void picThemEB_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int sl = int.Parse(lblSLEmBe.Text);
                if (sl < 5)
                {
                    sl += 1;
                    lblSLEmBe.Invoke((MethodInvoker)(() => lblSLEmBe.Text = sl.ToString()));
                }
            });

        }

        private async void picGiamEB_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int sl = int.Parse(lblSLEmBe.Text);
                if (sl > 0)
                {
                    sl -= 1;
                    lblSLEmBe.Invoke((MethodInvoker)(() => lblSLEmBe.Text = sl.ToString()));
                }
            });

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int nl = int.Parse(lblSLNguoiLon.Text);
            int te = int.Parse(lblSLTreEm.Text);
            int eb = int.Parse(lblSLEmBe.Text);

            if (nl > 1)
            {
                SLnl = lblSLNguoiLon.Text;
            }
            else SLnl = "1";
            if (te > 0)
            {
                SLte = lblSLTreEm.Text;
            }
            else SLte = "0";
            if (eb > 0)
            {
                SLeb = lblSLEmBe.Text;
            }
            else SLeb = "0";
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
