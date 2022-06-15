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
        private DSPhongDao dao = new DSPhongDao();

        public List<Phong> GetDSPhongByIDLoaiPhong(int ID)
        {
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

        public List<Phong> GetAllPhong()
        {
            List<Phong> phongList = new List<Phong>();
            foreach(DataRow i in dao.GetAllPhong().Rows)
            {
                Phong phong = new Phong();
                phong.IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"]);
                phong.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                phong.IDPhong = Convert.ToInt32(i["IDPhong"]);
                phong.TenPhong = i["TenPhong"].ToString();
                phong.TrangThai = i["TrangThai"].ToString();
                phongList.Add(phong);
            }
            return phongList;
        }

        
    }
}
