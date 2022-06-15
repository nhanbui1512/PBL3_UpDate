using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using System.Data;
using BUS;
using DTO;

namespace webpbl3.Areas.admin.Controllers
{
    public class KhachHangController : BaseController
    {
        // GET: admin/KhachHang
        public ActionResult DanhSachKhachHang()
        {
           var list = new DSKhachHangBus().DSKhachHang();

            return View(list);
        }

        [HttpPost]
        public ActionResult Search(string Input)
        {
            var data = new DSKhachHangBus().DSKhachHang();
            List<DSKhachHangView> list = new List<DSKhachHangView>();

            foreach(var item in data)
            {
                if(item.HoVaTen.Contains(Input) == true || item.CMND.Contains(Input))
                {
                    list.Add(item);
                }
            }
            return View(list);
        }

        public ActionResult XemThongTin(int ID)
        {
            var data = new DSKhachHangBus().DSKhachHang();
            DSKhachHangView view = new DSKhachHangView();
            foreach(var item in data)
            {
                if(item.ID == ID)
                {
                    view = item;
                    break;
                }
            }

            return View(view);
        }
        public ActionResult XoaTaiKhoan(int ID)
        {
            new TaiKhoanBUS().DeleleTaiKhoan(ID);
            return Redirect("/admin/KhachHang/DanhSachKhachHang");
        }

        public ActionResult ResetMatKhau(int ID)
        {
            var obj = new DSTaiKhoanNVBus();
            obj.ResetMatKhau(ID);
            return Redirect("/admin");
        }
    }
}