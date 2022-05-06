using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BUS
{
    public class DSDatPhongBus
    {
        List<DSDatPhongView> lst = new List<DSDatPhongView>();
        DSDatPhongDao dao = new DSDatPhongDao();
        public List<DSDatPhongView> DSDatPhong()
        {
            foreach(DataRow i in dao.GetAllDSDatPhong().Rows)
            {
                DSDatPhongView obj = new DSDatPhongView();
                obj.ID = Convert.ToInt32(i["IDDatPhong"]);
                obj.HoVaTen = i["HoTen"].ToString();
                obj.TenTaiKhoan = i["TenTaiKhoan"].ToString();
                obj.SDT = i["SDT"].ToString();
                obj.TenPhong = i["TenPhong"].ToString();
                obj.SoLuong = Convert.ToInt32(i["SoLuong"]);
                obj.ThoiGianBD = Convert.ToDateTime(i["BatDau"]);
                obj.ThoiGianKT = Convert.ToDateTime(i["KetThuc"]);
                obj.TrangThai = Convert.ToInt32(i["TrangThai"]);
                lst.Add(obj);
            }
            return lst;
        }
        public DSDatPhongView GetIDDatPhong(int ID)
        {
            DSDatPhongView obj1 = new DSDatPhongView();
            foreach (DataRow i in dao.GetAllDSDatPhong().Rows)
            {
                if(ID == Convert.ToInt32( i["IDDatPhong"]))
                {
                    obj1.ID = Convert.ToInt32(i["IDDatPhong"]);
                    obj1.HoVaTen = i["HoTen"].ToString();
                    obj1.TenTaiKhoan = i["TenTaiKhoan"].ToString();
                    obj1.SDT = i["SDT"].ToString();
                    obj1.TenPhong = i["TenPhong"].ToString();
                    obj1.SoLuong = Convert.ToInt32(i["SoLuong"]);
                    obj1.ThoiGianBD = Convert.ToDateTime(i["BatDau"]);
                    obj1.ThoiGianKT = Convert.ToDateTime(i["KetThuc"]);
                    obj1.TrangThai = Convert.ToInt32(i["TrangThai"]);
                    break;
                }
            }
            return obj1;
        }
    }
}
