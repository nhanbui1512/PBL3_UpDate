using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class TaiKhoanBUS
    {

        public void UpDateMatKhau(string MatKhau, int ID)
        {
            TaiKhoanDao dao = new TaiKhoanDao();
            dao.DoiMatKhau(MatKhau, ID);
        }
        public void DeleleTaiKhoan(int ID)
        {
            dbHelper db = new dbHelper();
            string query = "select DatPhong.IDDatPhong from DatPhong where DatPhong.IDTK = "+ID+ "";
            foreach (DataRow i in db.GetRecord(query).Rows)
            {
                db.ExcutedDB("delete from ChiTietHoaDon where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where IDDatPhong = "+i["IDDatPhong"].ToString()+" ) ");
                db.ExcutedDB("update ThongTinHoaDonDV set IDHoaDon = null where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where IDDatPhong = "+ i["IDDatPhong"].ToString() + " )");
                db.ExcutedDB("delete from HoaDon where HoaDon.IDDatPhong =  "+ i["IDDatPhong"].ToString() + "");
            }
       
            db.ExcutedDB("delete from DatPhong where DatPhong.IDTK = "+ID+"");
            db.ExcutedDB("delete from ThongTinTK where IDTaiKhoan = "+ID+"");
            db.ExcutedDB("delete from TaiKhoan where IDTK = " + ID + "");

        }
    }
}
