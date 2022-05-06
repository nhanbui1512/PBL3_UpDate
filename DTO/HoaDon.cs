using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public System.Int32 IDHoaDon { get; set; }
        public System.Int32 SoLuong { get; set; }
        public System.DateTime ThoiGianGD { get; set; }
        public System.Int64 TongTien { get; set; }
        public System.Int64 GiaPhong { get; set; }
        public System.Int64 GiaDV { get; set; }
        public System.Boolean TrangThai { get; set; }
        public ThongTinHoaDon DonDatPhongjoin { get; set; }
    }
}
