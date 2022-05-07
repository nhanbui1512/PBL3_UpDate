using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpbl3.Models
{
    public class FormThongTinDatPhong
    {
        public int ID { get; set; }
        public DateTime NgayGui { get; set; } = DateTime.Now;
        public string HoVaTen { get; set; }
        public string TenTaiKhoan { get; set; }
        public string SDT { get; set; }
        public string TinNhan { get; set; } = string.Empty;
        public string TenPhong { get; set; }
        public int SoLuong { get; set; }
        public DateTime ThoiGianBD { get; set; }
        public DateTime ThoiGianKT { get; set; }
        public string GhiChu { get; set; } = string.Empty;
        public string TrangThai { get; set; }
    }
}