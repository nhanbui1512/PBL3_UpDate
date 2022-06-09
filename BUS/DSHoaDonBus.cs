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
                obj.ID = Convert.ToInt32(i["IDHoaDon"]);
                obj.HoVaTen = i["HoTen"].ToString();
                obj.SDT = i["SDT"].ToString();
                obj.CMND = i["CMND"].ToString();
                obj.BatDau = Convert.ToDateTime(i["BatDau"]);
                obj.KetThuc = Convert.ToDateTime(i["KetThuc"]);
                obj.TenNV = i["HoTen"].ToString();
                obj.GiaPhong = Convert.ToDouble(i["GiaHDPhong"]);
                obj.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                obj.TenPhong = i["TenPhong"].ToString();
                obj.TrangThai = Convert.ToBoolean(i["TrangThai"]);
                obj.TongTien = Convert.ToDouble(i["TongTien"]);
                obj.IDPhong = Convert.ToInt32(i["IDPhong"]);
                TimeSpan Temp = Convert.ToDateTime(i["KetThuc"]) - Convert.ToDateTime(i["BatDau"]);
                obj.TongTG = Temp.Days;
                list.Add(obj);
            }
            return list;
        }
        public DSHoaDonView GetIDDSHoaDon(int id)
        {
            DSHoaDonView obj = new DSHoaDonView();
            foreach (DataRow i in dao.GetAllDSHoaDon().Rows)
            {
                if (id == Convert.ToInt32(i["IDHoaDon"]))
                {
                    obj.ID = Convert.ToInt32(i["IDHoaDon"]);
                    obj.HoVaTen = i["HoTen"].ToString();
                    obj.SDT = i["SDT"].ToString();
                    obj.CMND = i["CMND"].ToString();
                    obj.BatDau = Convert.ToDateTime(i["BatDau"]);
                    obj.KetThuc = Convert.ToDateTime(i["KetThuc"]);
                    //obj.TenNV = i["HoTen"].ToString();
                    obj.GiaPhong = Convert.ToDouble(i["GiaHDPhong"]);
                    obj.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                    obj.TrangThai = Convert.ToBoolean(i["TrangThai"]);
                    obj.IDPhong = Convert.ToInt32(i["IDPhong"]);
                    obj.TenPhong = i["TenPhong"].ToString();
                    obj.TongTien = Convert.ToDouble(i["TongTien"]);
                    TimeSpan Temp = Convert.ToDateTime(i["KetThuc"]) - Convert.ToDateTime(i["BatDau"]);
                    obj.TongTG = Temp.Days;
                    break;
                }
            }
            return obj;
        }

        public List<HoaDonDichVu> GetAllDSDichVuByIDHoaDon(int ID)
        {
            DSHoaDonDao dao = new DSHoaDonDao();
            List<HoaDonDichVu> data = new List<HoaDonDichVu>();

            foreach(DataRow i in dao.GetAllDSDichVuByIDHoaDon(ID).Rows)
            {
                data.Add(new HoaDonDichVu
                {
                    IDDV = Convert.ToInt32(i["IDDV"]),
                    IDHD = Convert.ToInt32(i["IDHoaDon"]),
                    TenDV = i["TenDichVu"].ToString(),
                    GiaDV = Convert.ToDouble(i["GiaDichVu"]),
                    SoLuong = Convert.ToInt32(i["SoLuong"]),
                    ThanhTien = Convert.ToDouble(i["ThanhTien"])

                });
                
            }
            return data;
        }

        public void ThemHoaDonDV(FormThemHoaDonDV form)
        {
            DSHoaDonDao dao = new DSHoaDonDao();
            dao.ThemHoaDonDV(form);
        }

        public void ThemHoaDonDVCoSan(FormThemHoaDonDV form)
        {
            DSHoaDonDao dao = new DSHoaDonDao();
            dao.ThemHoaDonDVCoSan(form);
        }

        public void UpDateHoaDon()
        {
            DSHoaDonDao dao = new DSHoaDonDao();
            dao.UpDateHoaDon();
        }

        public void ThanhToanHoaDon(int IDHoaDon,int IDPhong , int UserID, double TongTien)
        {
            DSHoaDonDao dao = new DSHoaDonDao();

            dao.ThanhToanHoaDon(IDHoaDon,IDPhong , UserID, TongTien);
        }

        public void XoaHoaDonDV(int IDDV, int IDHoaDon)
        {
            DSHoaDonDao dao = new DSHoaDonDao();
            dao.XoaHoaDonDV(IDDV, IDHoaDon);
        }
    }
}
