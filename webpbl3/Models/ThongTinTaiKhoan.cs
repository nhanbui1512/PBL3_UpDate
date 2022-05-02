using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpbl3.Models
{
    public class ThongTinTaiKhoan
    {
        public string HoTen { get; set; } = "";
        public int Quyen { get; set; } = 0;
        public DateTime NgaySinh { get; set; } = DateTime.Now;
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string CMND { get; set; } = "";
        public int IDTK { get; set; } = 0;

    }
}