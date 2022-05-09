using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpbl3.Areas.Client.Model
{
    public class FormDatPhong
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string SoDT { get; set; }
        public string Message { get; set; }
        public int IDLoaiPhong { get; set; }
    }
}