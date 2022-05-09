using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.BUS;
using webpbl3.Context;
using webpbl3.Models;
using BUS;
using DTO;
namespace webpbl3.Areas.admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        
        // GET: admin/TaiKhoan
        public ActionResult Danhsachtaikhoan()
        {
            List<DSTaiKhoanNVView> list = new List<DSTaiKhoanNVView>();
            list = new DSTaiKhoanNVBus().DSTaiKhoan();
            return View(list);
        }

        public ActionResult XemTaiKhoan(int ID)
        {
            DSTaiKhoanNVView obj = new DSTaiKhoanNVView();
            List<DSTaiKhoanNVView> list = new List<DSTaiKhoanNVView>();
            list = new DSTaiKhoanNVBus().DSTaiKhoan();

            foreach (DSTaiKhoanNVView v in list)
            {
                if (v.ID == ID)
                {
                    obj = v;
                    break;
                }    
               
            }
            return View(obj);
        }

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpDate(DSTaiKhoanNVView form)
        {
            var obj = new DSTaiKhoanNVBus();
            obj.UpDateThongTinTK(form);
            return Redirect("/admin/TaiKhoan/DanhSachTaiKhoan");
        }

        public ActionResult ResetMatKhau (int ID)
        {
            var obj = new DSTaiKhoanNVBus();
            obj.ResetMatKhau(ID);
            return Redirect("/admin");
        }



    }
}