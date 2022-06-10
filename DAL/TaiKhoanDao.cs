using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanDao
    {
        public dbHelper dbHelper = new dbHelper();
        public void DoiMatKhau(string MatKhauMoi, int IDTK )
        {
            string query = "UPDATE TaiKhoan SET MatKhau = '"+MatKhauMoi+"' WHERE IDTK = "+IDTK+"";
            dbHelper.ExcutedDB(query);
        }

        public void XoaTaiKhoan(int ID)
        {
            dbHelper.ExcutedDB("DELETE FROM DatPhong WHERE IDTK = " + ID + "");
            dbHelper.ExcutedDB("DELETE FROM ThongTinTK WHERE IDTaiKhoan = " + ID + "");
        }
    }
}
