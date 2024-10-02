using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DB;
namespace DB
{
    public class DangKi
    {
        DBConnet db=new DBConnet();
        public int ThemTaiKHoan(string TK,string Mk)
        {
            string caulenhIDMax = "select MAX(IDTaiKhoan) from QLTaiKhoan";
            string IDMax = (string)(db.GetExecuteScalar(caulenhIDMax) ?? 0);
            string NumberID = IDMax.Substring(2);
            int Number = int.Parse(NumberID)  + 1;
            NumberID = "TK" + Number.ToString("D3");
            string caulenhInsert= "INSERT INTO QLTaiKhoan (IDTaiKhoan, TenTaiKhoan, TenDangNhap, MatKhau, LoaiTK) VALUES ('"+NumberID+"',N'Nguyenvanti','"+TK+"','"+Mk+"',N'HANHKHACH')";
            int kq=db.GetExecuteNonQuery(caulenhInsert);
            return kq;
        }
        public bool KTTaiKhoan(string TK)
        {
            string caulenh = "select count(*) from QLTaiKhoan where TenDangNhap='" + TK + "'";
            int kq = db.GetExecuteNonQuery(caulenh);
            if (kq == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
