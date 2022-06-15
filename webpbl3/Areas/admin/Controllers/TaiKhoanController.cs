using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.BUS;
using webpbl3.Context;
using webpbl3.Models;
using webpbl3.Controllers;
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

        [HttpPost]
        public ActionResult Search(string Input)
        {
            var data = new DSTaiKhoanNVBus().DSTaiKhoan();
            List<DSTaiKhoanNVView> list = new List<DSTaiKhoanNVView>();

            foreach(var i in data)
            {
                if(i.HoVaTen.Contains(Input) == true || i.TenTaiKhoan.Contains(Input) == true ||i.SDT.Contains(Input) == true)
                {
                    list.Add(i);
                }
            }
            return View(list);
        }


        [HttpPost]

        public ActionResult ThemTaiKhoan(FormDK form)
        {
            form.Quyen = 2;
            AccountController accountController = new AccountController();
            accountController.CheckSignIn(form);
            return Redirect("/admin/TaiKhoan/DanhSachTaiKhoan");
        }

        public ActionResult XoaTaiKhoan(int ID)
        {
            new TaiKhoanBUS().DeleleTaiKhoan(ID);
            return Redirect("/admin/TaiKhoan/DanhSachTaiKhoan");
        }



    }
}