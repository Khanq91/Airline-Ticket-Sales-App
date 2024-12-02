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
        public (string tennguoidung, string idTaiKhoan, string loaitk) KTraTaiKhoan(string TaiKhoan, string MatKhau)
        {
            string tenNguoiDung = null;
            string idTaiKhoan = null;
            string loaitk = null;
            string caulenh = "SELECT TenTaiKhoan, ID, LoaiTaiKhoan FROM QLTaiKhoan WHERE TenDangNhap = '" + TaiKhoan + "' AND MatKhau = '" + MatKhau + "'";
            SqlDataReader reader = db.GetExecuteReader(caulenh);
            if (reader.Read()) // Nếu có kết quả
            {
                tenNguoiDung = reader["TenTaiKhoan"].ToString();
                idTaiKhoan = reader["ID"].ToString(); // Lấy IDTaiKhoan
                loaitk = reader["LoaiTaiKhoan"].ToString(); // Lấy Loại tài khoản
            }
            reader.Close();
            return (tenNguoiDung, idTaiKhoan, loaitk);
        }
    }
}
