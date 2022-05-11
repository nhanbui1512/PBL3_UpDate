using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DatPhongHelper
    {
        public void DatPhong(FormDatPhong form)
        {
            dbHelper dbHelper = new dbHelper();
            DateTime dt = DateTime.Now;
            string query = "insert into DatPhong (IDTK,IDLoaiPhong,BatDau,KetThuc,TrangThai,DonGia,SoDT,TinNhan , NgayGui) values ('"+form.IDTK+"','"+form.IDLoaiPhong+"','"+form.CheckIn.ToString("MM/dd/yyyy")+"' ,'"+ form.CheckOut.ToString("MM/dd/yyyy") + "', '0', '"+form.DonGia+"','"+form.SoDT+"','"+form.Message+"','"+dt.ToString()+"')";
            dbHelper.ExcutedDB(query);
        }
    }
}
