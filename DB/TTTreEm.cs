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
        public int ThemKH_TreEm(TTTreEm treem)
        {
            string caulenh = "INSERT INTO HANHKHACH(GioiTinhHanhKhach, TenHanhKhach, NgaySinhHanhKhach) VALUES (N'" + treem.Gioitinh + "',N'" + treem.TenKH + "','" + treem.NgaySinh.ToString("yyyy-MM-dd") + "')";
            int kq = db.GetExecuteNonQuery(caulenh);
            return kq;
        }
    }
}
