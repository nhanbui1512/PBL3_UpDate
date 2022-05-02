using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatPhong
    {
        public int IDDatPhong { get; set; }
        public int IDTaiKhoan { get; set; }
        public int IDPhong { get; set; }
        public DateTime ThoiDiemGui { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public bool TrangThai { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }

    }
}
