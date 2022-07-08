using System.Data.SqlClient;
using System.Web.Mvc;
using webpbl3.Models;
using webpbl3.Common;
using System.Data;
using System;
using System.Web.Services.Description;
using BUS;
using Facebook;
using System.Configuration;

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
            DBHelper helper = new DBHelper();
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
            DBHelper helper = new DBHelper();
            
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
            DBHelper helper = new DBHelper();
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
                helper.ExcutedDB("INSERT INTO TaiKhoan VALUES ('" + acc.TenTaiKhoan + "' , '" + acc.MatKhau + "' , '" + acc.Quyen + "')");
                int id = 0;
                foreach (DataRow i in helper.GetAllTK().Rows)
                {
                    if (acc.TenTaiKhoan == i["TenTaiKhoan"].ToString())
                    {
                        id = Convert.ToInt32(i["ID"]);
                    }
                }

                helper.ExcutedDB("INSERT INTO ThongTinTK VALUES ('" + acc.NgaySinh + "' , '" + acc.SoDT + "' , N'" + acc.DiaChi + "', '" + acc.CMND + "' , N'" + acc.HoVaTen + "' , '" + id + "', '' , '" + acc.GioiTinh + "')");

                ViewBag.Ketqua = "Dangkythanhcong";

            }
            else
            {
                ViewBag.Ketqua = "Datontaitaikhoan";

            }


            DatPhongHelper datPhongHelper = new DatPhongHelper();
            datPhongHelper.CheckThoiGianVaoO();


            var ListPhong = new DSLoaiPhongBus().GetDSLoaiPhong();
            var tong = ListPhong.Count;
            ViewBag.tong = tong;
            if (tong % 3 > 0)
            {
                ViewBag.Dem = 3 * (tong / 3) + 1;
            }
            else
            {
                ViewBag.Dem = 3 * (tong / 3);
            }
            return View(ListPhong);

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/");
        }

        private Uri RedirectURi
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;  
            }
        }

        public ActionResult LoginByFaceBook()
        {
            var fb = new FacebookClient();
            
            var loginURL = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["AppSecret"],
                redirect_uri = RedirectURi.AbsolutePath,
                response_type = "code",
                scope = "email",

            });

            return Redirect(loginURL.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["AppSecret"],
                redirect_uri = RedirectURi.AbsolutePath,
                code = code
            });

            var accessToken = result.AccessToken;
            if (!string.IsNullOrEmpty(accessToken))
            {
                dynamic me = fb.Get("me?fields = first_name, middle_name,last_name,id,email");
                string email = me.email;
                string username = me.email;
                string FirstName = me.first_name;
                string MiddleName = me.middle_name;
                string LastName = me.last_name;

                var userSession = new UserLogin();
                userSession.UserName = username;
                userSession.Quyen = 3;
                Session.Add(CommonConstant.USER_SESSION, userSession);


                return Redirect("/admin");
            }
            else
            {
                return Redirect("/admin");
            }

        }
    }
}