using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSBaoCaoView
    {
        public int IDHoaDon { get; set; }
        public string HoVaTen { get; set; }
        public string SoDT { get; set; }
        public string CMND { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public DateTime ThoiGianGiaoDich { get; set; }
        public double GiaHoaDonPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public string TenPhong { get; set; }
        public double TongThu { get; set; }
        public int IDNhanVien { get; set; }
        public int TongThoiGian { get; set; }


    }
}
