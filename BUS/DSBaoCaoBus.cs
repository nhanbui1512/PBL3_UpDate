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
                obj.ID = Convert.ToInt32(i["IDThongTinHD"]);
                obj.NgayTT = Convert.ToDateTime(i["ThoiGianGD"]);
                obj.HoVaTen = i["HoTen"].ToString();
                obj.TenPhong = i["TenPhong"].ToString();
                obj.TenDV = i["TenDichVu"].ToString();
                obj.TongTien = Convert.ToDouble(i["TongTien"]);
                lst.Add(obj);
            }
            return lst;
        }
    }
}
