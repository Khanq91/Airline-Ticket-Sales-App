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
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,
                pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18,
                pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,
                pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36
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

        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }
        public void XuLyPic()
        {
            foreach (PictureBox item in pices)
            {
                item.Image = Resources.chair_fix;
            }
        }
        private void GheCuaSo_Click(object sender, EventArgs e)
        {
            XuLyPic();
            PictureBox pic_click = sender as PictureBox;
            pic_click.Image = Resources.chair_click;
            //chưa nha
            lblViTriGhe.Text = "Ghế gần cửa số";//Có 2 loại ghế là "ghế gần cửa sổ" và "ghế bình thường"
            lblGiaViTriGhe.Text = "100.000";
        }
        private void GheBinhThuong_Click(object sender, EventArgs e)
        {
            XuLyPic();
            PictureBox pic_click = sender as PictureBox;
            pic_click.Image = Resources.chair_click;
            //chưa nha
            lblViTriGhe.Text = "Ghế bình thường";//Có 2 loại ghế là "ghế gần cửa sổ" và "ghế bình thường"
            lblGiaViTriGhe.Text = "80.000";
        }
    }
}
