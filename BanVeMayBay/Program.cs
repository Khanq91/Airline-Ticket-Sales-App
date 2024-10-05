using System;
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
<<<<<<< HEAD
            string tennguoidung = "aa";
            Application.Run(new frmMain(tennguoidung));
=======
            Application.Run(new frmMain("Khang"));
>>>>>>> afd0abc912289219a716a6dfaa7c4a3858af10e6
        }
    }
}
