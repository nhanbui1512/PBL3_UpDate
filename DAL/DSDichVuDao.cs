using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

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
        
        public void UpDateDichVu(FormDichVu dv)
        {
            dbHelper db = new dbHelper();
            string query = "UPDATE DichVu SET GiaTien = '" + dv.GiaTien + "', TrangThai = '" + dv.TrangThai + "', TenDichVu = N'" + dv.TenDV + "', DonVi = N'" + dv.DonVi + "' WHERE IDDV = " + dv.IDDV + "";
            db.ExcutedDB(query);
        }
    }
}
