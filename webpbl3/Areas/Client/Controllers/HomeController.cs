using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Areas.Client.Model;
using webpbl3.Models;
using BUS;
using webpbl3.Common;
using DTO;

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
            int ID;
            ID = sess.UserID;
            var obj = new DSKhachHangBus().GetIDDSKhachHang(ID);
            var LoaiPhong = new DSLoaiPhongBus().GetIDDSLoaiPhong(form.IDLoaiPhong);

            DBHelper db = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
            string query = "INSERT INTO DatPhong VALUES ('" + ID + "' , '" + form.CheckIn + "', '" + form.CheckOut + "' , '0' , '" + LoaiPhong.GiaPhong + "' , '1' , '', '', '" + form.SoDT + "' , '" + form.IDLoaiPhong + "' )";
            db.ExcutedDB(query);
            
            
            return Redirect("/Client");
        }
    }
}