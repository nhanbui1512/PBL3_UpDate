using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpbl3.Areas.admin.Controllers
{
    public class DoanhThuController : BaseController
    {
        // GET: admin/DoanhThu
        public ActionResult Xem()
        {
            return View("XemDoanhThu");
        }
    }
}