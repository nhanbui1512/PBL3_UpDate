using System.Web.Mvc;
using webpbl3.Context;

namespace webpbl3.Controllers
{
    public class HomePageController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XemPhong()
        {
            return View();
        }

    }
}