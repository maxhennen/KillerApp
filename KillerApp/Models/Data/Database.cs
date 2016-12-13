using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models
{
    public class Database
    {
        private static string connectionString = "Data Source=Laptop-Max;Initial Catalog=FunData;Integrated Security=True";
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }

    }
}
