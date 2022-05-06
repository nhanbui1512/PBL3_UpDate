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

namespace webpbl3.Areas.admin.Controllers
{
    public class DichVuController : BaseController
    {
        DBHelper db = new DBHelper("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");

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
            string query = "INSERT INTO DichVu VALUES (N'" +a.TenDichVu + "' , '" + a.GiaTien + "', '" + a.TrangThai + "'  )";
            db.ExcutedDB(query);
            return Redirect("/admin/DichVu/DanhSachDichVu");
        }


       
        public ActionResult Sua(int ID)
        {
            SQL_HotelEntities1 obj = new SQL_HotelEntities1();
            DichVu dv = new DichVu();
            DichVu_BUS bus = new DichVu_BUS();

            var list = obj.DichVus.ToList();
            foreach (var item in list)
            {
                if (ID == item.IDDV) dv = item;
            }
            bus.IDDV = dv.IDDV;
            bus.TenDV = dv.TenDichVu;
            bus.GiaTien = Convert.ToDouble( dv.GiaTien);
            
            if(dv.TrangThai == true)
            {
                bus.TrangThai = "1";
            }
            else
            {
                bus.TrangThai="0";
            }

            return View(bus);
        }

        [HttpPost]
        public ActionResult UpdateDV (DichVu_BUS dv)  
        {
            //bool trangthai = true;

            //if (dv.TrangThai == "1")
            //{
            //    trangthai = true;
            //}
            //else trangthai = false;

            string query = "UPDATE DichVu SET GiaTien = '"+dv.GiaTien+"', TrangThai = '"+dv.TrangThai+"', TenDichVu = N'"+dv.TenDV+"' WHERE IDDV = "+dv.IDDV+"";
            
            db.ExcutedDB(query);

            return Redirect("/admin/DichVu/DanhSachDichVu");

        }
    }
}