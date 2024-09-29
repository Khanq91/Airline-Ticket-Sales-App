using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmChonDiaDiemDatVe : Form
    {
        public frmChonDiaDiemDatVe()
        {
            InitializeComponent();
        }

        private void frmChonDiaDiemDatVe_Load(object sender, EventArgs e)
        {
            dateTimePickerNgayDi.MinDate = DateTime.Now;
            dateTimePickerNgayVe.MinDate = DateTime.Now;
            int dayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dateTimePickerNgayDi.MaxDate = new DateTime(2030, 12, dayofmonth);
            dateTimePickerNgayVe.MaxDate = new DateTime(2030, 12, dayofmonth);

            dateTimePickerNgayVe.Visible = false;
            lblNgayVe.Visible = false;
        }

        private void dateTimePickerNgayDi_CloseUp(object sender, EventArgs e)
        {
            dateTimePickerNgayVe.MinDate = dateTimePickerNgayDi.Value;
        }
        Form frmcon = new frmCon_frmChonDiaDiemDatVe();
        bool frmCoDangMoHayKhong = false; //Form có đang mở hay không
        private void picHanhKhachDropDown_Click(object sender, EventArgs e)
        {
            if(frmCoDangMoHayKhong)
            {
                frmcon.Hide();
                frmCoDangMoHayKhong = false;
            }
            else
            {
                if(frmcon == null || frmcon.IsDisposed)
                {
                    frmcon = new frmCon_frmChonDiaDiemDatVe();
                    frmcon.StartPosition = FormStartPosition.Manual;
                }
                frmcon.Location = new Point(1229, 651);
                DialogResult result = frmcon.ShowDialog();
                frmCoDangMoHayKhong = true;
                if(result == DialogResult.OK)
                {
                    string SLHK = string.Empty;
                    frmCon_frmChonDiaDiemDatVe frmc = new frmCon_frmChonDiaDiemDatVe();
                    int slNL = int.Parse(frmc.SLnl);
                    int slTE = int.Parse(frmc.SLte);
                    int slEB = int.Parse(frmc.SLeb);
                    //kt so luong nguoi de xuat hien tren form

                }    
                
            }
        }

        private void picDoiViTri_Click(object sender, EventArgs e)
        {
            var diemdi = cboDiemKhoiHanh.SelectedItem;
            var diemden = cboDiemDen.SelectedItem;

            cboDiemKhoiHanh.SelectedItem = diemden;
            cboDiemDen.SelectedItem = diemdi;
                
        }

        private void cboDiemKhoiHanh_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void rdoKhuHoi_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoKhuHoi.Checked)
            {
                dateTimePickerNgayVe.Visible = true; 
                lblNgayVe.Visible = true;
            }
            else
            {
                dateTimePickerNgayVe.Visible = false;
                lblNgayVe.Visible = false;
            }
        }
    }
}
