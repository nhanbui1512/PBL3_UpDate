using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BUS;
using webpbl3.Common;
using webpbl3.Models;
using System.Data;

namespace webpbl3.Areas.Client.Controllers
{
    public class MatKhauController : BaseController
    {
        [HttpPost]
        public ActionResult ThayDoi(FormDoiMK form)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            int id = sess.UserID;
            DBHelper db = new DBHelper();
            TaiKhoanBUS TkBus = new TaiKhoanBUS();

            bool ketqua = false;


            foreach (DataRow i in db.GetAllTK().Rows)
            {
                if (id == Convert.ToInt32(i["ID"]))
                {
                    if (form.MatKhauCu == i["MatKhau"].ToString() && form.MatKhauCu != form.MatKhauMoi && form.MatKhauMoi == form.XacNhanMatKhau)
                    {
                        ketqua = true;
                    }
                    break;
                }
            }
            if (ketqua == true)
            {
                TkBus.UpDateMatKhau(form.MatKhauMoi, id);
                ViewBag.ketqua = "1";

            }
            else
            {
                ViewBag.ketqua = "0";
            }

            return View();
        }
    }
}