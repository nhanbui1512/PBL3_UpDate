using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using webpbl3.BUS;
using System.Data;

namespace webpbl3.Areas.admin.Controllers
{
    public class KhachHangController : BaseController
    {
        // GET: admin/KhachHang
        public ActionResult DanhSachKhachHang()
        {
           
            return View();
        }
    }
}