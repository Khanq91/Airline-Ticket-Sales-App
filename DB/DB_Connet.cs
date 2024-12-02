using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DB_Connet
    {
        SqlConnection con;
        public DB_Connet()
        {
            //String conn = "Data Source=DESKTOP-MMVLGPG\\SQL2012;Initial Catalog=QL_VeMayBay;Integrated Security=True";
            String conn = "Data Source=LAPTOP-GHCIUOL8\\MSSQLSERVER01;Initial Catalog=QL_VeMayBay_dotNet;Integrated Security=True;Encrypt=False";
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
        public SqlDataReader GetExecuteReader(string caulenh)
        {
            OpenSql();
            SqlCommand cmd = new SqlCommand(caulenh, con);
            return cmd.ExecuteReader(); // Trả về SqlDataReader
        }
        public List<string> GetExecuteReader(string caulenh, string col)
        {
            List<string> result = new List<string>();
            OpenSql();
            SqlCommand cmd = new SqlCommand(caulenh, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                result.Add(rd[col].ToString());
            }
            CloseSql();
            return result;
        }

        public DataTable GetDataAdapter(string TenBang)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql_Dt = new SqlDataAdapter("select * from " + TenBang, con);
            sql_Dt.Fill(dt);
            return dt;
        }
        public DataTable GetDataTable(string caulenh)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql_Dt = new SqlDataAdapter(caulenh, con);
            sql_Dt.Fill(dt);
            return dt;
        }
    }
}
