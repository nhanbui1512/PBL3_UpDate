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
    public class DSPhongBUS
    {
        public List<Phong> GetDSPhongByIDLoaiPhong(int ID)
        {
            DSPhongDao dao = new DSPhongDao();
            List<Phong> phongList = new List<Phong>();

            foreach( DataRow i in dao.GetDSPhongByIDLoaiPhong(ID).Rows)
            {
                phongList.Add(new Phong { IDPhong = Convert.ToInt32( i["IDPhong"].ToString()),
                    IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"].ToString()),
                    TenPhong = i["TenPhong"].ToString(),
                    TrangThai = i["TrangThai"].ToString() 
                   
                });
            }

            return phongList;


        }
    }
}
