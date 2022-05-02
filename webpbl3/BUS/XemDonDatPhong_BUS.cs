using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpbl3.BUS
{
    public class XemDonDatPhong_BUS
    {
        public int IDDatPhong { get; set; }
        public string HoVaTen { get; set; }
        public string TenTK { get; set; }
        public string SoDT { get; set; }
        public string TinNhan {get; set; } 
        public string TenPhong { get; set; }
        public int SoLuong { get; set; }
        public string DonGia { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public bool TrangThai { get; set; }



    }
}