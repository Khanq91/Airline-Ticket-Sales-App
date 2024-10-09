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
    public partial class frmQuanLi : Form
    {
        string tennguoidung;
        string role;
        public frmQuanLi(string tennguoidung, string role)
        {
            InitializeComponent();
            this.tennguoidung = tennguoidung;
            this.role = role;
        }
        //startPosition cho thân giao diện (396, 142), Size(1502, 782)
        private void frmQuanLi_Load(object sender, EventArgs e)
        {
            if(role == "Quản lý")//351, 235//351, 463
            {
                lblChaoNguoiDung.Text = "Xin chào quản lý: " + tennguoidung;
            }    
            if (role == "Nhân viên đặt vé")
            {
                lblChaoNguoiDung.Text = "Xin chào nhân viên: " + tennguoidung;
                btnQL_TK.Visible = false;
                btnQL_SanBay.Visible = false;
            }    

            pnlQL_Ve.Visible = true;
        }

        private void btnQL_Ve_Click(object sender, EventArgs e)
        {
            if(pnlQL_Ve.Visible == false)
            {
                pnlQL_Ve.Visible = true;
                btnQL_Ve.BackColor = Color.LimeGreen;

                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
            }  
            else
            {
                btnQL_Ve.BackColor = Color.ForestGreen;
            }
            pnlQL_TK.Visible = false;
            pnlQL_SanBay.Visible = false;
        }

        private void btnQL_TK_Click(object sender, EventArgs e)
        {
            if (pnlQL_TK.Visible == false)
            {
                pnlQL_TK.Visible = true;
                btnQL_TK.BackColor = Color.LimeGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
            }
            else
            {
                btnQL_TK.BackColor = Color.ForestGreen;
            }

            pnlQL_Ve.Visible = false;
            pnlQL_SanBay.Visible = false;
        }

        private void btnQL_SanBay_Click(object sender, EventArgs e)
        {
            if (pnlQL_SanBay.Visible == false)
            {
                pnlQL_SanBay.Visible = true;
                btnQL_SanBay.BackColor = Color.LimeGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_TK.BackColor = Color.ForestGreen;
            }
            else
            {
                btnQL_SanBay.BackColor = Color.ForestGreen;
            }

            pnlQL_Ve.Visible = false;
            pnlQL_TK.Visible = false;
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void picReset_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmm = new frmMain(tennguoidung);
            frmm.FormClosed += (s, args) => this.Close();
            frmm.Show();
        }
    }
}
