using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;

namespace webpbl3.Areas.admin.Controllers
{
    public class LoaiPhongController : BaseController
    {
        private DBHelper dbHelper = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
        // GET: admin/LoaiPhong
        public ActionResult DanhSachLoaiPhong()
        {
            return View();
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhong(FormThemLoaiPhong form)
        {

            string query = "INSERT INTO LoaiPhong VALUES (N'"+form.TenLoaiPhong+"','', '"+form.GiaPhong+"' )";
            dbHelper.ExcutedDB(query);
            return Redirect("/admin/LoaiPhong/DanhSachLoaiPhong");
        }
    }
}