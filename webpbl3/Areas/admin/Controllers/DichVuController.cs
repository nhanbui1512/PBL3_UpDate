using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.BUS;
using webpbl3.Context;
using webpbl3.Models;
using System.Text;
using BUS;
using DTO;

namespace webpbl3.Areas.admin.Controllers
{
    public class DichVuController : BaseController
    {
        DBHelper db = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
        public DSDichVuBus bus = new DSDichVuBus();

        public ActionResult DanhSachDichVu()
        {
            var list = new DSDichVuBus().GetDSDichVu();

            return View(list);
        }

        public ActionResult ThemDichVu()
        {
            return View("ThemDichVu");
        }

        [HttpPost]

        public ActionResult AddDichVu(FormAddDichVu a)
        {
            string query = "INSERT INTO DichVu VALUES (N'" +a.TenDichVu + "' , '" + a.GiaTien + "', '" + a.TrangThai + "', N'"+a.DonVi+"',''  )";
            db.ExcutedDB(query);
            return Redirect("/admin/DichVu/DanhSachDichVu");
        }


       
        public ActionResult Sua(int ID)
        {
            //SQL_HotelEntities1 obj = new SQL_HotelEntities1();
            //DichVu dv = new DichVu();
            //DichVu_BUS bus = new DichVu_BUS();

            //var list = obj.DichVus.ToList();
            //foreach (var item in list)
            //{
            //    if (ID == item.IDDV) dv = item;
            //}
            //bus.IDDV = dv.IDDV;
            //bus.TenDV = dv.TenDichVu;
            //bus.GiaTien = Convert.ToDouble( dv.GiaTien);
            //bus.DonVi = dv.DonVi;
            //if(dv.TrangThai == true)
            //{
            //    bus.TrangThai = "1";
            //}
            //else
            //{
            //    bus.TrangThai="0";
            //}
            var obj = new DSDichVuBus().GetIDDSDichVu(ID);

            return View(obj);
        }

        [HttpPost]
        public ActionResult UpdateDV (FormDichVu dv)  
        {
            //bool trangthai = true;

            //if (dv.TrangThai == "1")
            //{
            //    trangthai = true;
            //}
            //else trangthai = false;

            //string query = "UPDATE DichVu SET GiaTien = '"+dv.GiaTien+"', TrangThai = '"+dv.TrangThai+"', TenDichVu = N'"+dv.TenDV+"', DonVi = N'"+dv.DonVi+"' WHERE IDDV = "+dv.IDDV+"";

            //db.ExcutedDB(query);
            bus.UpDateDichVu(dv);

            return Redirect("/admin/DichVu/DanhSachDichVu");

        }

        public ActionResult Delete(int ID)
        {
            //string query = "DELETE FROM DichVu WHERE IDDV = "+ID+"";
            //db.ExcutedDB(query);

            
            return Redirect("/admin/DichVu/DanhSachDichVu");
        }

    }
}