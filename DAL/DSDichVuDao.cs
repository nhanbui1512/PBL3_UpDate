using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSDichVuDao
    {
        public DataTable GetAllDichVu()
        {
            dbHelper db = new dbHelper();
            string query = "SELECT IDDV, TenDichVu, GiaTien, TrangThai, DonVi, GhiChu FROM DichVu";
            return db.GetRecord(query);
        }
        
        
    }
}
