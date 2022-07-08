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
using webpbl3.Common;

namespace webpbl3.Areas.admin.Controllers
{
    public class DatPhongController : BaseController
    {


        // GET: admin/DatPhong
        public ActionResult DanhSachDatPhong()
        {
            new DatPhongHelper().CheckThoiGianVaoO();

            var list = new DSDatPhongBus().DSDatPhong();

            List<DSDatPhongView> data = new List<DSDatPhongView>();

            foreach(var i in list)
            {
                if(i.TrangThai == "0" || i.TrangThai == "1")
                {
                    data.Add(i);
                }
            }

            DSDatPhongView temp = new DSDatPhongView();

            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (DateTime.Compare(data[i].NgayGui, data[j].NgayGui) < 0)
                    {
                        temp = data[j];
                        data[j] = data[i];
                        data[i] = temp;
                    }
                }
            }

            return View(data);
        }

        public ActionResult XemDon(int ID)
        {

            var obj = new DSDatPhongBus().GetIDDatPhong(ID);

            var listphong1 = new DSPhongBUS().GetDSPhongByIDLoaiPhong(obj.IDLoaiPhong);
            var listphong = new DatPhongHelper().GetAllPhongCoTheDat(obj.IDLoaiPhong, obj);

            if (obj.TrangThai == "1")
            {
                foreach(var i in listphong1)
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
            
            if(form.TrangThai == "1")
            {
                var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
                form.IDNhanVien = sess.UserID;
                obj.XacNhanDon(form);
            }

            if (form.TrangThai == "2")
            {
                DSDatPhongView dondatphong = new DSDatPhongBus().GetIDDatPhong(form.IDDatPhong);

                var taikhoan = new DSTaiKhoanNVBus().GetTKByTenTk(dondatphong.TenTaiKhoan);
                dondatphong.IDTK = taikhoan.ID;
                var sess = (UserLogin)Session[CommonConstant.USER_SESSION];

                obj.XacNhanVaoO(dondatphong , sess.UserID);
            }

            if(form.TrangThai == "0")
            {
                obj.ThayDoiTrangThai(form.IDDatPhong);
            }

            return Redirect("/admin/DatPhong/DanhSachDatPhong");

        }

        public  ActionResult Xoa(int ID)
        {
            var obj = new DatPhongHelper();
            obj.XoaDonDatPhong(ID);
            return Redirect("/admin/DatPhong/DanhSachDatPhong");
        }

        public ActionResult Search(string Input)
        {
            DSDatPhongBus bus = new DSDatPhongBus();
            List<DSDatPhongView> list = new List<DSDatPhongView>();
            
            foreach(var i in bus.DSDatPhong())
            {
                if( (i.TenTaiKhoan.Contains(Input) || i.HoVaTen.Contains(Input) ) && i.TrangThai != "2")
                {
                    list.Add(i);
                }

            }

            DSDatPhongView temp = new DSDatPhongView();

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (DateTime.Compare(list[i].NgayGui, list[j].NgayGui) < 0)
                    {
                        temp = list[j];
                        list[j] = list[i];
                        list[i] = temp;
                    }
                }
            }

            return View(list);
        }
    }
}