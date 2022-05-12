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
    }
    }
