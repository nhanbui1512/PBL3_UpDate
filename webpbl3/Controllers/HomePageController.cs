using System.Web.Mvc;
using webpbl3.Context;

namespace webpbl3.Controllers
{
    public class HomePageController : BaseController
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