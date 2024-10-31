using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class TTEmBe:TTKhachHang
    {
        DB_Connet db = new DB_Connet();
        string _NguoiBayCung;

        public string NguoiBayCung { get => _NguoiBayCung; set => _NguoiBayCung = value; }
        public TTEmBe() : base()
        {
            NguoiBayCung = "Nguyen van b";
        }
        public int ThemKH_EmBe(TTEmBe emBe)
        {
            string caulenh = "insert into HANHKHACH(GioiTinhHK,TenHK,NgaySinhHK,TenNguoiDiCung) values(N'" + emBe.Gioitinh + "',N'" + emBe.TenKH + "','" + emBe.NgaySinh.ToString("yyyy-MM-dd") + "',N'" + emBe.NguoiBayCung + "')";
            int kq = db.GetExecuteNonQuery(caulenh);
            return kq;
        }
    }
}
