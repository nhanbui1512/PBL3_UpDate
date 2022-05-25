using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;

namespace webpbl3.Areas.admin.Controllers
{
    public class PhongController : BaseController
    {
        
        public ActionResult DanhSachPhong()
        {
            List<DSLoaiPhongView> list = new DSLoaiPhongBus().GetDSLoaiPhong();

            return View(list);
        }

        [HttpPost]
        public ActionResult Search(FormCheckPhong form)
        {
            DSDatPhongView datphong = new DSDatPhongView();
            datphong.IDLoaiPhong = Convert.ToInt32(form.IDLoaiPhong);
            datphong.ThoiGianBD = form.CheckIn;
            datphong.ThoiGianKT = form.CheckOut;
            
            DatPhongHelper datPhongHelper = new DatPhongHelper();

            ViewBag.ListLoaiPhong = new DSLoaiPhongBus().GetDSLoaiPhong();

            return View(datPhongHelper.GetAllPhongCoTheDat(datphong.IDLoaiPhong,datphong));
        }

        public ActionResult ThemPhong()
        {
            
            var ListLoaiPhong = new DSLoaiPhongBus().GetDSLoaiPhong();

            ViewBag.listloaiphong = ListLoaiPhong;
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormThemPhong form)
        {

            var ListLoaiPhong = new DSLoaiPhongBus().GetDSLoaiPhong();

            ViewBag.listloaiphong = ListLoaiPhong;

            PhongHelper phongHelper = new PhongHelper();
            if(phongHelper.ThemPhong(form) == true)
            {
                ViewBag.KetQua = 1;
            }
            else
            {
                ViewBag.KetQua = 0;
            }
            return View();
        }
    }
}