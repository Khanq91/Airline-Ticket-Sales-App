using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class TTTreEm:TTKhachHang
    {
        DB_Connet db = new DB_Connet();
        public TTTreEm() : base()
        {

        }
        public int ThemTaiKHoan(TTTreEm treem, string idtaikhoan)
        {
            string caulenh = "insert into HANHKHACH(GioiTinhHK,TenHK,NgaySinhHK,IDTaiKhoan) values(N'" + treem.Gioitinh + "',N'" + treem.TenKH + "','" + treem.NgaySinh.ToString("dd/MM/yyyy") + "','" + idtaikhoan + "')";
            int kq = db.GetExecuteNonQuery(caulenh);
            return kq;
        }
    }
}
