using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSHoaDonDao
    {
        public DataTable GetAllDSHoaDon()
        {
            dbHelper dbHelper = new dbHelper();
            var query = "SELECT cthd.IDHoaDon, cthd.HoVaTen, cthd.SDT, cthd.CMND, cthd.BatDau, cthd.KetThuc, tt.HoTen, cthd.GiaHDPhong, hd.TrangThai, dp.TenLoaiPhong,P.IDPhong, P.TenPhong, cthd.TongTien " +
                 "FROM ChiTietHoaDon cthd " +
                 "INNER JOIN HoaDon hd " +
                 "ON cthd.IDHoaDon = hd.IDHoaDon " +
                 "INNER JOIN DatPhong dp " +
                 "ON hd.IDDatPhong = dp.IDDatPhong " +
                 "INNER JOIN TaiKhoan tk " +
                 "ON dp.IDTK = TK.IDTK " +
                 "INNER JOIN ThongTinTK tt " +
                 "ON dp.IDTK = tt.IDTaiKhoan " +
                 "INNER JOIN Phong P " +
                 "ON dp.IDPhong = P.IDPhong ";
            return dbHelper.GetRecord(query);
        }

        public DataTable GetAllDSDichVuByIDHoaDon(int ID)
        {
            dbHelper dbHelper=new dbHelper();
            var query = "SELECT * FROM ThongTinHoaDonDV WHERE IDHoaDon = " + ID + " ";
            return dbHelper.GetRecord(query);
        }


        
        public DataTable GetAllDSDichVuByIDHoaDonThanhToan(int ID)
        {
            dbHelper dbHelper = new dbHelper();
            var query = "SELECT * FROM ThongTinHoaDonDV WHERE IDHoaDonThanhToan = " + ID + " ";
            return dbHelper.GetRecord(query);
        }


        public void ThemHoaDonDV(FormThemHoaDonDV form)
        {
            dbHelper dbHelper = new dbHelper();
            dbHelper.ExcutedDB("INSERT INTO ThongTinHoaDonDV (IDDV, IDHoaDon, SoLuong , TenDichVu , GiaDichVu , ThanhTien , IDHoaDonThanhToan) VALUES ('"+form.IDDV+ "', '" + form.IDHoaDon + "', '" + form.SoLuong + "' , N'" + form.TenDV + "' , '" + form.GiaDichVu + "', '" + form.ThanhTien + "' , '"+form.IDHoaDon+"' ) ");
            double ThanhTienDV = form.GiaDichVu * form.SoLuong;
            dbHelper.ExcutedDB("UPDATE ChiTietHoaDon set TongTien = TongTien + "+ThanhTienDV+" ");
        }

        public void ThemHoaDonDVCoSan(FormThemHoaDonDV form)
        {
            double ThanhTienDV = form.GiaDichVu * form.SoLuong;

            dbHelper dbHelper = new dbHelper();
            dbHelper.ExcutedDB("update ThongTinHoaDonDV set Soluong = (Soluong + "+form.SoLuong+") where IDDV = "+form.IDDV+" and IDHoaDon = "+form.IDHoaDon+"");
            dbHelper.ExcutedDB("update ChiTietHoaDon set TongTien = TongTien + " + ThanhTienDV + "");
        }

        public void UpDateHoaDon()
        {
            dbHelper dbHelper = new dbHelper();
            dbHelper.ExcutedDB("update ThongTinHoaDonDV set ThanhTien = GiaDichVu * Soluong");
        }


        public void ThanhToanHoaDon(int IDHoaDon,int IDPhong , int IDUser, string UserName , double TongTien, DSHoaDonView hoadonphong)
        {
            dbHelper dbHelper = new dbHelper();
            DateTime date = DateTime.Now;
            dbHelper.ExcutedDB("UPDATE HoaDon set TrangThai = 1 where IDHoaDon = "+IDHoaDon+"");
            dbHelper.ExcutedDB("UPDATE ChiTietHoaDon set IDNhanVien = "+IDUser+" , TongTien = '"+TongTien+"', ThoiGianGiaoDich = '"+date+"' where IDHoaDon = "+IDHoaDon+" ");
            dbHelper.ExcutedDB("UPDATE Phong set TrangThai = '0' WHERE IDPhong = " + IDPhong + "");
            dbHelper.ExcutedDB("INSERT INTO HoaDonThanhToan (IDHoaDonThanhToan, HoVaTen , SoDT, CMND ,TenLoaiPhong, TenPhong , BatDau , KetThuc , NhanVienThanhToan, ThoiGianGiaoDich, GiaPhong, TongTien) VALUES ('"+hoadonphong.ID+ "', N'" + hoadonphong.HoVaTen + "' , '" + hoadonphong.SDT + "' , '" + hoadonphong.CMND + "' , '" + hoadonphong.TenLoaiPhong + "' , '" + hoadonphong.TenPhong + "', '" + hoadonphong.BatDau + "' , '" + hoadonphong.KetThuc + "' , N'" + UserName + "' , '" + DateTime.Now + "' , '" + hoadonphong.GiaPhong + "' , '" + hoadonphong.TongTien + "') ");
        }

        public void XoaHoaDonDV(int IDDV, int IDHoaDon, double TongTienDV)
        {
            dbHelper db = new dbHelper();
            db.ExcutedDB("Delete ThongTinHoaDonDV WHERE IDDV = "+IDDV+" AND IDHoaDon = "+IDHoaDon+"");
            db.ExcutedDB("Update ChiTietHoaDon set TongTien = TongTien - " + TongTienDV + "");
        }

    }
}
