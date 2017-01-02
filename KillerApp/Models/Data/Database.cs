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
        private static string connectionString = "Data Source=DESKTOP-VR2JK4O;Initial Catalog=FunDatabase;Integrated Security=True";
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
