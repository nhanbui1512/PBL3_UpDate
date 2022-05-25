using BUS;
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
            var list = new DSHoaDonBus().DSHoaDon();
            return View(list);
        }

        public ActionResult XemHoaDon(int id)
        {
            var list = new DSHoaDonBus().GetIDDSHoaDon(id);
            var listhoadon = new DSHoaDonBus().GetAllDSDichVuByIDHoaDon(id);
            ViewBag.listhoadon = listhoadon;
            return View (list);
        }
    }
}