using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DSDatPhongDao
    {
        public DataTable GetAllDSDatPhong()
        {
            dbHelper dbHelper = new dbHelper();
            var query = " select DatPhong.IDDatPhong, DatPhong.TinNhan,DatPhong.IDPhong ,DatPhong.SoDT, TaiKhoan.TenTaiKhoan , ThongTinTK.HoTen , DatPhong.BatDau , DatPhong.KetThuc , DatPhong.TrangThai , DatPhong.NgayGui, datphong.IDLoaiPhong , DatPhong.DonGia  , LoaiPhong.TenLoaiPhong "
                       + " from DatPhong, TaiKhoan, ThongTinTK , LoaiPhong "
                       + "  where  DatPhong.IDTK = ThongTinTK.IDTaiKhoan and DatPhong.IDTK = TaiKhoan.IDTK and DatPhong.IDLoaiPhong = LoaiPhong.IDLoaiPhong ";
            return dbHelper.GetRecord(query);

        }
    }
}
