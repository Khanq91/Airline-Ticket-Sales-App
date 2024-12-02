using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DB
{
    public class TTNguoiLon:TTKhachHang
    {
        DB_Connet db = new DB_Connet();
        string _SDT;
        string _Email;
        string _DiaChi;
        string _MaHoiVien;
        string _CCCD;
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string MaHoiVien { get => _MaHoiVien; set => _MaHoiVien = value; }
        public string CCCD { get => _CCCD; set => _CCCD = value; }

        public TTNguoiLon() : base(){
            SDT = "00000222";
            Email = "nguyenvana@gmail.com";
            DiaChi = "TanBinh";
            MaHoiVien = "sss";
            CCCD = "121111";
        }
        public int ThemKH_NguoiLon(TTNguoiLon nl)
        {
            string caulenh = "INSERT INTO HANHKHACH(GioiTinhHanhKhach,TenHanhKhach,NgaySinhHanhKhach,DiaChiHanhKhach,CCCD,SDTHanhKhach,Email) VALUES (N'" + nl.Gioitinh + "',N'" + nl.TenKH + "','" + nl.NgaySinh.ToString("yyyy-MM-dd") + "',N'" + nl.DiaChi + "','" + nl.CCCD + "','" + nl.SDT + "','" + nl.Email + "')";
            int kq = db.GetExecuteNonQuery(caulenh);
            return kq;
        }
    }
}
