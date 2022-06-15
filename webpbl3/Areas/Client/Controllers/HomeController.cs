using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using webpbl3.Common;
using BUS;
using DTO;
//using DTO;

namespace webpbl3.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Client/Home
        public ActionResult HomePage()
        {
            var ListPhong = new DSLoaiPhongBus().GetDSLoaiPhong();
            var tong = ListPhong.Count;
            ViewBag.tong = tong;
            if (tong % 3 > 0)
            {
                ViewBag.Dem = 3 * (tong / 3) + 1;
            }
            else
            {
                ViewBag.Dem = 3 * (tong / 3);
            }
            return View(ListPhong);
        }
        
        public ActionResult XemPhong(int ID)
        {
            var obj = new DSLoaiPhongBus().GetIDDSLoaiPhong(ID);

            return View(obj);
        }

        [HttpPost]
        public ActionResult DatPhong(FormDatPhong form)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            int ID =  sess.UserID;

            var loaiphong = new DSLoaiPhongBus().GetIDDSLoaiPhong(form.IDLoaiPhong);

            
            form.DonGia = loaiphong.GiaPhong;
            form.IDTK = ID;
            form.TenLoaiPhong = loaiphong.TenLoaiPhong;

            DatPhongHelper datphong = new DatPhongHelper();

            datphong.DatPhong(form);
            
            return Redirect("/Client/TaiKhoan/DanhSachDatPhong");
        }
    }
}