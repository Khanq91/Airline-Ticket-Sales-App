﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        #region 
        // Sửa lỗi trên màn hình có DPI cao khiến winform bị mờ
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        [STAThread]
        #endregion

        static void Main()
        {
            #region 
            //Kiểm tra phiên bản Windows để chắc rằng nó từ Vista trở về sau
            //Vì bản XP trở về trước không hỗ trợ DPI cao
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #endregion

            Application.Run(new frmDangNhap());
            //Application.Run(new frmMain("Khang"));
            //Application.Run(new frmThanhToan("10000"));
            //Application.Run(new frmQR_ThanhToan("Test", "1000"));
            //Application.Run(new frmQuanLi("Khang", "Quản lý"));

        }
    }
}
