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
        public int ThemTaiKHoan(string tennguoidung,string TK, string Mk)
        {
            string caulenhIDMax = "select MAX(IDTaiKhoan) from QLTaiKhoan";
            string IDMax = (string)(db.GetExecuteScalar(caulenhIDMax) ?? 0);
            string NumberID = IDMax.Substring(2);
            int Number = int.Parse(NumberID) + 1;
            NumberID = "TK" + Number.ToString("D3");
            string caulenhInsert = "INSERT INTO QLTaiKhoan (IDTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTK) VALUES ('" + NumberID + "',N'"+tennguoidung+"','" + TK + "','" + Mk + "',N'HANHKHACH')";
            int kq = db.GetExecuteNonQuery(caulenhInsert);
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
