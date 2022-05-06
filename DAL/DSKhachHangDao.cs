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
            var query = "SELECT IDTaiKhoan, HoTen, NgaySinh, CMT, SDT, DiaChi FROM ThongTinTK";
            return db.GetRecord(query);
        }
    }
}
