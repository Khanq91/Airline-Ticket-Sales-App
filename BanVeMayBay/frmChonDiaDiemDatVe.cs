using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmChonDiaDiemDatVe : Form
    {
        SanBay sb = new SanBay();
        DB_Connet db=new DB_Connet();
       
        public frmChonDiaDiemDatVe()
        {
            InitializeComponent();
            LoadSanBayDi();
            LoadSanBayDen();
        }
        public void LoadSanBayDi()
        { 
            DataTable sanabaydi=new DataTable();
            sanabaydi = db.GetDataAdapter("SanBay");
            cboDiemKhoiHanh.DataSource =sanabaydi ;
            cboDiemKhoiHanh.DisplayMember = "TenSB";
            cboDiemKhoiHanh.ValueMember = "MaSB";
        }
        public void LoadSanBayDen()
        {
            DataTable sanabaydi = new DataTable();
            sanabaydi = db.GetDataAdapter("SanBay");
            cboDiemDen.DataSource = sanabaydi;
            cboDiemDen.DisplayMember = "TenSB";
            cboDiemDen.ValueMember = "MaSB";
        }
        private void frmChonDiaDiemDatVe_Load(object sender, EventArgs e)
        {
            dateTimePickerNgayDi.MinDate = DateTime.Now;
            dateTimePickerNgayVe.MinDate = DateTime.Now;

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
        //Form frmcon = new frmCon_frmChonDiaDiemDatVe();
        frmCon_frmChonDiaDiemDatVe frmcon = new frmCon_frmChonDiaDiemDatVe();
        bool frmCoDangMoHayKhong = false; //Form có đang mở hay không
        public int slNL, slTE, slEB;
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
                frmcon.Location = new Point(1215, 663);
                DialogResult result = frmcon.ShowDialog();
                frmCoDangMoHayKhong = true;
                if(result == DialogResult.OK)
                {
                    string SLHK = "1 Người lớn";
                    slNL = int.Parse(frmcon.SLnl);
                    slTE = int.Parse(frmcon.SLte);
                    slEB = int.Parse(frmcon.SLeb);
                    if(slNL != 1)
                    {
                        SLHK = slNL.ToString() + " Người lớn";
                    }    
                    if(slTE != 0)
                    {
                        SLHK += ", " + slTE.ToString() + " Trẻ em";
                    }
                    if(slEB != 0)
                    {
                        SLHK += ", " + slEB.ToString() + " Em bé";
                    }
                    lblTTHanhKhach.Visible = true;
                    lblTTHanhKhach.Text = SLHK;
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

        private void btnTimChuyenBay_Click(object sender, EventArgs e)
        {
            if(rdoMotChieu.Checked)
            {
                if (
                    cboDiemDen.SelectedItem != null &&
                    cboDiemKhoiHanh.SelectedItem != null &&
                    lblTTHanhKhach.Text != "null"
                    )
                {
                    if(dateTimePickerNgayDi.Value == dateTimePickerNgayDi.MinDate)
                    {
                        lblDiemDen.Text = "Vui lòng chọn ngày đi!";
                        return;
                    }    
                }
                else
                {
                    lblDiemDen.Text = "Vui lòng nhập thông tin trước khi tìm chuyến bay!";
                    return;
                }
            }
            else
            {
                if(dateTimePickerNgayVe.Value == dateTimePickerNgayVe.MinDate)
                {
                    lblDiemDen.Text = "Vui lòng chọn ngày về!";
                    return;
                }
                else
                {
                    lblDiemDen.Text = "Vui lòng nhập thông tin trước khi tìm chuyến bay!";
                    return;
                }
            }
            frmMain frmmain = (frmMain)this.Parent.Parent.Parent;
            string date = dateTimePickerNgayDi.Value.ToString("dd/mm/yyyy");
            frmmain.ShowTTCB(slNL, slTE, slEB, date, cboDiemKhoiHanh.SelectedValue.ToString(), cboDiemDen.SelectedValue.ToString());
            this.Hide();
        }
    }
}
