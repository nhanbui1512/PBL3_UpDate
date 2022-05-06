using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSLoaiPhongDao
    {
        public DataTable GetAllLoaiPhong()
        {
            dbHelper db = new dbHelper();
            string query = " SELECT IDLoaiPhong, TenLoaiPhong, GhiChu, GiaPhong, LienKetAnh FROM LoaiPhong";
            return db.GetRecord(query);
        }
    }
}
