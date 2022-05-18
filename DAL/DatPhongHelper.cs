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
            string query = "insert into DatPhong (IDTK,IDLoaiPhong,BatDau,KetThuc,TrangThai,DonGia,SoDT,TinNhan , NgayGui) values ('"+form.IDTK+"','"+form.IDLoaiPhong+"','"+form.CheckIn.ToString("MM/dd/yyyy")+"' ,'"+ form.CheckOut.ToString("MM/dd/yyyy") + "', '0', '"+form.DonGia+"','"+form.SoDT+"',N'"+form.Message+"','"+dt.ToString()+"')";
            dbHelper.ExcutedDB(query);
        }

        public void XoaDonDatPhong(int IDDatPhong)
        {   
            dbHelper.ExcutedDB("DELETE FROM DatPhong WHERE IDDatPhong = "+IDDatPhong+"");
        }

        public void XacNhanDon(FormXacNhanDatPhong form)
        {
            string query = "UPDATE DatPhong SET TrangThai = '"+form.TrangThai+"', IDPhong = '"+form.IDPhong+"' WHERE IDDatPhong = "+form.IDDatPhong+"";
            dbHelper.ExcutedDB(query);
        }
        public void XacNhanVaoO(DSDatPhongView form)
        {
            string query = "insert into HoaDon (IDTK , IDPhong, BatDau , KetThuc , GiaPhong, TrangThai , TenLoaiPhong ,SoDT) values ('"+form.IDTK+"','"+form.IDPhong+"','"+form.ThoiGianBD+"' , '"+form.ThoiGianKT+"' , '"+form.DonGia+"' , '0' , '"+form.TenLoaiPhong+"' , '"+form.SDT+"')";
            string query2 = "UPDATE [dbo].[Phong] SET [TrangThai] = '2' WHERE IDPhong = '"+form.IDPhong+"' ";
            dbHelper.ExcutedDB(query);
            dbHelper.ExcutedDB(query2);
            XoaDonDatPhong(form.ID);
        }

        
    }
}
