using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Models;
using BUS;
using DTO;

namespace webpbl3.Areas.NhanVien.Controllers
{
    public class LoaiPhongController : BaseController
    {
        private DBHelper dbHelper = new DBHelper();
        // GET: admin/LoaiPhong
        public ActionResult DanhSachLoaiPhong()
        {
            var list = new DSLoaiPhongBus().GetDSLoaiPhong();

            return View(list);
        }

       
        public ActionResult Sua(int ID)
        {
            var Phong = new DSLoaiPhongBus().GetIDDSLoaiPhong(ID);
            return View(Phong);
        }

        [HttpPost]
        public ActionResult Search(FormSearchDichVu form)
        {
            DSLoaiPhongBus data = new DSLoaiPhongBus();
            var Listsorted = data.Sort(data.GetDSLoaiPhong());
            if (form.Input == null)
            {
                form.Input = "";
            }

            List<DSLoaiPhongView> list = new List<DSLoaiPhongView>();

            if (form.ID == "2")
            {
                foreach (var i in Listsorted)
                {
                    if (i.TenLoaiPhong.Contains(form.Input) == true || i.GiaPhong.ToString().Contains(form.Input) == true)
                    {
                        list.Add(i);
                    }
                }
            }

            else
            {
                Listsorted.Reverse();
                foreach (var i in Listsorted)
                {
                    if (i.TenLoaiPhong.Contains(form.Input) == true || i.GiaPhong.ToString().Contains(form.Input) == true) { list.Add(i); }
                }
            }
            return View(list);
        }


    }
}