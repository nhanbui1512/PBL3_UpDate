using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.BUS;
using webpbl3.Context;
using webpbl3.Models;
using System.Text;
using BUS;
using DTO;

namespace webpbl3.Areas.NhanVien.Controllers
{
    public class DichVuController : BaseController
    {
        DBHelper db = new DBHelper();
        public DSDichVuBus bus = new DSDichVuBus();

        public ActionResult DanhSachDichVu()
        {
            var list = new DSDichVuBus().GetDSDichVu();

            return View(list);
        }
    
        public ActionResult Sua(int ID)
        {
            var obj = new DSDichVuBus().GetIDDSDichVu(ID);
            return View(obj);
        }


    }
}