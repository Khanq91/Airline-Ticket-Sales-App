using BanVeMayBay.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmViTriGhe : Form
    {
        string _ViTriGhe;
        string _GiaGhe;
        List<PictureBox> pices = new List<PictureBox>();
        public string ViTriGhe { get => _ViTriGhe; set => _ViTriGhe = value; }
        public string GiaGhe { get => _GiaGhe; set => _GiaGhe = value; }

        public frmViTriGhe()
        {
            InitializeComponent();
            pices.AddRange(new[] {
                picA1, picA2, picA3, picA4, picA5, picA6,
                picB1, picB2, picB3, picB4, picB5, picB6,
                picC1, picC2, picC3, picC4, picC5, picC6,
                picD1, picD2, picD3, picD4, picD5, picD6,
                picE1, picE2, picE3, picE4, picE5, picE6,
                picF1, picF2, picF3, picF4, picF5, picF6

            });

        }
        //16, 13, 10, 25, 22, 19, left
        //1, 6, 9, 36, 33, 30 right
        private void picCancel_Click(object sender, EventArgs e)
        {
            btnHuy.PerformClick();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            GiaGhe = "";
            ViTriGhe = "";
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }
        public void XuLyPic(object sender)
        {
            PictureBox pic_click = sender as PictureBox;
            foreach (PictureBox item in pices)
            {
                item.Image = Resources.chair_fix;
            }
            pic_click.Image = Resources.chair_click;
        }
        private string GheCuaSo()
        {
            string vitri = "CS-";//Có 2 loại ghế là "ghế gần cửa sổ" và "ghế bình thường"
            lblGiaViTriGhe.Text = "100.000";
            GiaGhe = "100.000";
            return vitri;
        }
        private string GheBinhThuong()
        {
            string vitri = "BT-";//Có 2 loại ghế là "ghế gần cửa sổ" và "ghế bình thường"
            lblGiaViTriGhe.Text = "80.000";
            GiaGhe = "80.000";
            return vitri;
        }

        #region Hàng ghế A
        private void HangGheA(object sender, EventArgs e)
        {
            string ghe = "";
            XuLyPic(sender);
            PictureBox pic_click = sender as PictureBox;
            if (pic_click == picA1 || pic_click == picA6)
            {
                if (pic_click == picA1)
                    ghe = GheCuaSo() + "A1";
                else
                    ghe = GheCuaSo() + "A6";
            }
            else
            {
                if (pic_click == picA2)
                    ghe = GheBinhThuong() + "A2";
                else if (pic_click == picA3)
                    ghe = GheBinhThuong() + "A3";
                else if (pic_click == picA4)
                    ghe = GheBinhThuong() + "A4";
                else if (pic_click == picA5)
                    ghe = GheBinhThuong() + "A5";
            }
            lblViTriGhe.Text = ghe;
            ViTriGhe = ghe;
            lblGiaViTriGhe.Visible = true;
            lblViTriGhe.Visible = true;
        }
        #endregion
        #region Hàng ghế B
        private void HangGheB(object sender, EventArgs e)
        {
            string ghe = "";
            XuLyPic(sender);
            PictureBox pic_click = sender as PictureBox;
            if (pic_click == picB1 || pic_click == picB6)
            {
                if (pic_click == picB1)
                    ghe = GheCuaSo() + "B1";
                else
                    ghe = GheCuaSo() + "B6";
            }
            else
            {
                if (pic_click == picB2)
                    ghe = GheBinhThuong() + "B2";
                else if (pic_click == picB3)
                    ghe = GheBinhThuong() + "B3";
                else if (pic_click == picB4)
                    ghe = GheBinhThuong() + "B4";
                else if (pic_click == picB5)
                    ghe = GheBinhThuong() + "B5";
            }
            lblViTriGhe.Text = ghe;
            ViTriGhe = ghe;
            lblGiaViTriGhe.Visible = true;
            lblViTriGhe.Visible = true;
        }
        #endregion
        #region Hàng ghế C
        private void HangGheC(object sender, EventArgs e)
        {
            string ghe = "";
            XuLyPic(sender);
            PictureBox pic_click = sender as PictureBox;
            if (pic_click == picC1 || pic_click == picC6)
            {
                if (pic_click == picC1)
                    ghe = GheCuaSo() + "C1";
                else
                    ghe = GheCuaSo() + "C6";
            }
            else
            {
                if (pic_click == picC2)
                    ghe = GheBinhThuong() + "C2";
                else if (pic_click == picC3)
                    ghe = GheBinhThuong() + "C3";
                else if (pic_click == picC4)
                    ghe = GheBinhThuong() + "C4";
                else if (pic_click == picC5)
                    ghe = GheBinhThuong() + "C5";
            }
            lblViTriGhe.Text = ghe;
            ViTriGhe = ghe;
            lblGiaViTriGhe.Visible = true;
            lblViTriGhe.Visible = true;
        }
        #endregion
        #region Hàng ghế D
        private void HangGheD(object sender, EventArgs e)
        {
            string ghe = "";
            XuLyPic(sender);
            PictureBox pic_click = sender as PictureBox;
            if (pic_click == picD1 || pic_click == picD6)
            {
                if (pic_click == picD1)
                    ghe = GheCuaSo() + "D1";
                else
                    ghe = GheCuaSo() + "D6";
            }
            else
            {
                if (pic_click == picD2)
                    ghe = GheBinhThuong() + "D2";
                else if (pic_click == picD3)
                    ghe = GheBinhThuong() + "D3";
                else if (pic_click == picD4)
                    ghe = GheBinhThuong() + "D4";
                else if (pic_click == picD5)
                    ghe = GheBinhThuong() + "D5";
            }
            lblViTriGhe.Text = ghe;
            ViTriGhe = ghe;
            lblGiaViTriGhe.Visible = true;
            lblViTriGhe.Visible = true;
        }
        #endregion
        #region Hàng ghế E
        private void HangGheE(object sender, EventArgs e)
        {
            string ghe = "";
            XuLyPic(sender);
            PictureBox pic_click = sender as PictureBox;
            if (pic_click == picE1 || pic_click == picE6)
            {
                if (pic_click == picE1)
                    ghe = GheCuaSo() + "E1";
                else
                    ghe = GheCuaSo() + "E6";
            }
            else
            {
                if (pic_click == picE2)
                    ghe = GheBinhThuong() + "E2";
                else if (pic_click == picE3)
                    ghe = GheBinhThuong() + "E3";
                else if (pic_click == picE4)
                    ghe = GheBinhThuong() + "E4";
                else if (pic_click == picE5)
                    ghe = GheBinhThuong() + "E5";
            }
            lblViTriGhe.Text = ghe;
            ViTriGhe = ghe;
            lblGiaViTriGhe.Visible = true;
            lblViTriGhe.Visible = true;
        }
        #endregion
        #region Hàng ghế F
        private void HangGheF(object sender, EventArgs e)
        {
            string ghe = "";
            XuLyPic(sender);
            PictureBox pic_click = sender as PictureBox;
            if (pic_click == picF1||pic_click == picF6)
            {
                if(pic_click == picF1)
                    ghe = GheCuaSo() + "F1";
                else
                    ghe = GheCuaSo() + "F6";
            }    
            else
            {
                if (pic_click == picF2)
                    ghe = GheBinhThuong() + "F2";
                else if(pic_click == picF3)
                    ghe = GheBinhThuong() + "F3";
                else if (pic_click == picF4)
                    ghe = GheBinhThuong() + "F4";
                else if (pic_click == picF5)
                    ghe = GheBinhThuong() + "F5";
            }
            lblViTriGhe.Text = ghe;
            ViTriGhe = ghe;
            lblGiaViTriGhe.Visible = true;
            lblViTriGhe.Visible = true;
        }
        #endregion
    }
}
