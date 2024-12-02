using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DangKi
    {
        DB_Connet db = new DB_Connet();
        public int ThemTaiKHoan(string tennguoidung, string TK, string Mk)
        {
            string caulenh = "INSERT INTO QLTaiKhoan(TenTaiKhoan, TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES(N'" + tennguoidung + "','" + TK + "','" + Mk + "',N'Khách hàng') ";
            int kq = db.GetExecuteNonQuery(caulenh);
            return kq;
        }
        public bool KTTaiKhoan(string TK)
        {
            string caulenh = "select count(*) from QLTaiKhoan where TenDangNhap='" + TK + "'";
            int kq = (int)db.GetExecuteScalar(caulenh);
            if (kq == 0)
            {
                return true;//tai khoan chua ton tai
            }
            else
            {
                return false;//tai khoan da ton tai
            }
        }
    }
}
