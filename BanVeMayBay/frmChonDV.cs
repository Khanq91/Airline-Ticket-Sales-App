using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmChonDV : Form
    {
        public frmChonDV()
        {
            InitializeComponent();
        }
        bool kt = false;
        frmViTriGhe frmGhe = new frmViTriGhe();
        public string TenViTriGhe;
        public string GiaViTriGhe;
        private void btnChonGhe_Click(object sender, EventArgs e)
        {
            if(kt)
            {
                frmGhe.Hide();
                kt = false; 
            }    
            else
            {
                if(frmGhe == null || frmGhe.IsDisposed)
                {
                    frmGhe = new frmViTriGhe();
                }
                frmGhe.Location = new Point(730, 190);
                DialogResult result = frmGhe.ShowDialog();
                kt = true;
                if (result == DialogResult.OK)
                {
                    lblMaGhe.Visible = true;
                    lblTienGhe.Visible = true;

                    TenViTriGhe = frmGhe.ViTriGhe;
                    GiaViTriGhe = frmGhe.GiaGhe;

                    lblMaGhe.Text = TenViTriGhe;
                    lblTienGhe.Text = GiaViTriGhe;
                }
                else
                {
                    lblMaGhe.Visible = false;
                    lblTienGhe.Visible = false;

                    TenViTriGhe = "";
                    GiaViTriGhe = "";
                }
            }    
        }
        frmHanhLy frmHL = new frmHanhLy();
        public string TenGoi;
        public string GiaGoi;
        private void btnGoiHanhLy_Click(object sender, EventArgs e)
        {
            if(kt)
            {
                frmHL.Hide();
                kt = false;
            }    
            else 
            {
                if (frmHL == null || frmHL.IsDisposed)
                {
                    frmHL = new frmHanhLy();
                    //pnlDichVu.Controls.Add(frmHL);
                }
                frmHL.Location = new Point(730, 190);
                DialogResult result = frmHL.ShowDialog();
                kt = true;
                if (result == DialogResult.OK)
                {
                    lblGoiHanhLy.Visible = true;
                    lblTienHL.Visible = true;

                    TenGoi = frmHL.TenGoi;
                    GiaGoi = frmHL.GiaGoi;

                    lblGoiHanhLy.Text = TenGoi;
                    lblTienHL.Text = GiaGoi;
                }
                else
                {
                    lblGoiHanhLy.Visible = false;
                    lblTienHL.Visible = false;
                    TenGoi = "";
                    GiaGoi = "";
                }
                    
            }
        }
    }
}
