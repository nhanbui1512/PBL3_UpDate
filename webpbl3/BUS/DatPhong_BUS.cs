using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webpbl3.Context;
using webpbl3.Models;

namespace webpbl3.BUS
{
    public class DatPhong_BUS
    {
        public List<TaiKhoan> TaiKhoan { get; set; }
        public List<KhachHang> KhachHang { get; set; }
        public List<DatPhong> DatPhong { get; set; } 
    }
}