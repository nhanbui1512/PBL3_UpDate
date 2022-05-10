using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSPhongDaDatDao
    {
        public DataTable GetALLPhong()
        {
            dbHelper dbHelper = new dbHelper();
            var query = "select DatPhong.BatDau , DatPhong.KetThuc , Phong.IDPhong , LoaiPhong.IDLoaiPhong , Phong.TrangThai" +
                        "from DatPhong, Phong, Phong_DatPhong, LoaiPhong " +
                        "where Phong.IDPhong = Phong_DatPhong.IDPhong and DatPhong.IDDatPhong = Phong_DatPhong.IDDatPhong and DatPhong.IDLoaiPhong = LoaiPhong.IDLoaiPhong";
            return dbHelper.GetRecord(query);
        }
    }
}
