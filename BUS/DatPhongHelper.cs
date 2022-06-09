using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class DatPhongHelper
    {
        public void DatPhong(FormDatPhong form)
        {
            var datphongdao = new DAL.DatPhongHelper();
            datphongdao.DatPhong(form);
        }

        public void XoaDonDatPhong(int ID)
        {
            var datphongdao = new DAL.DatPhongHelper();
            datphongdao.XoaDonDatPhong(ID);
        }

        public void ThayDoiTrangThai(int ID)
        {
            var datphongdao = new DAL.DatPhongHelper();
            datphongdao.ThayDoiTrangThai(ID);
        }

        public bool ChekThoiGian(DSDatPhongView a, DSDatPhongView b)
        {

            int sosanh1 = DateTime.Compare(a.ThoiGianKT, b.ThoiGianBD);
            int sosanh2 = DateTime.Compare(b.ThoiGianKT, a.ThoiGianBD);

            if (sosanh2 < 0 || sosanh1 < 0)
            {
                return true; // Không trùng thời gian nhau
            }

            return false;
        }

       

        public void XacNhanDon(FormXacNhanDatPhong form)
        {
            var datphongdao = new DAL.DatPhongHelper();
            datphongdao.XacNhanDon(form);

        }
        public void XacNhanVaoO(DSDatPhongView form , int IDNV)
        {
            var xacnhandao = new DAL.DatPhongHelper();
            xacnhandao.XacNhanVaoO(form , IDNV);
        }

        public List<PhongDaDat> GetAllPhongDaDat(int ID){
            List<PhongDaDat> data = new List<PhongDaDat>();
            var dao = new DAL.DatPhongHelper();
            foreach (DataRow i in dao.GetAllPhongDaDat(ID).Rows) {

                data.Add(new PhongDaDat
                {
                    BatDau = Convert.ToDateTime( i["BatDau"]),
                    KetThuc = Convert.ToDateTime(i["KetThuc"]),
                    IDPhong = Convert.ToInt32(i["IDPhong"]),
                    TenPhong = i["TenPhong"].ToString(),
                });

            }
            return data;
        }

        public List<Phong> AllPhongDaDatOfLoaiPhong(int IDLoaiPhong)
        {
            List<Phong> data = new List<Phong>();

            var dao = new DAL.DatPhongHelper();

            foreach (DataRow i in dao.GetAllPhongOfLoaiPhong(IDLoaiPhong).Rows)
            {

                data.Add(new Phong
                {
                    IDPhong = Convert.ToInt32(i["IDPhong"]),
                    TenPhong = i["TenPhong"].ToString(),
                    IDLoaiPhong = IDLoaiPhong
                });
            }

            return data;
        }


        public List<DSDatPhongView> GetAllDatPhongByIDPhong(int ID)
        {
            
            string query = "SELECT DatPhong.BatDau , DatPhong.KetThuc, DatPhong.IDPhong , DatPhong.TenLoaiPhong , Phong.TrangThai , Phong.TenPhong FROM DatPhong , Phong WHERE DatPhong.IDPhong = " +ID+ " and DatPhong.IDPhong = Phong.IDPhong";


            List<DSDatPhongView> data = new List<DSDatPhongView>();
            dbHelper dbHelper = new dbHelper();

            foreach (DataRow i in dbHelper.GetRecord(query).Rows) 
            {
                data.Add(new DSDatPhongView { ThoiGianBD = Convert.ToDateTime(i["BatDau"]) ,
                    ThoiGianKT = Convert.ToDateTime(i["KetThuc"]),
                    IDPhong = i["IDPhong"].ToString(),
                    TenPhong = i["TenPhong"].ToString(),
                    TrangThai = i["TrangThai"].ToString(),
                    TenLoaiPhong = i["TenLoaiPhong"].ToString()
                });
            }
            return data;
        }

        public List<Phong> DSPhongTrongByLoaiPhong(int IDLoaiPhong)
        {
            List<Phong> phongList = new List<Phong>();
            dbHelper dbHelper = new dbHelper();
            string query = "select Phong.IDPhong , Phong.TenPhong,Phong.TrangThai from Phong where Phong.IDLoaiPhong = "+IDLoaiPhong+" and Phong.TrangThai = 0";
            
            foreach(DataRow i in dbHelper.GetRecord(query).Rows)
            {
                phongList.Add(new Phong { IDPhong = Convert.ToInt32(i["IDPhong"]),
                TenPhong = i["TenPhong"].ToString(),
                TrangThai = i["TrangThai"].ToString()
                }
                );
            }

            return phongList;
        }


        public List<Phong> GetAllPhongCoTheDat(int IDLoaiPhong , DSDatPhongView DatPhong)
        {
            List<Phong> data = new List<Phong>();

            PhongHelper phongHelper = new PhongHelper();
            
            foreach(var i in phongHelper.DSPhongByLoaiPhong(IDLoaiPhong) )
            {

                if(GetAllDatPhongByIDPhong(i.IDPhong).Count() == 0)
                {
                    data.Add(i);
                }

                foreach (var j in GetAllDatPhongByIDPhong(i.IDPhong))
                {
                    int dem = 0;

                    if (ChekThoiGian(j, DatPhong) == false)
                    {
                        break;
                    }
                    dem++;

                    if (dem >= GetAllDatPhongByIDPhong(i.IDPhong).Count)
                    {
                        data.Add(new Phong { IDPhong =  Convert.ToInt32( j.IDPhong) , TenPhong = j.TenPhong,TrangThai = j.TrangThai, IDLoaiPhong = j.IDLoaiPhong , TenLoaiPhong = j.TenLoaiPhong });
                    }

                }

            }

            return data;
        }

        public void CheckThoiGianVaoO()
        {
            DateTime now = DateTime.Now;

            var list = new DSDatPhongBus().DSDatPhong();

            TimeSpan timeSpan = new System.TimeSpan(0, 11, 0, 0);
            
            foreach(var i in list)
            {
                DateTime BatDau = i.ThoiGianBD.Add(timeSpan);
                if (DateTime.Compare(BatDau , now) < 0 && i.TrangThai != "2" )
                {
                    XoaDonDatPhong(i.ID); 
                }
            }
        }



    }


}
