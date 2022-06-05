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
                obj.Quyen = (i["Quyen"]).ToString();
                obj.CMND = i["CMT"].ToString();
                obj.NgaySinh = Convert.ToDateTime(i["NgaySinh"]);
                obj.SDT = i["SDT"].ToString();
                obj.GioiTinh = (i["GioiTinh"]).ToString();
                obj.GhiChu = i["GhiChu"].ToString();
                lst.Add(obj);
            }
            return lst;
        } 

        public DSTaiKhoanNVView GetTKNVByID(int IDTK)
        {
            DSTaiKhoanNVView dSTaiKhoanNVView = new DSTaiKhoanNVView();

            foreach(var i in DSTaiKhoan())
            {
                if(IDTK == i.ID)
                {
                    dSTaiKhoanNVView = i;
                    break;
                }
            }

            return dSTaiKhoanNVView;
        }
        
        public void UpDateThongTinTK( DSTaiKhoanNVView form)
        {
            dao.UpDateThongTinTK(form);
        }
       
        public void ResetMatKhau(int ID)
        {
            dao.ResetMatKhau(ID);
        }

        public DSKhachHangView GetTKByTenTk(string TenTK)
        {
            DSKhachHangBus tk = new DSKhachHangBus();
            DSKhachHangView dSKhachHangView = new DSKhachHangView();
            foreach(var i in tk.DSKhachHang())
            {
                if(i.TenTaiKhoan == TenTK)
                {
                    dSKhachHangView = i;
                }
            }
            return dSKhachHangView;
        }

    }
}
