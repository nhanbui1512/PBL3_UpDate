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
            FormThongTinDatPhong form = new FormThongTinDatPhong();
            form.ID = obj.ID;
            form.NgayGui = obj.NgayGui;
            form.HoVaTen = obj.HoVaTen;
            form.SDT = obj.SDT;
            form.TenPhong = obj.TenPhong;
            form.GhiChu = obj.GhiChu;
            form.TinNhan = obj.TinNhan;
            form.TenTaiKhoan = obj.TenTaiKhoan;
            form.ThoiGianBD = obj.ThoiGianBD;
            form.ThoiGianKT = obj.ThoiGianKT;
            if (obj.TrangThai == 1) form.TrangThai = "1";
            else form.TrangThai = "0";
            return View(form);
        }
    }
}