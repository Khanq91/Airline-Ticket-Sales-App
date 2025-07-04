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
        
        // Sửa lỗi trên màn hình có DPI cao khiến winform bị mờ
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        [STAThread]
        static void Main()
        {
            //Kiểm tra phiên bản Windows để chắc rằng nó từ Vista trở về sau
            //Vì bản XP trở về trước không hỗ trợ DPI cao
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangKy());
        }
    }
}
