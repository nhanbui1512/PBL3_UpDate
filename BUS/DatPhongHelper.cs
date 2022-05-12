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
    }
}
