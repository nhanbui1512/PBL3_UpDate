using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSLoaiPhongView
    {
        public int IDLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public string GhiChu { get; set; }
        public double GiaPhong { get; set; }
        public string LienKetAnhDaiDien { get; set; }
        public string LienKetAnhWC { get; set; }

    }
}
