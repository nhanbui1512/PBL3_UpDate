using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webpbl3.Models
{
    public class DBHelper
    {
        private static SqlConnection cnn;
        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }

        public void ExcutedDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public DataTable GetAllTK() {
            string query = "SELECT * FROM TaiKhoan";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader r;

            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "ID" , DataType = typeof(int)}, 
                new DataColumn{ColumnName = "TenTaiKhoan" , DataType = typeof(string)}, 
                new DataColumn{ColumnName = "MatKhau" , DataType = typeof(string)}, 
                new DataColumn{ColumnName = "Quyen" , DataType = typeof(int)},

            });
            cnn.Open();
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                dt.Rows.Add(Convert.ToInt32(r[0]) , r[1].ToString(), r[2].ToString() ,Convert.ToInt32( r[3]) );

            }
            cnn.Close();
            return dt;
            
        }


        public DataTable GetAllKhachHang()
        {
            string query = "SELECT * FROM ThongTinTK";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader r;

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "IDKH" , DataType = typeof(int)},
                new DataColumn{ColumnName = "NgaySinh" , DataType = typeof(DateTime)},
                new DataColumn{ColumnName = "SoDT" , DataType = typeof(string)},
                new DataColumn{ColumnName = "DiaChi" , DataType = typeof(string)},
                new DataColumn{ColumnName = "CMND" , DataType = typeof(string)},
                new DataColumn{ColumnName = "TenKH" , DataType = typeof(string)},
                new DataColumn{ColumnName = "IDTK" , DataType = typeof(int)},

            });

            cnn.Open();
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                dt.Rows.Add(Convert.ToInt32(r["IDKH"]), Convert.ToDateTime( r["NgaySinh"]),
                    r["SoDT"].ToString(), r["DiaChi"].ToString() ,
                    r["CMND"].ToString() , r["TenKH"].ToString(),
                    Convert.ToInt32(r["IDTK"]) );

            }
            cnn.Close();

            return dt;
        }

        public DataTable GetRecord(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
            DataSet dataset = new DataSet();

            cnn.Open();
            adapter.Fill(dataset ,"Record");
            cnn.Close();
            dt = dataset.Tables["Record"];
            return dt;
        }

        

    }
    
}