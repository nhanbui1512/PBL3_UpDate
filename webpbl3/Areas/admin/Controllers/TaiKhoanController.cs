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
        SQL_HotelEntities1 obj = new SQL_HotelEntities1();
        // GET: admin/TaiKhoan
        public ActionResult Danhsachtaikhoan()
        {
            TaiKhoan_BUS tk = new TaiKhoan_BUS();

            var list1 = new List<TaiKhoan>();
            var list2 = new List<KhachHang>();

            list1 = obj.TaiKhoans.ToList();
            list2 = obj.KhachHangs.ToList();

            tk.listTk = list1;
            tk.listKH = list2;

            return View(tk);
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