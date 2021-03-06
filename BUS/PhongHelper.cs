using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class PhongHelper
    {
        dbHelper dbHelper = new dbHelper();

        public bool ThemPhong(FormThemPhong form)
        {
            if(CheckPhong(form) == true)
            {
                string query = "INSERT INTO Phong (TenPhong , TrangThai, IDLoaiPhong) VALUES ('"+form.TenPhong+"' , '0' , '"+form.IDLoaiPhong+"')";
                dbHelper.ExcutedDB(query);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Phong> DSPhongByLoaiPhong(int IDLoaiPhong)
        {
            List<Phong> Data = new List<Phong>();
            string query = "SELECT LoaiPhong.TenLoaiPhong, Phong.IDLoaiPhong , Phong.TenPhong , Phong.IDPhong, Phong.TrangThai FROM Phong,LoaiPhong WHERE Phong.IDLoaiPhong = "+IDLoaiPhong+ " and Phong.IDLoaiPhong = LoaiPhong.IDLoaiPhong";
            

            if(dbHelper.GetRecord(query).Rows.Count > 0)
            {
                foreach (DataRow i in dbHelper.GetRecord(query).Rows)
                {
                    Data.Add(new Phong
                    {
                        TenPhong = i["TenPhong"].ToString(),
                        IDPhong = Convert.ToInt32(i["IDPhong"]),
                        IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"]),
                        TrangThai = i["TrangThai"].ToString(),
                        TenLoaiPhong = i["TenLoaiPhong"].ToString()
                    }) ;
                }
            }
            
            return Data;
        }


        // kiểm tra tên phòng đã tồn tại trong loại phòng đó hay chưa
        public bool CheckPhong(FormThemPhong form)
        {
            int dem = 0;
            bool result = false;

            foreach (Phong i in DSPhongByLoaiPhong(Convert.ToInt32(form.IDLoaiPhong)))
            {
                if (form.TenPhong == i.TenPhong)
                {
                    result = false;
                    break;
                }
                dem++;
            }

            if(dem >= DSPhongByLoaiPhong(Convert.ToInt32(form.IDLoaiPhong)).Count)
            {
                result = true;
            }
            return result;
        }

        public void DeletePhong(int IDPhong)
        {
            dbHelper db = new dbHelper();

            foreach (DataRow i in db.GetRecord("select DatPhong.IDDatPhong from DatPhong where IDPhong = " + IDPhong + "").Rows)
            {
                db.ExcutedDB("delete from ChiTietHoaDon where IDHoaDon = (select HoaDon.IDHoaDon from HoaDon where IDDatPhong = " + i["IDDatPhong"].ToString() + "  )");
                db.ExcutedDB("update ThongTinHoaDonDV set IDHoaDon = null where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where HoaDon.IDDatPhong = " + i["IDDatPhong"].ToString() + " ) ");
                db.ExcutedDB("delete from HoaDon where IDDatPhong = " + i["IDDatPhong"].ToString() + "");

            }
            db.ExcutedDB("delete from DatPhong where IDPhong = " + IDPhong + "");
            db.ExcutedDB("delete from Phong where IDPhong = " + IDPhong + "");

        }

        public void Update (Phong phong)
        {
            string query = "UPDATE Phong SET TenPhong = '"+phong.TenPhong+"' , TrangThai = '"+phong.TrangThai+"' WHERE IDPhong = "+phong.IDPhong+" ";
            dbHelper.ExcutedDB(query);
        }
    }
}
