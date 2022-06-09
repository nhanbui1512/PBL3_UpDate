using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Common;

namespace webpbl3.Areas.NhanVien.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: admin/HoaDon
        public ActionResult DanhSachHoaDon()
        {
            List<DSHoaDonView> list = new List<DSHoaDonView>();

            var listhoadon = new DSHoaDonBus().DSHoaDon();
            foreach (var item in listhoadon)
            {
                if (item.TrangThai == false)
                {
                    list.Add(item);
                }
            }
            return View(list);
        }

        public ActionResult XemHoaDon(int id)
        {
            var listdichvu = new DSDichVuBus().GetDSDichVu();
            var hoadonphong = new DSHoaDonBus().GetIDDSHoaDon(id);
            var listhoadondv = new DSHoaDonBus().GetAllDSDichVuByIDHoaDon(id);
            double TongTien = 0;

            foreach (var i in listhoadondv)
            {
                TongTien += i.ThanhTien;

            }

            TongTien += (hoadonphong.TongTG * hoadonphong.GiaPhong);
            ViewBag.TongTien = TongTien;

            ViewBag.listhoadon = listhoadondv;

            ViewBag.DSDichVu = listdichvu;
            return View(hoadonphong);
        }

        [HttpPost]
        public ActionResult ThemHoaDonDichVu(FormThemHoaDonDV form)
        {
            DSHoaDonBus helper = new DSHoaDonBus();

            var listhoadondv = new DSHoaDonBus().GetAllDSDichVuByIDHoaDon(form.IDHoaDon);

            var DichVu = new DSDichVuBus().GetIDDSDichVu(Convert.ToInt32(form.IDDV));

            form.TenDV = DichVu.TenDV;
            form.GiaDichVu = DichVu.GiaDV;
            form.ThanhTien = form.GiaDichVu * form.SoLuong;

            int dem = 0;
            foreach (var i in listhoadondv)
            {
                if (i.IDDV == Convert.ToInt32(form.IDDV))
                {
                    break;
                }
                dem++;
            }

            if (listhoadondv.Count == 0)
            {
                helper.ThemHoaDonDV(form);
            }
            else
            {
                if (dem >= listhoadondv.Count)
                {
                    helper.ThemHoaDonDV(form);
                    helper.UpDateHoaDon();

                }
                else
                {
                    helper.ThemHoaDonDVCoSan(form);
                    helper.UpDateHoaDon();
                }
            }



            return Redirect("/NhanVien/HoaDon/XemHoaDon/" + form.IDHoaDon + "/#DichVu");
        }


        public ActionResult ThanhToanHoaDon(int ID)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];

            var hoadonphong = new DSHoaDonBus().GetIDDSHoaDon(ID);
            var listhoadondv = new DSHoaDonBus().GetAllDSDichVuByIDHoaDon(ID);
            double TongTien = 0;
            foreach (var i in listhoadondv)
            {
                TongTien += i.ThanhTien;

            }

            TongTien += (hoadonphong.TongTG * hoadonphong.GiaPhong);


            new DSHoaDonBus().ThanhToanHoaDon(ID,hoadonphong.IDPhong, sess.UserID, TongTien);

            return Redirect("/NhanVien/HoaDon/DanhSachHoaDon");
        }


        public ActionResult XoaHoaDonDV(int IDDV, int IDHoaDon)
        {
            new DSHoaDonBus().XoaHoaDonDV(IDDV, IDHoaDon);
            return Redirect("/NhanVien/HoaDon/XemHoaDon/" + IDHoaDon + "/#DichVu");
        }



    }
}