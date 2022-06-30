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
            var listhoadondv = new DSHoaDonBus().GetAllDSDichVuByIDHoaDonThanhToan(IDHoaDon);

            ViewBag.listhoadon = listhoadondv;

            return View(HoaDonPhong);
        }

        public ActionResult BaoCaoDoanhThu()
        {
            var list = new DSBaoCaoBus().GetDSBaoCao();

            for(int i = 0; i < list.Count - 1 ; i++)
            {
                for(int j = i + 1; j < list.Count  ; j++)
                {
                    int sosanh = DateTime.Compare(list[i].ThoiGianGiaoDich, list[j].ThoiGianGiaoDich);
                    if(sosanh < 0)
                    {
                        DSBaoCaoView temp = new DSBaoCaoView();
                        temp = list[j];
                        list[j] = list[i];
                        list[i] = temp;
                    }
                }
            }
            
            return View(list);
        }

        public ActionResult Search(DateTime InputTime)
        {
            var list = new DSBaoCaoBus().GetDSBaoCao();
            List<DSBaoCaoView> result = new List<DSBaoCaoView>();
            

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    int sosanh = DateTime.Compare(list[i].ThoiGianGiaoDich, list[j].ThoiGianGiaoDich);
                    if (sosanh < 0)
                    {
                        DSBaoCaoView temp = new DSBaoCaoView();
                        temp = list[j];
                        list[j] = list[i];
                        list[i] = temp;
                    }
                }
            }

            foreach (var i in list)
            {
                if (i.ThoiGianGiaoDich.Day == InputTime.Day && i.ThoiGianGiaoDich.Month == InputTime.Month && i.ThoiGianGiaoDich.Year == InputTime.Year)
                {
                    result.Add(i);
                }
            }
            return View(result);
        }


    }
}