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

        private List<int> _SL;
        private List<string> _DuLieu;

        public List<int> SL { get => _SL; set => _SL = value; }
        public List<string> DuLieu { get => _DuLieu; set => _DuLieu = value; }

        public frmCon_frmChonDiaDiemDatVe()
        {
            InitializeComponent();
            SL = new List<int>();
            DuLieu = new List<string>();
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
            string str_nl = lblNguoiLon.Text;
            string str_te = lblSLTreEm.Text;
            string str_eb = lblSLEmBe.Text;

            if (nl > 1)
            {
                SL.Add(nl);
                DuLieu.Add(str_nl);
            }
            else if (te > 0)
            {
                SL.Add(te);
                DuLieu.Add(str_te);
            }
            else if (eb > 0)
            {
                SL.Add(eb);
                DuLieu.Add(str_eb);
            }
            else return;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
