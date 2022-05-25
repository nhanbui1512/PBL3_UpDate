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
            var query = "SELECT cthd.IDHoaDon, cthd.HoVaTen, cthd.SDT, cthd.CMND, cthd.BatDau, cthd.KetThuc, tt.HoTen, cthd.GiaHDPhong, hd.TrangThai, dp.TenLoaiPhong, P.TenPhong, cthd.TongTien " +
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

//        select ThongTinHoaDonDV.Soluong, DichVu.TenDichVu , DichVu.GiaTien
//from DichVu, ThongTinHoaDonDV , HoaDon
//where DichVu.IDDV = ThongTinHoaDonDV.IDDV and ThongTinHoaDonDV.IDHoaDon = HoaDon.IDHoaDon


    }
}
