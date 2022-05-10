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
    public class DSDichVuBus
    {
        DSDichVuDao dao = new DSDichVuDao();
        List<DSDichVuView>  list = new List<DSDichVuView> ();
        public List<DSDichVuView> GetDSDichVu()
        {
            foreach(DataRow i in dao.GetAllDichVu().Rows)
            {
                DSDichVuView v = new DSDichVuView ();
                v.IDDV = Convert.ToInt32(i["IDDV"]);
                v.TenDV = i["TenDichVu"].ToString();
                v.GiaDV = Convert.ToDouble(i["GiaTien"]);
                v.TrangThai = (i["TrangThai"]).ToString();
                v.DonVi = i["DonVi"].ToString();
                v.GhiChu = i["GhiChu"].ToString();
                list.Add (v);
            }
            return list;
        }
        public DSDichVuView GetIDDSDichVu(int ID)
        {
            DSDichVuView v = new DSDichVuView();
            foreach (DataRow i in dao.GetAllDichVu().Rows)
            {
                if(ID == Convert.ToInt32(i["IDDV"]))
                {
                    v.IDDV = Convert.ToInt32(i["IDDV"]);
                    v.TenDV = i["TenDichVu"].ToString();
                    v.GiaDV = Convert.ToDouble(i["GiaTien"]);
                    v.TrangThai = (i["TrangThai"]).ToString();
                    v.DonVi = i["DonVi"].ToString();
                    v.GhiChu = i["GhiChu"].ToString();
                    break;
                }
            }
            return v;
        }

        public void UpDateDichVu(FormDichVu dv)
        {
            var obj =  new DSDichVuDao();
            obj.UpDateDichVu(dv);
        }

        public void DeleteDichVu(int ID)
        {
            var obj = new DSDichVuDao();
            obj.DeleteDichVu(ID);
        }

    }
}
