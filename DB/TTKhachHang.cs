using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public abstract class TTKhachHang
    {
        string _Gioitinh;
        string _MaKh;
        string _TenKH;
        string _IDTaiKhoan;
        DateTime _NgaySinh;
   
        public string Gioitinh { get => _Gioitinh; set => _Gioitinh = value; }
        public string MaKh { get => _MaKh; set => _MaKh = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public string IDTaiKhoan { get => _IDTaiKhoan; set => _IDTaiKhoan = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public TTKhachHang()
        {
            Gioitinh = "Nam";
            MaKh = "001";
            TenKH = "NguyenVana";
            IDTaiKhoan = "Tk001";
            NgaySinh = DateTime.Parse("12/12/2004");
        }
    }
}
