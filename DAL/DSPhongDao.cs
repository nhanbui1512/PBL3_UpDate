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
    }
}
