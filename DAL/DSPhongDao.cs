using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DSPhongDao
    {
        dbHelper dbHelper = new dbHelper(); 
        public DataTable GetDSPhongByIDLoaiPhong(int ID)
        {
            DataTable data = new DataTable();
            string query = "SELECT * FROM Phong WHERE IDLoaiPhong = "+ID+"";
            data = dbHelper.GetRecord(query);
            return data;
        }

        public DataTable GetAllPhong()
        {
            DataTable data = new DataTable();
            string query = "select LoaiPhong.IDLoaiPhong , LoaiPhong.TenLoaiPhong , Phong.IDPhong , Phong.TenPhong , Phong.TrangThai"
                + " from Phong, LoaiPhong where LoaiPhong.IDLoaiPhong = Phong.IDLoaiPhong";
            data = dbHelper.GetRecord(query);
            return data;
        }
    }
}
