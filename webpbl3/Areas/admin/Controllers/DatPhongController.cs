using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpbl3.Context;
using webpbl3.Models;
using webpbl3.BUS;

namespace webpbl3.Areas.admin.Controllers
{
    public class DatPhongController : BaseController
    {

        SQL_HotelEntities1 obj = new SQL_HotelEntities1();

        // GET: admin/DatPhong
        public ActionResult DanhSachDatPhong()
        {   
            DatPhong_BUS datPhong_BUS = new DatPhong_BUS();
            
            var list1 = new List<DatPhong>();
            var list2 = new List<TaiKhoan>();
            var list3 = new List<KhachHang>();
            
            list1 = obj.DatPhongs.ToList();
            list2 = obj.TaiKhoans.ToList();
            list3 = obj.KhachHangs.ToList();

            datPhong_BUS.DatPhong = list1;
            datPhong_BUS.TaiKhoan = list2;
            datPhong_BUS.KhachHang = list3;


            return View(datPhong_BUS);
        }

        public ActionResult XemDon(int ID )
        {   
            XemDonDatPhong_BUS form = new XemDonDatPhong_BUS();

            var list1 = new List<DatPhong>();
            var list2 = new List<TaiKhoan>();
            var list3 = new List<KhachHang>();
            var list4 = new List<Phong>();

            list1 = obj.DatPhongs.ToList();
            list2 = obj.TaiKhoans.ToList();
            list3 = obj.KhachHangs.ToList();
            list4 = obj.Phongs.ToList();

            foreach(var item in list1)
            {
                if(ID == item.IDDatPhong)
                {
                    form.IDDatPhong = item.IDDatPhong;
                    form.BatDau = Convert.ToDateTime( item.BatDau);
                    form.KetThuc = Convert.ToDateTime( item.KetThuc);
                    form.SoLuong = Convert.ToInt32( item.SoLuong);
                    form.TrangThai = Convert.ToBoolean( item.TrangThai) ;
                    form.SoLuong = Convert.ToInt32( item.SoLuong);
                    form.DonGia = Convert.ToString( item.DonGia );

                    foreach(var j in list4)
                    {
                        if(j.IDPhong == item.IDPhong)
                        {
                            form.TenPhong = j.TenPhong;
                            break;
                            
                        }
                    }
                    foreach(var j in list2)
                    {
                        if(j.IDTK == item.IDTK)
                        {
                            form.TenTK = j.TenTaiKhoan;
                            break;

                        }
                    }

                    foreach(var j in list3)
                    {
                        if(j.IDTaiKhoan == item.IDTK)
                        {
                            form.SoDT = j.SDT;
                            form.HoVaTen = j.HoTen;
                        }
                    }

                }
                break;

            }


            return View(form);
        }
    }
}