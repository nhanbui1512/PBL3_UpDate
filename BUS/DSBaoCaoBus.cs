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
    public class DSBaoCaoBus
    {
        List<DSBaoCaoView> lst = new List<DSBaoCaoView>();
        DSBaoCaoDao dao = new DSBaoCaoDao();
        public List<DSBaoCaoView> GetDSBaoCao()
        {
            foreach (DataRow i in dao.GetAllBaoCao().Rows)
            {
                var obj = new DSBaoCaoView();
                obj.IDHoaDon = Convert.ToInt32(i["IDHoaDonThanhToan"]);
                obj.HoVaTen = i["HoVaTen"].ToString();
                obj.SoDT = i["SoDT"].ToString();
                obj.CMND = i["CMND"].ToString();
                obj.BatDau = Convert.ToDateTime(i["BatDau"]);
                obj.KetThuc = Convert.ToDateTime(i["KetThuc"]);
                obj.ThoiGianGiaoDich = Convert.ToDateTime(i["ThoiGianGiaoDich"]);
                obj.GiaHoaDonPhong = Convert.ToDouble(i["GiaPhong"]);
                obj.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                obj.TenPhong = i["TenPhong"].ToString();
                obj.TongThu = Convert.ToDouble(i["TongTien"]);
                obj.TenNhanVien = i["NhanVienThanhToan"].ToString();
                lst.Add(obj);
            }
            return lst;
        }

        public DSBaoCaoView GetBaoCaoByIDHoaDon(int IDHoaDon)
        {
            DSBaoCaoView obj = new DSBaoCaoView();
            foreach(var i in GetDSBaoCao())
            {
                if(i.IDHoaDon == IDHoaDon)
                {
                    obj = i;
                    break;
                }
            }
            TimeSpan Temp = obj.KetThuc - obj.BatDau;
            obj.TongThoiGian = Temp.Days;
            return obj;
        }
    }
}
