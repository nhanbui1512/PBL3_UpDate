using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDichVu
    {
        public int IDHD { get; set; }
        public int IDDV { get; set; }
        public double GiaDV { get; set; }
        public string TenDV { get; set; }

        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
    }
}
