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
        dbHelper dbHelper = new dbHelper();

        public void DatPhong(FormDatPhong form)
        {
            DateTime dt = DateTime.Now;
            string query = "insert into DatPhong (IDTK,IDLoaiPhong,BatDau,KetThuc,TrangThai,DonGia,SoDT,TinNhan , NgayGui, TenLoaiPhong) values ('"+form.IDTK+"','"+form.IDLoaiPhong+"','"+form.CheckIn.ToString("MM/dd/yyyy")+"' ,'"+ form.CheckOut.ToString("MM/dd/yyyy") + "', '0', '"+form.DonGia+"','"+form.SoDT+"',N'"+form.Message+"','"+dt.ToString()+"','"+form.TenLoaiPhong+"')";
            dbHelper.ExcutedDB(query);
        }

        public void XoaDonDatPhong(int IDDatPhong)
        {   
            dbHelper.ExcutedDB("DELETE FROM DatPhong WHERE IDDatPhong = "+IDDatPhong+"");
        }
    }
}
