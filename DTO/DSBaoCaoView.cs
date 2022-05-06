using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSBaoCaoView
    {
        public int ID { get; set; }
        public DateTime NgayTT { get; set; }
        public string HoVaTen { get; set; }
        public string TenPhong { get; set; }
        public string TenDV { get; set; }
        public double TongTien { get; set; }

    }
}
