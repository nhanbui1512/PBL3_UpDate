using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DatPhongHelper
    {
        public void DatPhong(FormDatPhong form)
        {
            var datphongdao = new DAL.DatPhongHelper();
            datphongdao.DatPhong(form);
        }

        public void XoaDonDatPhong(int ID)
        {
            var datphongdao = new DAL.DatPhongHelper();
            datphongdao.XoaDonDatPhong(ID);
        }

        public bool ChekDatPhong(DSDatPhongView a, DSDatPhongView b)
        {
            

            int sosanh1 = DateTime.Compare(a.ThoiGianBD, b.ThoiGianKT);
            int sosanh2 = DateTime.Compare(a.ThoiGianKT, b.ThoiGianBD);
            
            if (sosanh2 > 0 || sosanh1 < 0)
            {
                return false;
            }
            
            return true;
        }

        public List<Phong> ListPhongKhaDung()
        {
            List<Phong> phonglist = new List<Phong>();

            return phonglist;
        }

       
    }
}
