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
            return View();
        }
        
        public ActionResult XemPhong()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DatPhong(FormDatPhong form)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            int ID =  sess.UserID;

            var loaiphong = new DSLoaiPhongBus().GetIDDSLoaiPhong(form.IDLoaiPhong);

            form.DonGia = loaiphong.GiaPhong;
            form.IDTK = ID;

            DatPhongHelper datphong = new DatPhongHelper();

            datphong.DatPhong(form);
            
            return Redirect("/Client");
        }
    }
}