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
        DBHelper db = new DBHelper();
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
             
            var obj = new DSDichVuBus().GetIDDSDichVu(ID);
            return View(obj);
        }

        [HttpPost]
        public ActionResult UpdateDV (FormDichVu dv)  
        {
            
            bus.UpDateDichVu(dv);

            return Redirect("/admin/DichVu/DanhSachDichVu");

        }

        public ActionResult Delete(int ID)
        {
            //string query = "DELETE FROM DichVu WHERE IDDV = " + ID + "";
            //db.ExcutedDB(query);

            bus.DeleteDichVu(ID);
            return Redirect("/admin/DichVu/DanhSachDichVu");
        }

        public ActionResult Search(string Input)
        {
            var list = new DSDichVuBus().GetDSDichVu();

            List<DSDichVuView> ListSearch = new List<DSDichVuView>();

            foreach(DSDichVuView i in list)
            {
                if (i.TenDV.Contains(Input) == true)
                {
                    ListSearch.Add(i);
                }
                    
            }

            return View(ListSearch);
        }

    }
}