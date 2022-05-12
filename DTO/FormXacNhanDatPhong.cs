using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class FormXacNhanDatPhong
    {
        public int IDDatPhong { get; set; }
        public int IDTaiKhoan { get; set; }
        public int IDNhanVien { get; set; }
        public int IDLoaiPhong { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public string TrangThai { get; set; }
        public double DonGia { get; set; }
        public string SDT { get; set; }
        public string TinNhan { get; set; }
        public Phong Phong { get; set; }
    }
}
