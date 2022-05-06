using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinHoaDon
    {
        public System.Int32 IDThongTinHoaDon { get; set; }
        public Phong Phongjoin { get; set; }
        public DichVu DichVujoin { get; set; }
        public HoaDon HoaDonjoin { get; set; }
    }
}
