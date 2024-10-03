using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DangNhap
    {
        DB_Connet db = new DB_Connet();
        public string KTraTaiKhoan(string Tk, string MK)
        {
            string tennguodung = null;
            string caulenh = "SELECT TenTaiKhoan FROM QLTaiKhoan WHERE TenDangNhap = '" + Tk + "' AND MatKhau = '" + MK + "'";
            string kq = (string)db.GetExecuteScalar(caulenh);
            if (kq != null)
            {
                tennguodung = kq;
            }
            return tennguodung;
        }
    }
}
