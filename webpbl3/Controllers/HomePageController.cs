using System.Web.Mvc;
using webpbl3.Context;
using BUS;

namespace webpbl3.Controllers
{
    public class HomePageController : BaseController
    {

        public ActionResult Index()
        {
            var ListPhong = new DSLoaiPhongBus().GetDSLoaiPhong();
            var tong = ListPhong.Count;
            ViewBag.tong = tong;
            if(tong%3 > 0)
            {
                ViewBag.Dem = 3*(tong / 3) + 1;
            }
            else {
                ViewBag.Dem = 3 * (tong / 3);
             }
            return View(ListPhong);
        }

        public ActionResult XemPhong(int ID)
        {
            var obj = new DSLoaiPhongBus().GetIDDSLoaiPhong(ID);

            return View(obj);
        }


    }
}