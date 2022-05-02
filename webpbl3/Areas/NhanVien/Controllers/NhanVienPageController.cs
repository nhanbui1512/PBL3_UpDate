using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpbl3.Areas.NhanVien.Controllers
{
    public class NhanVienPageController : BaseController
    {
        // GET: NhanVien/NhanVienPage
        public ActionResult Index()
        {
            return View();
        }
    }
}