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
    public class DSKhachHangBus
    {
        DSKhachHangDao dao = new DSKhachHangDao();
        List<DSKhachHangView> lst = new List<DSKhachHangView>();
        public List<DSKhachHangView> DSKhachHang()
        {
            foreach(DataRow i in dao.GetAllKH().Rows)
            {
                var obj = new DSKhachHangView();
                obj.ID = Convert.ToInt32(i["IDTaiKhoan"]);
                obj.HoVaTen = i["HoTen"].ToString();
                obj.NgaySinh = Convert.ToDateTime(i["NgaySinh"]);
                obj.CMND = i["CMT"].ToString();
                obj.SDT = i["SDT"].ToString();
                obj.DiaChi = i["DiaChi"].ToString();
                obj.GioiTinh = i["GioiTinh"].ToString();
                obj.TenTaiKhoan = i["TenTaiKhoan"].ToString();
                lst.Add(obj);
            }
            return lst;
        }
        public DSKhachHangView GetIDDSKhachHang(int ID)
        {
            DSKhachHangView obj = new DSKhachHangView();
            foreach (DataRow i in dao.GetAllKH().Rows)
            {
                if (ID == Convert.ToInt32(i["IDTaiKhoan"]))
                {
                    obj.HoVaTen = i["HoTen"].ToString();
                    obj.NgaySinh = Convert.ToDateTime(i["NgaySinh"]);
                    obj.CMND = i["CMT"].ToString();
                    obj.SDT = i["SDT"].ToString();
                    obj.DiaChi = i["DiaChi"].ToString();
                    break;
                }
            }
            return obj;
        }
    }
}
