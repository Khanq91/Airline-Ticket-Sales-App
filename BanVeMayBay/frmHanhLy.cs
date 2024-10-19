using BanVeMayBay.Properties;
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
    public partial class frmHanhLy : Form
    {
        string _TenGoi;
        string _GiaGoi;
        List<PictureBox> pices = new List<PictureBox>();

        public string TenGoi { get => _TenGoi; set => _TenGoi = value; }
        public string GiaGoi { get => _GiaGoi; set => _GiaGoi = value; }

        public frmHanhLy()
        {
            InitializeComponent();

            pices.AddRange(new[] { picGoi1, picGoi2, picGoi3, picGoi4, picGoi5, picGoi6 });
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }
        private void picGoi1_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picc in pices)
            {
                picc.Image = Resources.add2;
            }
            picGoi1.Image = Resources.correct;
            lblTenGoi.Text = lblTenGoi1.Text;
            lblGiaGoi.Text = lblGiaGoi1.Text;

            TenGoi = lblTenGoi.Text;
            GiaGoi = lblGiaGoi.Text.Replace(" VND", "");

            lblTenGoi.Visible = true;
            lblGiaGoi.Visible = true;
        }
        private void picGoi2_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picc in pices)
            {
                picc.Image = Resources.add2;
            }
            picGoi2.Image = Resources.correct;
            lblTenGoi.Text = lblTenGoi2.Text;
            lblGiaGoi.Text = lblGiaGoi2.Text;

            TenGoi = lblTenGoi.Text;
            GiaGoi = lblGiaGoi.Text.Replace(" VND", "");

            lblTenGoi.Visible = true;
            lblGiaGoi.Visible = true;
        }
        private void picGoi3_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picc in pices)
            {
                picc.Image = Resources.add2;
            }
            picGoi3.Image = Resources.correct;
            lblTenGoi.Text = lblTenGoi3.Text;
            lblGiaGoi.Text = lblGiaGoi3.Text;

            TenGoi = lblTenGoi.Text;
            GiaGoi = lblGiaGoi.Text.Replace(" VND", "");

            lblTenGoi.Visible = true;
            lblGiaGoi.Visible = true;
        }
        private void picGoi4_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picc in pices)
            {
                picc.Image = Resources.add2;
            }
            picGoi4.Image = Resources.correct;
            lblTenGoi.Text = lblTenGoi4.Text;
            lblGiaGoi.Text = lblGiaGoi4.Text;

            TenGoi = lblTenGoi.Text;
            GiaGoi = lblGiaGoi.Text.Replace(" VND", "");

            lblTenGoi.Visible = true;
            lblGiaGoi.Visible = true;
        }
        private void picGoi5_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picc in pices)
            {
                picc.Image = Resources.add2;
            }
            picGoi5.Image = Resources.correct;
            lblTenGoi.Text = lblTenGoi5.Text;
            lblGiaGoi.Text = lblGiaGoi5.Text;

            TenGoi = lblTenGoi.Text;
            GiaGoi = lblGiaGoi.Text.Replace(" VND", "");

            lblTenGoi.Visible = true;
            lblGiaGoi.Visible = true;
        }
        private void picGoi6_Click(object sender, EventArgs e)
        {
            foreach (PictureBox picc in pices)
            {
                picc.Image = Resources.add2;
            }
            picGoi6.Image = Resources.correct;
            lblTenGoi.Text = lblTenGoi6.Text;
            lblGiaGoi.Text = lblGiaGoi6.Text;

            TenGoi = lblTenGoi.Text;
            GiaGoi = lblGiaGoi.Text.Replace(" VND","");

            lblTenGoi.Visible = true;
            lblGiaGoi.Visible = true;
        }

    }
}
