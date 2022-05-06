using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DSHoaDonBus
    {
        DSHoaDonDao dao = new DSHoaDonDao();
        List<DSHoaDonView> list = new List<DSHoaDonView>();
        public List<DSHoaDonView> DSHoaDon()
        {
            foreach(DataRow i in dao.GetAllDSHoaDon().Rows)
            {
                var obj = new DSHoaDonView();
                obj.ID = Convert.ToInt32(i["IDThongTinHD"]);
                obj.HoVaTen = i["HoTen"].ToString();
                obj.SDT = i["SDT"].ToString();
                obj.CMND = i["CMT"].ToString();
                obj.BatDau = Convert.ToDateTime(i["BatDau"]);
                obj.KetThuc = Convert.ToDateTime(i["KetThuc"]);
                obj.TenNV = i["TenNhanVien"].ToString();
                obj.GiaPhong = Convert.ToDouble(i["GiaPhong"]);
                obj.GiaDV = Convert.ToDouble(i["GiaDichVu"]);
                obj.TenDV = i["TenDichVu"].ToString();
                obj.TenPhong = i["TenPhong"].ToString();
                obj.TrangThai = Convert.ToBoolean(i["TrangThai"]);
                obj.TongTien = Convert.ToDouble(i["TongTien"]);
                obj.TongTG = 2;
                list.Add(obj);
            }
            return list;
        }
        public DSHoaDonView GetIDDSHoaDon(int id)
        {
            DSHoaDonView obj = new DSHoaDonView();
            foreach (DataRow i in dao.GetAllDSHoaDon().Rows)
            {
                if (id == Convert.ToInt32(i["IDThongTinHD"]))
                {
                    obj.HoVaTen = i["HoTen"].ToString();
                    obj.SDT = i["SDT"].ToString();
                    obj.CMND = i["CMT"].ToString();
                    obj.BatDau = Convert.ToDateTime(i["BatDau"]);
                    obj.KetThuc = Convert.ToDateTime(i["KetThuc"]);
                    obj.TenNV = i["TenNhanVien"].ToString();
                    obj.GiaPhong = Convert.ToDouble(i["GiaPhong"]);
                    obj.TenDV = i["TenDichVu"].ToString();
                    obj.GiaDV = Convert.ToDouble(i["GiaDichVu"]);
                    obj.TrangThai = Convert.ToBoolean(i["TrangThai"]);
                    obj.TenPhong = i["TenPhong"].ToString();
                    obj.TongTien = Convert.ToDouble(i["TongTien"]);
                    obj.TongTG = 2;
                    break;
                }
            }
            return obj;
        }
    }
}
