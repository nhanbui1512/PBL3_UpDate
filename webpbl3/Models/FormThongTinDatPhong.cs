using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace webpbl3.Models
{
    public class FormThongTinDatPhong
    {
        public int ID { get; set; }
        public int IDLoaiPhong { get; set; }
        public DateTime NgayGui { get; set; }
        public string HoVaTen { get; set; }
        public string TenTaiKhoan { get; set; }
        public string SDT { get; set; }
        public string TinNhan { get; set; } = string.Empty;
        public string TenPhong { get; set; } = string.Empty;
        public DateTime ThoiGianBD { get; set; }
        public DateTime ThoiGianKT { get; set; }
        public string TrangThai { get; set; }
        public string TenLoaiPhong { get; set; } = string.Empty;
        public double DonGia { get; set; } = 0;
        public List<Phong> DSPhongTrong { get; set; }
    }
}