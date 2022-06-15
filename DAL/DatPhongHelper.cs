using System;
using System.Collections.Generic;
using System.Data;
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
            string query = "insert into DatPhong (IDTK,IDLoaiPhong,BatDau,KetThuc,TrangThai,DonGia,SoDT,TinNhan , NgayGui , TenLoaiPhong) values ('"+form.IDTK+"','"+form.IDLoaiPhong+"','"+form.CheckIn.ToString("MM/dd/yyyy")+"' ,'"+ form.CheckOut.ToString("MM/dd/yyyy") + "', '0', '"+form.DonGia+"','"+form.SoDT+"',N'"+form.Message+"','"+dt.ToString()+"' , N'"+form.TenLoaiPhong+"')";
            dbHelper.ExcutedDB(query);
        }

        public void XoaDonDatPhong(int IDDatPhong)
        {   
            dbHelper.ExcutedDB("DELETE FROM DatPhong WHERE IDDatPhong = "+IDDatPhong+"");
        }

        public void ThayDoiTrangThai(int IDDatPhong)
        {
            dbHelper.ExcutedDB("UPDATE DatPhong SET TrangThai = '0' , IDPhong = null , IDNhanVien = null WHERE IDDatPhong = " + IDDatPhong + "");
        }

        public void XacNhanDon(FormXacNhanDatPhong form)
        {
            string query = "UPDATE DatPhong SET TrangThai = '"+form.TrangThai+"', IDPhong = '"+form.IDPhong+"' , IDNhanVien = '"+form.IDNhanVien+"' WHERE IDDatPhong = "+form.IDDatPhong+"";
            dbHelper.ExcutedDB(query);
        }
        public void XacNhanVaoO(DSDatPhongView form , int IDNV)
        {
    
            string query2 = "UPDATE [dbo].[Phong] SET [TrangThai] = '1' WHERE IDPhong = '"+form.IDPhong+"' ";
            dbHelper.ExcutedDB(query2);
            dbHelper.ExcutedDB("UPDATE DatPhong SET TrangThai = '2' WHERE IDDatPhong = "+form.ID+" ");
            dbHelper.ExcutedDB("insert into HoaDon values ('"+IDNV+"' ,'0' ,'"+form.ID+"')");
            dbHelper.ExcutedDB("UPDATE ChiTietHoaDon SET TenPhong = '"+form.TenPhong+"' ");

            int IDHoaDon = 0;
            foreach(DataRow i in dbHelper.GetRecord("select HoaDon.IDHoaDon from HoaDon where HoaDon.IDDatPhong = "+form.ID+" ").Rows)
            {
                IDHoaDon = Convert.ToInt32(i["IDHoaDon"]);
            }

            TimeSpan TongTG = form.ThoiGianKT - form.ThoiGianBD;
            double TongTienPhong = form.DonGia * TongTG.Days;
            dbHelper.ExcutedDB("insert into ChiTietHoaDon (IDHoaDon , BatDau , KetThuc , GiaHDPhong , HoVaTen , SDT , CMND , TongTien) values ('" +IDHoaDon+ "' , '"+form.ThoiGianBD+ "', '" + form.ThoiGianKT + "' , '" + form.DonGia+ "', N'" + form.HoVaTen + "' , '" + form.SDT + "' , '"+form.CMND+"', '"+TongTienPhong+"' )");

        }


        public DataTable GetAllPhongDaDat(int IDLoaiPhong )
        {
            dbHelper dbHelper = new dbHelper();
            return dbHelper.GetRecord("select DatPhong.BatDau , DatPhong.KetThuc , Phong.IDPhong , Phong.TenPhong from DatPhong , Phong where(DatPhong.TrangThai = 1 or DatPhong.TrangThai = 2) and DatPhong.IDPhong = Phong.IDPhong and DatPhong.IDLoaiPhong = "+IDLoaiPhong+"");
        }

        // Lấy ra tất cả các phòng đã được đặt thuộc loại phòng nào đó
        public DataTable GetAllPhongOfLoaiPhong(int IDLoaiPhong)
        {
            dbHelper db = new dbHelper();
            return db.GetRecord("select distinct Phong.TenPhong , DatPhong.IDPhong from DatPhong , Phong where DatPhong.IDLoaiPhong = "+IDLoaiPhong+" and DatPhong.IDPhong = Phong.IDPhong ");
        }
        
    }
}
