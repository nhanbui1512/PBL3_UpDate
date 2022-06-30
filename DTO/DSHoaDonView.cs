using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSHoaDonView
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string CMND { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public int TongTG { get; set; }
        public string TenNV { get; set; }
        public double GiaPhong { get; set; }
        public bool TrangThai { get; set; }
        public string TenLoaiPhong { get; set; }
        public int IDPhong { get; set; }
        public int IDDatPhong { get; set; }
        public string TenPhong { get; set; }
        public double TongTien { get; set; }

    }
}
