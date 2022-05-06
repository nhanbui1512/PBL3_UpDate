using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class dbHelper
    {
        private static SqlConnection cnn;

        public dbHelper()
        {
            cnn = new SqlConnection("Data Source=LAPTOP-BFIK942I\\NHANBUI;Initial Catalog=SQL_Hotel;Integrated Security=True");
        }

        public void ExcutedDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetRecord(string query) {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query , cnn);
            DataSet ds = new DataSet();

            cnn.Open();
            adapter.Fill(ds);
            cnn.Close();
            dt = ds.Tables[0];
            return dt;
        }
    }
}
