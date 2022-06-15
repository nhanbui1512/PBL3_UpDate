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
            var query = "SELECT * FROM HoaDonThanhToan";

            return db.GetRecord(query);
        }

    }
}
