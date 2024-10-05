using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class TTKhachHang
    {
        string _MaKh;
        string _TenKH;
        string _DiaChi;
        string _Email;
        string _SDT;
        string _CCCD;
        string _HoChieu;
        DateTime _NgaySinh;
        string _IDTaiKhoan;

        public string MaKh { get => _MaKh; set => _MaKh = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string CCCD { get => _CCCD; set => _CCCD = value; }
        public string HoChieu { get => _HoChieu; set => _HoChieu = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public string IDTaiKhoan { get => _IDTaiKhoan; set => _IDTaiKhoan = value; }
        public TTKhachHang()
        {

        }
    }
}
