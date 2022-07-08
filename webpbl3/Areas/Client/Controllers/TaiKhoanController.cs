using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Common;
using DTO;
using BUS;

namespace webpbl3.Areas.Client.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Client/TaiKhoan
        public ActionResult ThongTinCaNhan()
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            var list = new DSTaiKhoanNVBus().DSTaiKhoan();
            DSTaiKhoanNVView Client = new DSTaiKhoanNVView();
            
            if (sess == null)
            {
                return Redirect("/admin/adminPage/LoginPage");
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.ID == sess.UserID)
                    {
                        Client = item;
                        break;
                    }

                }
            }

            return View(Client);
        }

        public ActionResult DoiMatKhau()
        {
            return View();
        }

        public ActionResult ThongTinDatPhong(int ID)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];

            var danhsach = new DSDatPhongBus().DSDatPhong();
            DSDatPhongView data = new DSDatPhongView();
            foreach (var i in danhsach)
            {
                if (i.TenTaiKhoan == sess.UserName && i.ID == ID)
                {
                    data = i;
                    break;
                }
            }

            var obj = new DSDatPhongBus().GetIDDatPhong(ID);

            var listphong1 = new DSPhongBUS().GetDSPhongByIDLoaiPhong(obj.IDLoaiPhong);
            var listphong = new DatPhongHelper().GetAllPhongCoTheDat(obj.IDLoaiPhong, obj);


            if (obj.TrangThai == "1")
            {
                foreach (var i in listphong1)
                {
                    if (Convert.ToInt32(obj.IDPhong) == i.IDPhong)
                    {
                        obj.TenPhong = i.TenPhong;
                    }
                }

            }

            obj.DSPhongTrong = listphong;

            return View(obj);
        }


        public ActionResult DanhSachDatPhong()
        {
            List<DSDatPhongView> data = new List<DSDatPhongView>();
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            var list = new DSDatPhongBus().DSDatPhong();

            foreach(var i in list)
            {
                if(i.TenTaiKhoan == sess.UserName)
                {
                    data.Add(i);
                }
            }

            DSDatPhongView temp = new DSDatPhongView();
            for(int i = 0; i < data.Count -1 ; i++)
            {
                for(int j = i +1; j < data.Count; j++)
                {
                    if(DateTime.Compare(data[i].NgayGui,data[j].NgayGui) < 0)
                    {
                        temp = data[j];
                        data[j] = data[i];
                        data[i] = temp;
                    }
                }
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult UpDate(DSTaiKhoanNVView form)
        {
            var obj = new DSTaiKhoanNVBus();
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            form.ID = sess.UserID;
            form.Quyen = sess.Quyen.ToString();
            obj.UpDateThongTinTK(form);
            return Redirect("/Client");
        }


    }
}