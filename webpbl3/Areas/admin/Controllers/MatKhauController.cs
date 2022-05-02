using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Common;
using webpbl3.Models;

namespace webpbl3.Areas.admin.Controllers
{
    public class MatKhauController : BaseController
    {
        // GET: admin/MatKhau
        public ActionResult DoiMatKhau()
        {
            return View("DoiMatKhau");
        }

        [HttpPost]
        public ActionResult UpDate(FormDoiMK form)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            int id = sess.UserID;
            DBHelper db = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
            
             
            foreach(DataRow i in db.GetAllTK().Rows)
            {
                if (id == Convert.ToInt32(i["ID"]))
                {
                    if (i["MatKhau"].ToString() != form.MatKhauCu)
                    {
                        return View();
                        
                    }
                    else
                    {
                        if(form.MatKhauMoi == form.XacNhanMatKhau)
                        {
                            string query = "UPDATE TaiKhoan  SET MatKhau = '"+form.MatKhauMoi+"' WHERE IDTK = "+sess.UserID+" ";
                            db.ExcutedDB(query);
                            return Redirect("/admin");
                        }
                        else
                        {
                            return Redirect("");
                        }
                    }
                    break;
                }
            }
            return View();
        }
    }
}