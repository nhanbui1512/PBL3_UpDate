using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using DTO;


namespace webpbl3.Areas.admin.Controllers
{
    public class DoanhThuController : BaseController
    {

        public ActionResult Xem(int IDHoaDon)
        {

            DSBaoCaoView HoaDonPhong = new DSBaoCaoBus().GetBaoCaoByIDHoaDon(IDHoaDon);
            var listhoadondv = new DSHoaDonBus().GetAllDSDichVuByIDHoaDon(IDHoaDon);
            var NhanVien = new DSTaiKhoanNVBus().GetTKNVByID(HoaDonPhong.IDNhanVien);

            ViewBag.listhoadon = listhoadondv;
            ViewBag.TenNhanVien = NhanVien.HoVaTen;

            return View(HoaDonPhong);
        }

        public ActionResult BaoCaoDoanhThu()
        {
            var list = new DSBaoCaoBus().GetDSBaoCao();
            return View(list);
        }


    }
}