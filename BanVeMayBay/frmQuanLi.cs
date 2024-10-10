using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Thư viện cho chức năng xuất file Excel
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml.ConditionalFormatting.Contracts;

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
        //startPosition for panel 707, 65, size 779, 700
        //search 720, 76
        private void frmQuanLi_Load(object sender, EventArgs e)
        {
            //2 role của cấp quản lí:(Quản lý,  Nhân viên đặt vé)

            if (role == "Quản lý")//351, 235//351, 463
            {
                lblRole.Text = "Quản lý";
                lblTenNguoiDung.Text = tennguoidung;
            }    
            if (role == "Nhân viên đặt vé")
            {
                lblRole.Text = "Nhân viên";
                lblTenNguoiDung.Text = tennguoidung;
                btnQL_TK.Visible = false;
                btnQL_SanBay.Visible = false;
            }
            dateTimePickerNgayKhoiHanh.MinDate = DateTime.Now;
            pnlQL_Ve.Visible = true;
                
        }
        #region Sửa lý giao diện
        private void btnQL_Ve_Click(object sender, EventArgs e)
        {
            if(pnlQL_Ve.Visible == false)
            {
                pnlQL_Ve.Visible = true;
                btnQL_Ve.BackColor = Color.WhiteSmoke;
                btnQL_Ve.ForeColor = Color.ForestGreen;

                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_TK.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }  
            else
            {
                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_TK.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            pnlQL_TK.Visible = false;
            pnlQL_SanBay.Visible = false;
            pnlQL_HD.Visible = false;
        }
        private void btnQL_TK_Click(object sender, EventArgs e)
        {
            if (pnlQL_TK.Visible == false)
            {
                pnlQL_TK.Visible = true;
                btnQL_TK.BackColor = Color.WhiteSmoke;
                btnQL_TK.ForeColor = Color.ForestGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }

            pnlQL_Ve.Visible = false;
            pnlQL_SanBay.Visible = false;
            pnlQL_HD.Visible = false;
        }
        private void btnQL_SanBay_Click(object sender, EventArgs e)
        {
            if (pnlQL_SanBay.Visible == false)
            {
                pnlQL_SanBay.Visible = true;
                btnQL_SanBay.BackColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.ForestGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_TK.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_HoaDon.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_TK.ForeColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.WhiteSmoke;
            }

            pnlQL_Ve.Visible = false;
            pnlQL_TK.Visible = false;
            pnlQL_HD.Visible = false;
        }
        private void btnQL_HoaDon_Click(object sender, EventArgs e)
        {
            if(pnlQL_HD.Visible == false)
            {
                pnlQL_HD.Visible = true;
                btnQL_HoaDon.BackColor = Color.WhiteSmoke;
                btnQL_HoaDon.ForeColor = Color.ForestGreen;

                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_TK.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;

            }
            else
            {
                btnQL_Ve.BackColor = Color.ForestGreen;
                btnQL_TK.BackColor = Color.ForestGreen;
                btnQL_SanBay.BackColor = Color.ForestGreen;
                btnQL_Ve.ForeColor = Color.WhiteSmoke;
                btnQL_TK.ForeColor = Color.WhiteSmoke;
                btnQL_SanBay.ForeColor = Color.WhiteSmoke;
            }
            pnlQL_Ve.Visible = false;
            pnlQL_SanBay.Visible = false;
            pnlQL_TK.Visible = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frmQL = new frmQuanLi(tennguoidung, role);
            frmQL.FormClosed += (s, args) => this.Close();
            frmQL.Show();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        private void txtTGDK_Gio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }    
        }
        #region Quản lý vé
        private void btnThem_QLVe_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_QLVe_Click(object sender, EventArgs e)
        {
            //Khi chọn 1 item trong datagridview thì nút này được mở (btnSua_QLVe.Enable = true;)
        }

        private void btnXoa_QLVe_Click(object sender, EventArgs e)
        {
            //Khi chọn 1 item trong datagridview thì nút này được mở (btnXoa_QLVe.Enable = true;)

        }
        #endregion

        #region Quản lý tài khoản
        private void btnThem_QLTK_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_QLTK_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_QLTK_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Quản lí sân bay
        private void btnThem_QLSB_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_QLSB_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_QLSB_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Quản lý hóa đơn
        private void btnXuatExcel_QLHD_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFiledialog = new SaveFileDialog();
            saveFiledialog.Title = "Xuất file Excel";
            saveFiledialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if(saveFiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatExcel(saveFiledialog.FileName);
                    MessageBox.Show("Xuất file thành công!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xuất file thất bại!\nLỗi:" + ex.Message);
                }
            }
        }
        public void XuatExcel(string path)
        {
            Excel.Application ExcApp = new Excel.Application();
            ExcApp.Application.Workbooks.Add(Type.Missing);
            for(int i =0; i < dataGrV_HoaDon.Columns.Count; i++)
            {
                ExcApp.Cells[1, i + 1] = dataGrV_HoaDon.Columns[i].HeaderText;
            }
            for(int i = 0; i < dataGrV_HoaDon.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrV_HoaDon.Columns.Count; j++)
                {
                    ExcApp.Cells[i + 2, j + 1] = dataGrV_HoaDon.Rows[i].Cells[j].Value;
                }
            }
            ExcApp.Columns.AutoFit();
            ExcApp.ActiveWorkbook.SaveCopyAs(path);
            ExcApp.ActiveWorkbook.Saved = true;
        }
        #endregion

    }
}
