using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpbl3.Models
{
    public class FormDK
    {
        public string HoVaTen { get; set; } = string.Empty;
        public string TenTaiKhoan { get; set; }  
        public string MatKhau { get; set; } 
        public string XacNhanMatKhau { get; set; }
        public string CMND { get; set; } = String.Empty;
        public DateTime NgaySinh { get; set; } = DateTime.Now;
        public string DiaChi { get; set; } = "";
        public string SoDT { get; set; } = "";
        public int Quyen { get; set; } = 3;
        public string GioiTinh { get; set; } = "1";


    }
}