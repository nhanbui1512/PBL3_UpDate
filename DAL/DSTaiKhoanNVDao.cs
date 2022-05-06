using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSTaiKhoanNVDao
    {

        public DataTable GetAllDS()
        {
            dbHelper db = new dbHelper();
            string query = "SELECT TK.IDTK, TK.TenTaiKhoan, TT.HoTen, TK.Quyen, TT.CMT, TT.NgaySinh, TT.SDT, TT.GioiTinh, TT.GhiChu" +
                " FROM TaiKhoan TK " +
                "INNER JOIN  ThongTinTK TT " +
                "ON TK.IDTK = TT.IDTaiKhoan ";
            return db.GetRecord(query);
        }
    }
}
