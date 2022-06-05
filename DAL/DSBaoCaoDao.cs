using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSBaoCaoDao
    {
        public DataTable GetAllBaoCao()
        {
            dbHelper db = new dbHelper();
            var query = "SELECT cthd.IDHoaDon, cthd.HoVaTen, cthd.SDT, cthd.CMND, cthd.BatDau, cthd.KetThuc, cthd.GiaHDPhong, hd.TrangThai, dp.TenLoaiPhong, P.TenPhong, cthd.TongTien , cthd.ThoiGianGiaoDich , cthd.IDNhanVien "

               + " FROM ChiTietHoaDon cthd INNER JOIN HoaDon hd"
                + " ON cthd.IDHoaDon = hd.IDHoaDon "
                 + " INNER JOIN DatPhong dp "
                 + " ON hd.IDDatPhong = dp.IDDatPhong "
                 + " INNER JOIN TaiKhoan tk "
                 + " ON dp.IDTK = TK.IDTK "
                 + " INNER JOIN ThongTinTK tt "
                 + " ON dp.IDTK = tt.IDTaiKhoan "
                 + " INNER JOIN Phong P "
                 + " ON dp.IDPhong = P.IDPhong "
                + " where hd.TrangThai = 1";

            return db.GetRecord(query);
        }

    }
}
