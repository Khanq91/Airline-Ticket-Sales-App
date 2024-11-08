using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{

    public class TTCHUYENBAY
    {
        DB_Connet db=new DB_Connet();
        string _DiemKhoiHanh;
        string _DiemDen;
        string _NgayKhoiHanh;
        TimeSpan _ThoiGianDi;
        TimeSpan _ThoiGianDen;
        string _MaChuyenBay;
        string _MaMayBay;
        string _LoaiMB;
        public string DiemKhoiHanh { get => _DiemKhoiHanh; set => _DiemKhoiHanh = value; }
        public string DiemDen { get => _DiemDen; set => _DiemDen = value; }
        public string NgayKhoiHanh { get => _NgayKhoiHanh; set => _NgayKhoiHanh = value; }
        public string MaChuyenBay { get => _MaChuyenBay; set => _MaChuyenBay = value; }
        public string MaMayBay { get => _MaMayBay; set => _MaMayBay = value; }
        public string LoaiMB { get => _LoaiMB; set => _LoaiMB = value; }
        public TimeSpan ThoiGianDi { get => _ThoiGianDi; set => _ThoiGianDi = value; }
        public TimeSpan ThoiGianDen { get => _ThoiGianDen; set => _ThoiGianDen = value; }

        public string TenSanBay(string maSanBay)
        {
            string caulenh = "select TenSB from SANBAY where MaSanBay ='"+ maSanBay + "'";
            string kq = (string)db.GetExecuteScalar(caulenh);
            return kq;
        }

        public List<TTCHUYENBAY> GetLSTChuyenBay(string maSanBayDi,string maSanBayDen, string ngayBay)
        {
            List<TTCHUYENBAY> lstCB = new List<TTCHUYENBAY>();

            #region Câu lệnh tìm các sân bay phù hợp
            //string caulenh = "select SANBAYDI.MaSanBay,SANBAYDEN.MaSanBay, NgayBay, GioBay, GioDen, MaTuyenBay " +
            //                "from SANBAY as SANBAYDI, SANBAY as SANBAYDEN, CHANGBAY, TUYENBAY " +
            //                "where TUYENBAY.IDChangBay = CHANGBAY.ID " +
            //                "and CHANGBAY.IDSanBaydi = SANBAYDI.ID " +
            //                "and CHANGBAY.IDSanBayden = SANBAYDEN.ID " +
            //                "and SANBAYDI.MaSanBay = '"+ maSanBayDi + "' " +
            //                "and SANBAYDEN.MaSanBay = '"+ maSanBayDen + "' " +
            //                "and NgayBay = '"+ ngayBay + "'";
            string caulenh = "select SANBAYDI.MaSanBay,SANBAYDEN.MaSanBay, NgayBay, GioBay, GioDen, MaTuyenBay, MaMayBay, LoaiMB " +
                            "from SANBAY as SANBAYDI, SANBAY as SANBAYDEN, CHANGBAY, TUYENBAY, MAYBAY " +
                            "where TUYENBAY.IDChangBay = CHANGBAY.ID " +
                            "and TUYENBAY.IDMayBay = MAYBAY.ID " +
                            "and CHANGBAY.IDSanBaydi = SANBAYDI.ID " +
                            "and CHANGBAY.IDSanBayden = SANBAYDEN.ID " +
                            "and SANBAYDI.MaSanBay ='" + maSanBayDi + "' " +
                            "and SANBAYDEN.MaSanBay ='" + maSanBayDen + "' " +
                            "and NgayBay='" + ngayBay + "' ";
            //caulenh = "select SANBAYDI.MaSanBay,SANBAYDEN.MaSanBay, NgayBay, GioBay, GioDen, MaTuyenBay, MaMayBay, LoaiMB from SANBAY as SANBAYDI, SANBAY as SANBAYDEN, CHANGBAY, TUYENBAY, MAYBAY where TUYENBAY.IDChangBay = CHANGBAY.ID and TUYENBAY.IDMayBay = MAYBAY.ID and CHANGBAY.IDSanBaydi = SANBAYDI.ID and CHANGBAY.IDSanBayden = SANBAYDEN.ID and SANBAYDI.MaSanBay ='SB001' and SANBAYDEN.MaSanBay ='SB002' and NgayBay='2024-11-19'";
            #endregion

            SqlDataReader reader = db.GetExecuteReader(caulenh);
            while (reader.Read()){
                TTCHUYENBAY cb = new TTCHUYENBAY();
                cb.NgayKhoiHanh = Convert.ToDateTime(reader["NgayBay"]).ToString();
                cb.ThoiGianDi = (TimeSpan)reader["GioBay"];
                cb.ThoiGianDen = (TimeSpan)reader["GioDen"];
                cb.MaChuyenBay = reader["MaTuyenBay"].ToString();
                cb.MaMayBay = reader["MaMayBay"].ToString();
                cb.LoaiMB = reader["LoaiMB"].ToString();
                lstCB.Add(cb);
            }
            reader.Close();
            db.CloseSql();
            foreach(var cb in lstCB)
            {
                cb.DiemKhoiHanh = TenSanBay(maSanBayDi);
                cb.DiemDen = TenSanBay(maSanBayDen);
            }
            return lstCB;
        }
    }
}
