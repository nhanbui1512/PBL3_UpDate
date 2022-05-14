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
            var query = " SELECT DP.IDDatPhong, TT.HoTen, TK.TenTaiKhoan, DP.SoDT, DP.TenPhong, DP.BatDau, DP.KetThuc, DP.TrangThai, DP.TenLoaiPhong, DP.TinNhan, DP.DonGia, DP.NgayGui, DP.IDLoaiPhong " +
                "FROM DatPhong DP " +
                "INNER JOIN TaiKhoan TK " +
                "ON DP.IDTK = TK.IDTK " +
                "INNER JOIN ThongTinTK TT " +
                "ON DP.IDTK = TT.IDTaiKhoan ";
            return dbHelper.GetRecord(query);

        }
    }
}
