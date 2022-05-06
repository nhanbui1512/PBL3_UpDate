using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public System.Int32 IDKhachHang { get; set; }
        public string HoVaTen { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public TaiKhoan TaiKhoanjoin { get; set; }


    }
}
