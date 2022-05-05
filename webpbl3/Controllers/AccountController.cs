﻿using System.Data.SqlClient;
using System.Web.Mvc;
using webpbl3.Models;
using webpbl3.Common;
using System.Data;
using System;
using System.Web.Services.Description;

namespace webpbl3.Controllers
{
    public class AccountController : Controller
    {

    
        // Get account 
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        
        //[HttpPost]
        //public ActionResult Verify(Account acc)
        //{

        //    connectionString();
        //    con.Open();
        //    com.Connection = con;
        //    com.CommandText = "SELECT * FROM [User] WHERE username='" + acc.name + "' and password='" + acc.password + "'";
        //    dr = com.ExecuteReader();


        //    if (dr.Read())
        //    {
        //        con.Close();
        //        //return View("Success");
        //        return Redirect("/admin");
        //    }
        //    else
        //    {
        //        con.Close();
        //        return View("Login");

        //    }


        //}



        [HttpPost]
        public ActionResult CheckLogin(Account acc)
        {
            DBHelper helper = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
            bool ketqua = false;
            foreach (DataRow i in helper.GetAllTK().Rows)
            {
                if (acc.TenTaiKhoan == i["TenTaiKhoan"].ToString() && acc.MatKhau == i["MatKhau"].ToString())
                {

                    ketqua = true;
                    break;
                }


            }

            if (ketqua == true)
            {
                return Redirect("/admin");

            }
            else
            {
                return Redirect("/HomePage");

            }


        }



        [HttpPost]
        public ActionResult CheckDangNhap(Account acc)
        {
            DBHelper helper = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
            
            bool ketqua = false;

            int id = 0;
            string name = "";
            int quyen = 3;
            if (ModelState.IsValid)
            {
                foreach (DataRow i in helper.GetAllTK().Rows)
                {
                    if (acc.TenTaiKhoan == i["TenTaiKhoan"].ToString() && acc.MatKhau == i["MatKhau"].ToString())
                    {

                        ketqua = true;
                        id = Convert.ToInt32(i["ID"].ToString());
                        name = i["TenTaiKhoan"].ToString();
                        quyen =  Convert.ToInt32( i["Quyen"].ToString());
                        break;
                    }


                }

                if (ketqua == true)
                {
                    var userSession = new UserLogin();
                    userSession.UserID = id;
                    userSession.UserName = name;
                    userSession.Quyen = quyen;
                    Session.Add(CommonConstant.USER_SESSION, userSession);

                    if(quyen == 1) { return Redirect("/admin"); }
                    if(quyen == 2) { return Redirect("/NhanVien"); }
                    if(quyen == 3) { return Redirect("/Client"); }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Thành Công ");

                }
            }
                return Redirect("/HomePage");


        }



        [HttpPost]
        public ActionResult CheckSignIn(FormDK acc)
        {
            DBHelper helper = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
            bool ketqua = false;
            foreach (DataRow i in helper.GetAllTK().Rows)
            {
                if (acc.TenTaiKhoan == i["TenTaiKhoan"].ToString()  )
                {
                    ketqua = true;
                    break;
                }


            }
            

            if (ketqua == false && acc.MatKhau.ToString() == acc.XacNhanMatKhau.ToString())
            {
                helper.ExcutedDB("INSERT INTO TaiKhoan VALUES ('"+acc.TenTaiKhoan+"' , '"+acc.MatKhau+"' , '"+acc.Quyen+"')");
                int id = 0;
                foreach(DataRow i in helper.GetAllTK().Rows)
                {
                    if (acc.TenTaiKhoan == i["TenTaiKhoan"].ToString())
                    {
                        id = Convert.ToInt32(i["ID"]);
                    }
                }

                helper.ExcutedDB("INSERT INTO KhachHang VALUES ('" + acc.NgaySinh + "' , '" + acc.SoDT + "' , '" + acc.DiaChi + "', '" + acc.CMND + "' , '" + acc.HoVaTen + "' , '" +id+"')");

                return View("DangKyThanhCong");

            }
            else
            {
                return Redirect("/HomePage");

            }


        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/HomePage");
        }




    }
}