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
        frmNhapTT_NguoiLon frmNL = new frmNhapTT_NguoiLon();
        frmNhapTT_TreEm frmTE = new frmNhapTT_TreEm();
        frmNhapTT_EmBe frmEB = new frmNhapTT_EmBe();
        public frmNhapTT_Main()
        {
            InitializeComponent();
        }

        private void frmNhapTT_Main_Load(object sender, EventArgs e)
        {
        }
        public void ShowTTHK(int slNL, int slTE, int slEB)
        {
            for (int i = 0;i < slNL; i++)
            {
                frmNL.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmNL);
                frmNL.Show();
            }
            for (int i = 0; i < slTE; i++)
            {
                frmTE.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmTE);
                frmTE.Show();
            }
            for (int i = 0; i < slEB; i++)
            {
                frmEB.TopLevel = false;
                flowLayoutPanelTT.Controls.Add(frmEB);
                frmEB.Show();
            }
        }
    }
}
