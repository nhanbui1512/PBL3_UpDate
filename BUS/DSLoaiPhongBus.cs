using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DSLoaiPhongBus
    {
        DSLoaiPhongDao dao = new DSLoaiPhongDao();
        List<DSLoaiPhongView> list = new List<DSLoaiPhongView>();
        public List<DSLoaiPhongView> GetDSLoaiPhong()
        {
            foreach (DataRow i in dao.GetAllLoaiPhong().Rows)
            {
                DSLoaiPhongView obj = new DSLoaiPhongView();
                obj.IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"]);
                obj.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                obj.GhiChu = i["GhiChu"].ToString();
                obj.GiaPhong = Convert.ToDouble(i["GiaPhong"]);
                obj.LienKetAnhDaiDien = i["LienKetAnhDaiDien"].ToString();
                obj.LienKetAnhWC = i["LienKetAnhWC"].ToString();
                list.Add(obj);
            }
            return list;
        }
        public DSLoaiPhongView GetIDDSLoaiPhong(int ID)
        {
            DSLoaiPhongView obj = new DSLoaiPhongView();
            foreach (DataRow i in dao.GetAllLoaiPhong().Rows)
            {
                if(ID == Convert.ToInt32(i["IDLoaiPhong"]))
                {
                    obj.IDLoaiPhong = Convert.ToInt32(i["IDLoaiPhong"]);
                    obj.TenLoaiPhong = i["TenLoaiPhong"].ToString();
                    obj.GhiChu = i["GhiChu"].ToString();
                    obj.GiaPhong = Convert.ToDouble(i["GiaPhong"]);
                    obj.LienKetAnhDaiDien = i["LienKetAnhDaiDien"].ToString();
                    obj.LienKetAnhWC = i["LienKetAnhWC"].ToString();
                }
                
            }
            return obj;
        }

        public List<DSLoaiPhongView> Sort(List<DSLoaiPhongView> list)
        {
            DSLoaiPhongView temp = new DSLoaiPhongView();
            for(int i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if(list[i].GiaPhong < list[j].GiaPhong)
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list; 
        }

        public void DeleteLoaiPhong(int IDLoaiPhong)
        {
            dbHelper db = new dbHelper();

            foreach(DataRow i in db.GetRecord("select DatPhong.IDDatPhong from DatPhong where IDLoaiPhong = "+IDLoaiPhong+"").Rows)
            {
                db.ExcutedDB("delete from ChiTietHoaDon where IDHoaDon = (select HoaDon.IDHoaDon from HoaDon where IDDatPhong = "+i["IDDatPhong"].ToString()+"  )");
                db.ExcutedDB("update ThongTinHoaDonDV set IDHoaDon = null where IDHoaDon = ( select HoaDon.IDHoaDon from HoaDon where HoaDon.IDDatPhong = "+i["IDDatPhong"].ToString()+" ) ");
                db.ExcutedDB("delete from HoaDon where IDDatPhong = " + i["IDDatPhong"].ToString() + "");
           
            }

            db.ExcutedDB("delete from DatPhong where IDLoaiPhong = " + IDLoaiPhong + "");
            db.ExcutedDB("delete from Phong where IDLoaiPhong = " + IDLoaiPhong + "");
            db.ExcutedDB("delete from LoaiPhong where IDLoaiPhong = " + IDLoaiPhong + "");
        }
    }
    }
