using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webpbl3.Context;

namespace webpbl3.Models
{
    public class KhachHang_DatPhong
    {

        public List<KhachHang> listkh { get; set; }
        public List<DatPhong> listdp { get; set; }
        public List<TaiKhoan> listtk { get; set; }

    }
}