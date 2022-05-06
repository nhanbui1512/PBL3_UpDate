using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using webpbl3.BUS;
using webpbl3.Common;

namespace webpbl3.Areas.admin.Controllers
{
    public class CaNhanController : BaseController
    {
        private DBHelper db = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
        // GET: admin/CaNhan
        public ActionResult UpDateThongTinCaNhan()
        {
            ThongTinCaNhan tt = new ThongTinCaNhan();
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];


            return View();
        }
    }
}