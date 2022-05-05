using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}