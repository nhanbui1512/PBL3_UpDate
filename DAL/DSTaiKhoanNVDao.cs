using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DSTaiKhoanNVDao
    {
        dbHelper dbHelper = new dbHelper();

        public DataTable GetAllDS()
        {
            dbHelper db = new dbHelper();
            string query = "SELECT TK.IDTK, TK.TenTaiKhoan, TT.HoTen, TK.Quyen, TT.CMT, TT.NgaySinh, TT.SDT, TT.GioiTinh, TT.GhiChu" +
                " FROM TaiKhoan TK " +
                "INNER JOIN  ThongTinTK TT " +
                "ON TK.IDTK = TT.IDTaiKhoan ";
            return db.GetRecord(query);
        }

        public void UpDateThongTinTK( DSTaiKhoanNVView form)
        {
            string query = "UPDATE ThongTinTK SET SDT = '" + form.SDT + "', CMT = '" + form.CMND + "', HoTen = N'" + form.HoVaTen + "', GioiTinh = '" + form.GioiTinh + "' WHERE IDTaiKhoan = " + form.ID + ""; 
            dbHelper.ExcutedDB(query);
            string query2 = "UPDATE TaiKhoan SET Quyen = '" + form.Quyen + "' WHERE IDTK = " + form.ID + "";
            dbHelper.ExcutedDB(query2);
        }
        
        public void ResetMatKhau(int ID)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = '123456' WHERE IDTK = "+ID+"";
            dbHelper.ExcutedDB(query);

        }
    }
}
