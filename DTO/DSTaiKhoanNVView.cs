using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSTaiKhoanNVView
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public bool? GioiTinh { get; set; }
        public string CMND { get; set; }
        public DateTime NgaySinh { get; set; }
        public int Quyen { get; set; }
        public string SDT { get; set; }
        public string GhiChu { get; set; }
        public string TenTaiKhoan { get; set; }

    }
}
