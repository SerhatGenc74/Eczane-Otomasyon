using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon
{
    public static class Connection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=(localdb)\\serhatt;Initial Catalog=Eczane_Otomasyon;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); 

            conn.Open();

            return conn;
        }
    }
}
