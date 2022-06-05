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
                obj.SDT = i["SoDT"].ToString();
                obj.ThoiGianBD = Convert.ToDateTime(i["BatDau"]);
                obj.ThoiGianKT = Convert.ToDateTime(i["KetThuc"]);
                obj.TrangThai = (i["TrangThai"]).ToString();
                obj.TinNhan = i["TinNhan"].ToString();
                obj.TenLoaiPhong = i["TenLoaiPhong"].ToString() ;
                obj.NgayGui = Convert.ToDateTime(i["NgayGui"]);
                obj.DonGia = Convert.ToDouble(i["DonGia"]);
                obj.IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"]);
                obj.IDPhong = i["IDPhong"].ToString();
                obj.CMND = i["CMT"].ToString();
            
                lst.Add(obj);
            }
            return lst;
        }
        public DSDatPhongView GetIDDatPhong(int ID)
        {
            DSDatPhongView obj = new DSDatPhongView();
            foreach (DataRow i in dao.GetAllDSDatPhong().Rows)
            {
                if(ID == Convert.ToInt32( i["IDDatPhong"]))
                {
                    obj.ID = Convert.ToInt32(i["IDDatPhong"]);
                    obj.HoVaTen = i["HoTen"].ToString();
                    obj.TenTaiKhoan = i["TenTaiKhoan"].ToString();
                    obj.SDT = i["SoDT"].ToString();
                    obj.ThoiGianBD = Convert.ToDateTime(i["BatDau"]);
                    obj.ThoiGianKT = Convert.ToDateTime(i["KetThuc"]);
                    obj.TrangThai = i["TrangThai"].ToString();
                    obj.TinNhan = i["TinNhan"].ToString();
                    obj.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                    obj.NgayGui = Convert.ToDateTime(i["NgayGui"]);
                    obj.DonGia = Convert.ToDouble(i["DonGia"]);
                    obj.IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"]);
                    obj.IDPhong = i["IDPhong"].ToString();
                    obj.CMND = i["CMT"].ToString();
                    break;
                }
            }
            return obj;
        }

        public List<PhongDaDat> GetAllPhongDaDat()
        {
            DataTable data = new DSPhongDaDatDao().GetALLPhong();

            List<PhongDaDat> list = new List<PhongDaDat>();
            foreach(DataRow i in data.Rows)
            {
                list.Add(new PhongDaDat { IDPhong = Convert.ToInt32(i["IDPhong"]),
                    BatDau = Convert.ToDateTime(i["BatDau"]),
                    KetThuc = Convert.ToDateTime(i["KetThu"])
                 
                });
            }
            return list;
        }
    }
}
