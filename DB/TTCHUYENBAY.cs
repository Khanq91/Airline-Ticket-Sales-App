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
        string _DIemKhoiHanh;
        string _DiemDen;
        string _NgayKhoiHanh;
        TimeSpan _ThoiGianDi;
        TimeSpan _ThoiGianDen;
        string _MaChuyenBay;
        string _MaMayBay;
        public string DIemKhoiHanh { get => _DIemKhoiHanh; set => _DIemKhoiHanh = value; }
        public string DiemDen { get => _DiemDen; set => _DiemDen = value; }
        public string NgayKhoiHanh { get => _NgayKhoiHanh; set => _NgayKhoiHanh = value; }
        public string MaChuyenBay { get => _MaChuyenBay; set => _MaChuyenBay = value; }
        public string MaMayBay { get => _MaMayBay; set => _MaMayBay = value; }
        public TimeSpan ThoiGianDi { get => _ThoiGianDi; set => _ThoiGianDi = value; }
        public TimeSpan ThoiGianDen { get => _ThoiGianDen; set => _ThoiGianDen = value; }

        public string TenSanBay(string masanbay)
        {
            string caulenh = "select TenSB from SANBAY where MaSB='"+masanbay+"'";
            string kq = (string)db.GetExecuteScalar(caulenh);
            return kq;
        }

        public List<TTCHUYENBAY> GetLSTChuyenBay(string masbdi,string masbden,string ngaybay)
        {
            //SqlConnection con;
            //String conn = "Data Source=DESKTOP-MMVLGPG\\SQL2012;Initial Catalog=QL_VeMayBay;Integrated Security=True";
            //con = new SqlConnection(conn);
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //db.OpenSql();
            List<TTCHUYENBAY> lstCB = new List<TTCHUYENBAY>();
            //string caulenh = "select MaSBden,MaSBdi,NgayBay,GioBay,GioDen,MaCB from CHUYENBAY ,CHANGBAY where CHUYENBAY.STTcb=CHANGBAY.STTchangbay and MaSBdi='"+masbdi+"' and MaSBden='"+masbden+"' and NgayBay='"+ngaybay+"'";
            string caulenh = "select MaSBden,MaSBdi,NgayBay,GioBay,GioDen,MaCB from CHUYENBAY ,CHANGBAY where CHUYENBAY.STTcb=CHANGBAY.STTchangbay and MaSBdi='SB001' and MaSBden='SB005' and NgayBay='2024-10-14'";

            //SqlCommand cmd = new SqlCommand(caulenh, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlDataReader reader = db.GetExecuteReader(caulenh);
            while (reader.Read()){
                TTCHUYENBAY cb= new TTCHUYENBAY();
                //cb.DIemKhoiHanh = TenSanBay(masbdi);
                //cb.DiemDen = TenSanBay(masbden);
                cb.NgayKhoiHanh = Convert.ToDateTime(reader["NgayBay"]).ToString();
                cb.ThoiGianDi = (TimeSpan)reader["GioBay"];
                cb.ThoiGianDen = (TimeSpan)reader["GioDen"];
                cb.MaChuyenBay = reader["MaCB"].ToString();
                lstCB.Add(cb);
            }
            reader.Close();
            db.CloseSql();
            foreach(var cb in lstCB)
            {
                cb.DIemKhoiHanh = TenSanBay(masbdi);
                cb.DiemDen = TenSanBay(masbden);
            }
            return lstCB;
        }
    }
}
