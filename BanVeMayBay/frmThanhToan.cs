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
    public partial class frmThanhToan : Form
    {
        string _TamTinh;
        List<Label> labels = new List<Label>();
        public string TamTinh { get => _TamTinh; set => _TamTinh = value; }
        public frmThanhToan(string tamtinh)
        {
            InitializeComponent();
            labels.AddRange(new[] {
                lbl_LineMB, lbl_LineSacombank, lbl_LineAgribank,
                lbl_LineVietcombank, lbl_LineVietinbank, lbl_LineACB,
                lbl_LineBIDV, lbl_LineTechcombank, lbl_LineOCB,
                lbl_LineTienMat
            });

            this.TamTinh = tamtinh;
        }
        #region Xử lý giao diện
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblTamTinh.Text = TamTinh;
        }
        public void ThanhTien()
        {
            #region Vì là không có giảm giá gì cả, nên không tính nhá
            //float tamtinh = float.Parse(TamTinh.Replace(".", ""));
            //float giamgia = float.Parse(lblKhuyenMai.Text.Replace(".", ""));
            //float tongtien = tamtinh - giamgia;
            //lblTongTien.Text = string.Format("{0:n0}", tongtien);
            //lblTongTien.Text = string.Format("{0:n0}", tamtinh);
            #endregion
            lblTongTien.Text = TamTinh;
        }

        private void pnlMB_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineMB);

        }

        private void pnlSacombank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineSacombank);

        }

        private void pnlAgribank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineAgribank);

        }

        private void pnlVietcombank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineVietcombank);

        }

        private void pnlVietinbank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineVietinbank);

        }

        private void pnlACB_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineACB);

        }

        private void pnlBIDV_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineBIDV);

        }

        private void pnlTechcombank_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineTechcombank);

        }

        private void pnlOCB_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineOCB);

        }

        private void pnlTienMat_Click(object sender, EventArgs e)
        {
            XulyLine(lbl_LineTienMat);
        }
        public void XulyLine(object sender)
        {
            Label lbl_click = sender as Label;
            foreach (Label item in labels)
            {
                item.Visible = false;
            }
            lbl_click.Visible = true;
        }
        #endregion
    }
}
