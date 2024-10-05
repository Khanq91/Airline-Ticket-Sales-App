using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class SanBay
    {
        DB_Connet db = new DB_Connet();
        public SanBay()
        {

        }
        public List<string> GetSanBay()
        {
            List<string> result = new List<string>();
            string caulenh = "select * from SANBAY";
            result = db.GetExecuteReader(caulenh, "TenSB");
            return result;
        }
    }
}
