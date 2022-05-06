using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSDatPhongDao
    {
        public DataTable GetAllDSDatPhong()
        {
            dbHelper dbHelper = new dbHelper();
            var query = " SELECT DP.IDDatPhong, TT.HoTen, TK.TenTaiKhoan, TT.SDT, P.TenPhong, DP.SoLuong, DP.BatDau, DP.KetThuc, DP.TrangThai " +
                "FROM DatPhong DP " +
                "INNER JOIN TaiKhoan TK " +
                "ON DP.IDTK = TK.IDTK " +
                "INNER JOIN ThongTinTK TT " +
                "ON DP.IDTK = TT.IDTaiKhoan " +
                "INNER JOIN Phong_DatPhong PDP " +
                "ON DP.IDDatPhong = PDP.IDDatPhong " +
                "INNER JOIN Phong P " +
                "ON PDP.IDPhong = P.IDPhong ";
            return dbHelper.GetRecord(query);

        }
    }
}
