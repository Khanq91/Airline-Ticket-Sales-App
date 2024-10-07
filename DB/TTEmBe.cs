using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class TTEmBe:TTKhachHang
    {
        string _NguoiBayCung;

        public string NguoiBayCung { get => _NguoiBayCung; set => _NguoiBayCung = value; }
        public TTEmBe() : base()
        {
            NguoiBayCung = "Nguyen van b";
        }
    }
}
