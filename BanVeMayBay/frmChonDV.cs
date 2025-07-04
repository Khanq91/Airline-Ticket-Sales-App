﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frmChonDV : Form
    {
        public frmChonDV()
        {
            InitializeComponent();
        }
        bool kt = false;
        string _TenViTriGhe;
        string _GiaViTriGhe;
        string _TenGoi;
        string _GiaGoi;
        public string TenViTriGhe { get => _TenViTriGhe; set => _TenViTriGhe = value; }
        public string GiaViTriGhe { get => _GiaViTriGhe; set => _GiaViTriGhe = value; }
        public string TenGoi { get => _TenGoi; set => _TenGoi = value; }
        public string GiaGoi { get => _GiaGoi; set => _GiaGoi = value; }

        #region test truyền dữ liệu qua form main
        public event EventHandler<LabelDataEventArgs> LabelTextChanged;
        public class LabelDataEventArgs : EventArgs
        {
            public string Event_TenViTriGhe { get; set; }
            public string Event_GiaViTriGhe { get; set; }
            public string Event_TenGoi { get; set; }
            public string Event_GiaGoi { get; set; }
        }
        #endregion
        frmViTriGhe frmGhe = new frmViTriGhe();
        private void btnChonGhe_Click(object sender, EventArgs e)
        {
            if(kt)
            {
                frmGhe.Hide();
                kt = false; 
            }    
            else
            {
                if(frmGhe == null || frmGhe.IsDisposed)
                {
                    frmGhe = new frmViTriGhe();
                }
                frmGhe.Location = new Point(730, 190);
                DialogResult result = frmGhe.ShowDialog();
                kt = true;
                if (result == DialogResult.OK)
                {
                    lblMaGhe.Visible = true;
                    lblTienGhe.Visible = true;

                    this.TenViTriGhe = frmGhe.ViTriGhe;
                    this.GiaViTriGhe = frmGhe.GiaGhe;

                    lblMaGhe.Text = TenViTriGhe;
                    lblTienGhe.Text = GiaViTriGhe;
                    #region Test truyền dữ liệu qua form Main
                    LabelTextChanged?.Invoke(this, new LabelDataEventArgs
                    {
                        Event_TenViTriGhe = TenViTriGhe,
                        Event_GiaViTriGhe = GiaViTriGhe
                    });
                    #endregion
                }
                else
                {
                    lblMaGhe.Visible = false;
                    lblTienGhe.Visible = false;

                    TenViTriGhe = "";
                    GiaViTriGhe = "";

                    lblMaGhe.Text = TenViTriGhe;
                    lblTienGhe.Text = GiaViTriGhe;
                    #region Test truyền dữ liệu qua form Main
                    LabelTextChanged?.Invoke(this, new LabelDataEventArgs
                    {
                        Event_TenViTriGhe = TenViTriGhe,
                        Event_GiaViTriGhe = GiaViTriGhe
                    });
                    #endregion
                }
            }    
        }
        frmHanhLy frmHL = new frmHanhLy();

        private void btnGoiHanhLy_Click(object sender, EventArgs e)
        {
            if(kt)
            {
                frmHL.Hide();
                kt = false;
            }    
            else 
            {
                if (frmHL == null || frmHL.IsDisposed)
                {
                    frmHL = new frmHanhLy();
                    //pnlDichVu.Controls.Add(frmHL);
                }
                frmHL.Location = new Point(730, 190);
                DialogResult result = frmHL.ShowDialog();
                kt = true;
                if (result == DialogResult.OK)
                {
                    lblGoiHanhLy.Visible = true;
                    lblTienHL.Visible = true;

                    this.TenGoi = frmHL.TenGoi;
                    this.GiaGoi = frmHL.GiaGoi;

                    lblGoiHanhLy.Text = TenGoi;
                    lblTienHL.Text = GiaGoi;

                    #region Test truyền dữ liệu qua form Main
                    LabelTextChanged?.Invoke(this, new LabelDataEventArgs
                    {
                        Event_TenGoi = TenGoi,
                        Event_GiaGoi = GiaGoi
                    });
                    #endregion
                }
                else
                {
                    lblGoiHanhLy.Visible = false;
                    lblTienHL.Visible = false;
                    TenGoi = "";
                    GiaGoi = "";
                    lblGoiHanhLy.Text = TenGoi;
                    lblTienHL.Text = GiaGoi;

                    #region Test truyền dữ liệu qua form Main
                    LabelTextChanged?.Invoke(this, new LabelDataEventArgs
                    {
                        Event_TenGoi = TenGoi,
                        Event_GiaGoi = GiaGoi
                    });
                    #endregion
                }

            }
        }
    }
}
