using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace DB
{
    public class DangNhap
    {
        DBConnet db=new DBConnet();
        public string KTraTaiKhoan(string Tk,string MK)
        {
            string tennguodung = null;
            string caulenh = "SELECT TenHienThi FROM QLTaiKhoan WHERE TenTaiKhoan = '"+Tk+"' AND MatKhau = '"+MK+"'";
            string kq= (string)db.GetExecuteScalar(caulenh);
            if (kq != null)
            {
               tennguodung = kq;
            }
            return tennguodung;
        }
    }
}
