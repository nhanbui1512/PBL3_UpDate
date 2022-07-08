using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using webpbl3.Common;
using BUS;
using DTO;

namespace webpbl3.Areas.NhanVien.Controllers
{
    public class CaNhanController : BaseController
    {
        private DBHelper db = new DBHelper();
        public ActionResult UpDateThongTinCaNhan()
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            DSTaiKhoanNVView view = new DSTaiKhoanNVView();
            var list = new DSTaiKhoanNVBus().DSTaiKhoan();

            if(sess == null)
            {
                return Redirect("/admin/adminPage/LoginPage");
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.ID == sess.UserID)
                    {
                        view = item;
                        break;
                    }

                }
            }
            
            return View(view);
        }
        [HttpPost]
        public ActionResult UpDate(DSTaiKhoanNVView form)
        {
            var obj = new DSTaiKhoanNVBus();
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            form.ID = sess.UserID;
            form.Quyen = sess.Quyen.ToString();
            obj.UpDateThongTinTK(form);
            return Redirect("/NhanVien");
        }
    }
}