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
            string query = "SELECT Phong.IDLoaiPhong , Phong.TenPhong , Phong.IDPhong FROM Phong WHERE Phong.IDLoaiPhong = "+IDLoaiPhong+"";
            

            if(dbHelper.GetRecord(query).Rows.Count > 0)
            {
                foreach (DataRow i in dbHelper.GetRecord(query).Rows)
                {
                    Data.Add(new Phong
                    {
                        TenPhong = i["TenPhong"].ToString(),
                        IDPhong = Convert.ToInt32(i["IDPhong"]),
                        IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"])
                    });
                }
            }
            
            return Data;
        }

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
    }
}
