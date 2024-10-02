using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DB
{
    public class DBConnet
    {
        SqlConnection con;
        public DBConnet()
        {
            String conn = "Data Source=DESKTOP-MMVLGPG\\SQL2012;Initial Catalog=QL_VeMayBay;Integrated Security=True";
            con = new SqlConnection(conn);
        }
        public void OpenSql()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void CloseSql()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public int GetExecuteNonQuery(string caulenh)
        {
            OpenSql();
            SqlCommand cmd = new SqlCommand(caulenh, con);
            int kq = (int)cmd.ExecuteNonQuery();
            CloseSql();
            return kq;
        }
        public object GetExecuteScalar(string caulenh)
        {
            OpenSql();
            SqlCommand cmd = new SqlCommand(caulenh, con);
            object kq = cmd.ExecuteScalar();
            CloseSql();
            return kq;
        }

    }
}
