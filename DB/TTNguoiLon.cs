using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DB
{
    public class TTNguoiLon:TTKhachHang
    {
        string _QuocGia;
        string _SDT;
        string _Email;
        string _DiaChi;
        string _MaHoiVien;

        public string QuocGia { get => _QuocGia; set => _QuocGia = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string MaHoiVien { get => _MaHoiVien; set => _MaHoiVien = value; }
    public TTNguoiLon() : base(){
            QuocGia = "VietNam";
            SDT = "00000222";
            Email = "nguyenvana@gamil.com";
            DiaChi = "TanBinh";
            MaHoiVien = "sss";
        }
    }
}
