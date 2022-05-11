using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSKhachHangDao
    {
        public DataTable GetAllKH()
        {
            dbHelper db = new dbHelper();
            var query = "select IDTaiKhoan,TenTaiKhoan , HoTen , NgaySinh , DiaChi , SDT , CMT, GioiTinh from TaiKhoan, ThongTinTK where TaiKhoan.IDTK = ThongTinTK.IDTaiKhoan and TaiKhoan.Quyen = 3";
            return db.GetRecord(query);
        }
    }
}
