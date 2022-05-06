using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Phong
    {
        public System.Int32 IDPhong { get; set; }
        public string TenPhong { get; set; }
        public System.Int32 KhongGian { get; set; }
        public System.Boolean TrangThai { get; set; }
        public LoaiPhong LoaiPhongjoin { get; set; }
        public System.Int32 GiaKM { get; set; }
        public string   TenViTri { get; set; }
    }
}
