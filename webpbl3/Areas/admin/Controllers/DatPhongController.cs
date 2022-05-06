using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Context;
using webpbl3.Models;
using webpbl3.BUS;
using BUS;
using DTO;

namespace webpbl3.Areas.admin.Controllers
{
    public class DatPhongController : BaseController
    {


        // GET: admin/DatPhong
        public ActionResult DanhSachDatPhong()
        {   
            var list = new DSDatPhongBus().DSDatPhong();

            return View(list);
        }

        public ActionResult XemDon(int ID)
        {
            var obj = new DSDatPhongBus().GetIDDatPhong(ID);
                return View(obj);
        }
    }
}