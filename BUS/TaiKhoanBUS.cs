using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class TaiKhoanBUS
    {

        public void UpDateMatKhau(string MatKhau, int ID)
        {
            TaiKhoanDao dao = new TaiKhoanDao();
            dao.DoiMatKhau(MatKhau, ID);
        }
    }
}
