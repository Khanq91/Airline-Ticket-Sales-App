using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        DB_Connet db = new DB_Connet();
        DataTable dt_sanBayDi = new DataTable();
        DataTable dt_sanBayDen = new DataTable();

        public frmChonDiaDiemDatVe()
        {
            InitializeComponent();
            LoadSanBayDi();
            cboDiemKhoiHanh.SelectedIndex = -1;
            cboDiemDen.SelectedIndex = -1;
        }
        public void LoadSanBayDi()
        {
            dt_sanBayDi = db.GetDataTable("select MaSanBay, DiaDiem from SANBAY");
            cboDiemKhoiHanh.DataSource = dt_sanBayDi;
            cboDiemKhoiHanh.DisplayMember = "DiaDiem";
            cboDiemKhoiHanh.ValueMember = "MaSanBay";
        }
        public void LoadSanBayDen(string DiaDiemDaChon)
        {
            string caulenh = "select MaSanBay, DiaDiem from SANBAY where DiaDiem != N'" + DiaDiemDaChon + "'";
            dt_sanBayDen = db.GetDataTable(caulenh);
            cboDiemDen.DataSource = dt_sanBayDen;
            cboDiemDen.DisplayMember = "DiaDiem";
            cboDiemDen.ValueMember = "MaSanBay";
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

        private void cboDiemDen_DropDown(object sender, EventArgs e)
        {
            if(cboDiemKhoiHanh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn điểm khởi hành trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboDiemKhoiHanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboDiemKhoiHanh.SelectedIndex != -1)
            {
                LoadSanBayDen(cboDiemKhoiHanh.Text);
            }
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
                if (cboDiemDen.SelectedItem != null &&
                    cboDiemKhoiHanh.SelectedItem != null &&
                    lblTTHanhKhach.Text != "null")
                {
                    if(dateTimePickerNgayDi.Value == dateTimePickerNgayDi.MinDate)
                    {
                        //lblDiemDen.Text = "Vui lòng chọn ngày đi!";
                        MessageBox.Show("Vui lòng chọn ngày đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }    
                }
                else
                {
                    //lblDiemDen.Text = "Vui lòng nhập thông tin trước khi tìm chuyến bay!";
                    MessageBox.Show("Vui lòng nhập thông tin trước khi tìm chuyến bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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

            //string date = dateTimePickerNgayDi.Value.ToString("dd/MM/yyyy");

            string date = dateTimePickerNgayDi.Value.ToString("dd/MM/yyyy"); 
            DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
            string sqlFormattedDate = dateTime.ToString("yyyy-MM-dd");

            frmmain.ShowTTCB(slNL, slTE, slEB, sqlFormattedDate, cboDiemKhoiHanh.SelectedValue.ToString(), cboDiemDen.SelectedValue.ToString());
            this.Hide();
        }
    }
}
