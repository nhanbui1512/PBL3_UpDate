using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Context;
using webpbl3.Models;
using webpbl3.BUS;
using BUS;
using DTO;

namespace webpbl3.Areas.admin.Controllers
{
    public class DatPhongController : BaseController
    {


        // GET: admin/DatPhong
        public ActionResult DanhSachDatPhong()
        {   
            var list = new DSDatPhongBus().DSDatPhong();

            return View(list);
        }

        public ActionResult XemDon(int ID)
        {

            var obj = new DSDatPhongBus().GetIDDatPhong(ID);
            

            var listphong = new DSPhongBUS().GetDSPhongByIDLoaiPhong(obj.IDLoaiPhong);


            if (obj.TrangThai == "1")
            {
                foreach(var i in listphong)
                {
                    if(Convert.ToInt32(obj.IDPhong) == i.IDPhong)
                    {
                        obj.TenPhong = i.TenPhong;
                    }
                }

            }

            obj.DSPhongTrong = listphong;

            return View(obj);
        }

        [HttpPost]
        public ActionResult XacNhanDon(FormXacNhanDatPhong form)
        {
            var obj = new DatPhongHelper();
            
            obj.XacNhanDon(form);

            if (form.TrangThai == "2")
            {
                DSDatPhongView bus = new DSDatPhongBus().GetIDDatPhong(form.IDDatPhong);
                var taikhoan = new DSTaiKhoanNVBus().GetTKByTenTk(bus.TenTaiKhoan);
                bus.IDTK = taikhoan.ID;
                obj.XacNhanVaoO(bus);
            }

            return Redirect("/admin/DatPhong/DanhSachDatPhong");

        }

        public  ActionResult Xoa(int ID)
        {
            var obj = new DatPhongHelper();
            obj.XoaDonDatPhong(ID);
            return Redirect("/admin/DatPhong/DanhSachDatPhong");
        }
    }
}