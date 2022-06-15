using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using BUS;
using DTO;

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

        [HttpPost]
        public ActionResult UpDate(FormThemLoaiPhong form)
        {
            string query = "UPDATE LoaiPhong SET TenLoaiPhong = N'" + form.TenLoaiPhong + "', GhiChu = N'" + form.GhiChu + "', GiaPhong = '" + form.GiaPhong + "', LienKetAnhDaiDien = '" + form.URLAnhDaiDien + "' , LienKetAnhWC = '"+form.URLAnhWC+"' WHERE IDLoaiPhong = " + form.IDLoaiPhong + "";
            dbHelper.ExcutedDB(query);
            return Redirect("/admin/LoaiPhong/DanhSachLoaiPhong");
        }

        public ActionResult Delete(int ID)
        {
            new DSLoaiPhongBus().DeleteLoaiPhong(ID);
            return Redirect("/admin/LoaiPhong/DanhSachLoaiPhong");
        }

        [HttpPost]
        public ActionResult Search(FormSearchDichVu form)
        {
            DSLoaiPhongBus data = new DSLoaiPhongBus();
            var Listsorted = data.Sort(data.GetDSLoaiPhong());
            if(form.Input == null)
            {
                form.Input = "";
            }
            
            List<DSLoaiPhongView> list = new List<DSLoaiPhongView>();

            if (form.ID == "2")
            {
                foreach (var i in Listsorted)
                {
                    if (i.TenLoaiPhong.Contains(form.Input) == true || i.GiaPhong.ToString().Contains(form.Input) == true )
                    {
                        list.Add(i);
                    }
                }
            }

            else 
            {
                Listsorted.Reverse();
                foreach (var i in Listsorted)
                {
                    if(i.TenLoaiPhong.Contains(form.Input) == true || i.GiaPhong.ToString().Contains(form.Input) == true ) { list.Add(i); }
                }
            }
            return View(list);
        }


    }
}