using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class DSTaiKhoanNVBus
    {
        DSTaiKhoanNVDao dao = new DSTaiKhoanNVDao();
        List<DSTaiKhoanNVView> lst = new List<DSTaiKhoanNVView>();
        public List<DSTaiKhoanNVView> DSTaiKhoan()
        {
            
            foreach (DataRow i in dao.GetAllDS().Rows)
            {
                var obj = new DSTaiKhoanNVView();
                obj.ID = Convert.ToInt32(i["IDTK"]);
                obj.TenTaiKhoan = i["TenTaiKhoan"].ToString();
                obj.HoVaTen = i["HoTen"].ToString();
                obj.Quyen = Convert.ToInt32(i["Quyen"]);
                obj.CMND = i["CMT"].ToString();
                obj.NgaySinh = Convert.ToDateTime(i["NgaySinh"]);
                obj.SDT = i["SDT"].ToString();
                obj.GioiTinh = Convert.ToBoolean(i["GioiTinh"]);
                obj.GhiChu = i["GhiChu"].ToString();
                lst.Add(obj);
            }
            return lst;
        }  
    }
}
