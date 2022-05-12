using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FormDatPhong
    {
        public int IDTK { get; set; }
        public double DonGia { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string SoDT { get; set; }
        public string Message { get; set; }
        public int IDLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }

    }
}
