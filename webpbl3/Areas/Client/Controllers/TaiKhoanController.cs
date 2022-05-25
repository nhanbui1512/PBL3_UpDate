using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Common;
using DTO;
using BUS;

namespace webpbl3.Areas.Client.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Client/TaiKhoan
        public ActionResult ThongTinCaNhan()
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            var Client = new DSTaiKhoanNVBus().GetTKByTenTk(sess.UserName);
            return View(Client);
        }

        public ActionResult DoiMatKhau()
        {
            return View();
        }

        public ActionResult ThongTinDatPhong()
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            var danhsach = new DSDatPhongBus().DSDatPhong();
            DSDatPhongView data = new DSDatPhongView();
            foreach(var i in danhsach)
            {
                if(i.TenTaiKhoan == sess.UserName)
                {
                    data = i;
                    break;
                }
            }
            return View(data);
        }
    }
}