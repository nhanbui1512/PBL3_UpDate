using System;
using System.Data;
using System.Web.Mvc;
using webpbl3.Common;
using webpbl3.Models;

namespace webpbl3.Areas.admin.Controllers
{
    public class adminPageController : Controller
    {
        // GET: admin/adminPage
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoginPage()
        {
            return View();
        }


    }
}