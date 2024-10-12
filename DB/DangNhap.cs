using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DangNhap
    {
        DB_Connet db = new DB_Connet();
        public (string tennguoidung, string idTaiKhoan) KTraTaiKhoan(string Tk, string MK)
        {
            string tenNguoiDung = null;
            string idTaiKhoan = null;
            string caulenh = "SELECT TenTaiKhoan,IDTaiKhoan FROM QLTaiKhoan WHERE TenDangNhap = '" + Tk + "' AND MatKhau = '" + MK + "'";
            SqlDataReader reader = db.GetExecuteReader(caulenh);
            if (reader.Read()) // Nếu có kết quả
            {
                tenNguoiDung = reader["TenTaiKhoan"].ToString();
                idTaiKhoan = reader["IDTaiKhoan"].ToString(); // Lấy IDTaiKhoan
            }
            return (tenNguoiDung, idTaiKhoan);
        }
    }
}
