using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using BUS;

namespace webpbl3.Areas.admin.Controllers
{
    public class LoaiPhongController : BaseController
    {
        private DBHelper dbHelper = new DBHelper();
        // GET: admin/LoaiPhong
        public ActionResult DanhSachLoaiPhong()
        {
            var list = new DSLoaiPhongBus().GetDSLoaiPhong();

            return View(list);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhong(FormThemLoaiPhong form)
        {

            string query = "INSERT INTO LoaiPhong VALUES (N'"+form.TenLoaiPhong+"',N'"+form.GhiChu+"', '"+form.GiaPhong+"' , '"+form.URLAnhDaiDien+"', '"+form.URLAnhWC+"', '' )";
            dbHelper.ExcutedDB(query);
            return Redirect("/admin/LoaiPhong/DanhSachLoaiPhong");
        }

        public ActionResult Sua(int ID)
        {
            var Phong = new DSLoaiPhongBus().GetIDDSLoaiPhong(ID);
            return View(Phong);
        }

        public ActionResult UpDate(FormThemLoaiPhong form)
        {
            string query = "UPDATE LoaiPhong SET TenLoaiPhong = N'" + form.TenLoaiPhong + "', GhiChu = N'" + form.GhiChu + "', GiaPhong = '" + form.GiaPhong + "', LienKetAnhDaiDien = '" + form.URLAnhDaiDien + "' , LienKetAnhWC = '"+form.URLAnhWC+"' WHERE IDLoaiPhong = " + form.IDLoaiPhong + "";
            dbHelper.ExcutedDB(query);
            return Redirect("/admin/LoaiPhong/DanhSachLoaiPhong");
        }

        public ActionResult Delete(int ID)
        {
            string query = "DELETE FROM LoaiPhong WHERE IDLoaiPhong = "+ID+"";
            dbHelper.ExcutedDB(query);
            return Redirect("/admin/LoaiPhong/DanhSachLoaiPhong");
        }
    }
}