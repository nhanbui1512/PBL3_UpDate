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
            var query = "SELECT tthd.IDThongTinHD, hd.ThoiGianGD, tt.HoTen, p.TenPhong, dv.TenDichVu, hd.TongTien " +
                "FROM ThongTinHoaDon tthd " +
                "INNER JOIN HoaDon hd " +
                "ON tthd.IDHoaDon = hd.IDHoaDon " +
                "INNER JOIN DatPhong dp " +
                "ON hd.IDDatPhong = dp.IDDatPhong " +
                "INNER JOIN TaiKhoan tk " +
                "ON dp.IDTK = TK.IDTK " +
                "INNER JOIN ThongTinTK tt " +
                "ON dp.IDTK = tt.IDTaiKhoan " +
                "INNER JOIN ThongTinHoaDonPhong tthdp " +
                "ON hd.IDHoaDon = tthdp.IDHoaDon " +
                "INNER JOIN Phong P " +
                "ON tthdp.IDPhong = P.IDPhong " +
                "INNER JOIN ThongTinHoaDonDV tthddv " +
                "ON hd.IDHoaDon = tthddv.IDHoaDon " +
                "INNER JOIN DichVu dv " +
                "ON tthddv.IDDV = dv.IDDV ";
                
            return db.GetRecord(query);
        }
    }
}
