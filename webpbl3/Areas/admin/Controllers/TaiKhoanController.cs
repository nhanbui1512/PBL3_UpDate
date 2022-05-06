using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.BUS;
using webpbl3.Context;
using webpbl3.Models;

namespace webpbl3.Areas.admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: admin/TaiKhoan
        public ActionResult Danhsachtaikhoan()
        {
            
            return View();
        }

        public ActionResult XemTaiKhoan()
        {
            return View();
        }

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }


    }
}