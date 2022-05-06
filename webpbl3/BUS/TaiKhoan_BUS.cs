using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webpbl3.Context;
using webpbl3.Models;

namespace webpbl3.BUS
{
    public class TaiKhoan_BUS
    {
        public List<TaiKhoan> listTk { get; set; }
        public List<ThongTinCaNhan> listKH { get; set; }
    }
}