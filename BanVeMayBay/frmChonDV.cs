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
        string _TenViTriGhe;
        string _GiaViTriGhe;
        string _TenGoi;
        string _GiaGoi;
        public string TenViTriGhe { get => _TenViTriGhe; set => _TenViTriGhe = value; }
        public string GiaViTriGhe { get => _GiaViTriGhe; set => _GiaViTriGhe = value; }
        public string TenGoi { get => _TenGoi; set => _TenGoi = value; }
        public string GiaGoi { get => _GiaGoi; set => _GiaGoi = value; }


        frmViTriGhe frmGhe = new frmViTriGhe();
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

                    this.TenViTriGhe = frmGhe.ViTriGhe;
                    this.GiaViTriGhe = frmGhe.GiaGhe;

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

                    this.TenGoi = frmHL.TenGoi;
                    this.GiaGoi = frmHL.GiaGoi;

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
        public string output(string Ghe, string GiaGhe, string GoiHL, string GiaGoiHL)
        {
            if (Ghe == "1")
            {
                return TenViTriGhe;
            }
            else if (GiaGhe == "1")
            {
                return GiaViTriGhe;
            }
            else if (GoiHL == "1")
            {
                return TenGoi;
            }
            else if (GiaGoiHL == "1")
            {
                return GiaGoi;
            }
            else return "0";
        }
    }
}
