using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatPhong
    {
        public System.Int32 IDDatPhong { get; set; }
        public TaiKhoan TaiKhoanjoin { get; set; }
        public System.DateTime ThoiDiemGui { get; set; }
        public System.DateTime BatDau { get; set; }
        public System.DateTime KetThuc { get; set; }
        public System.Boolean TrangThai { get; set; }
        public System.Int64? DonGia { get; set; }
        public System.Int32 SoLuong { get; set; }
        public System.Int32 IDNhanVien { get; set; }
        public string TenNhanVien { get; set; }
    }
}
