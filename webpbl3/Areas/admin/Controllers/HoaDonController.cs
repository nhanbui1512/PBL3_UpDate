using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpbl3.Areas.admin.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: admin/HoaDon
        public ActionResult DanhSachHoaDon()
        {

            return View();
        }

        public ActionResult XemHoaDon()
        {
            return View ();
        }
    }
}