using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpbl3.Models
{
    public class FormAddDichVu
    {   
        public int IDDV { get; set; }
        public string TenDichVu { get; set; }
        public double GiaTien { get; set; }
        public bool TrangThai { get; set; } = true;
        
    }
}