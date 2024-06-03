using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Mini
{
    internal  class Dal
    {
        SqlConnection conn;
        public  SqlConnection Connect(string connectionString) {
             conn = new SqlConnection(connectionString);
            return conn;
        }

        public  int FireQuery(string query) { 
            SqlCommand command= new SqlCommand(query, conn);
            conn.Open();
            int affected= command.ExecuteNonQuery();
            conn.Close();

            return affected;
        }

    }
}
