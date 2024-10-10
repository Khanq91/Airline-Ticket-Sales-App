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
    public partial class frmChonDV : Form
    {
        public frmChonDV()
        {
            InitializeComponent();
        }

        private void btnChonGhe_Click(object sender, EventArgs e)
        {
            //if(pnlDichVu.Visible == false)
            //{
            //    pnlDichVu.Visible = true;
            //}
            //else
            //{
            //    pnlDichVu.Visible = false;
            //}
        }
        frmHanhLy frmHL = new frmHanhLy();
        bool kt = false;
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
