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
    public partial class frmNhapTT_Main : Form
    {
        public frmNhapTT_Main()
        {
            InitializeComponent();
        }

        private void frmNhapTT_Main_Load(object sender, EventArgs e)
        {
        }
        public void ShowTTHK(int slNL, int slTE, int slEB)
        {
            int i;
            for (i = 0;i < slNL; i++)
            {
                frmNhapTT_NguoiLon frmNL = new frmNhapTT_NguoiLon();
                frmNL.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmNL);
                frmNL.Show();
            }
            for (i = 0; i < slTE; i++)
            {
                frmNhapTT_TreEm frmTE = new frmNhapTT_TreEm();
                frmTE.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmTE);
                frmTE.Show();
            }
            for (i = 0; i < slEB; i++)
            {
                frmNhapTT_EmBe frmEB = new frmNhapTT_EmBe();
                frmEB.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmEB);
                frmEB.Show();
            }
        }
    }
}
