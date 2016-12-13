using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace KillerApp.Data
{
    class BestellingSQLContext:IBestellingSQLContext
    {
       public Bestelling Invoeren(List<Producten> producten, Gebruiker email)
        {
            Bestelling bestelling = new Bestelling();
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand("BestellingInvoeren", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email.Mail;
                    cmd.Parameters.Add("@List", SqlDbType.VarChar).Value = producten;
                    conn.Open();
                    cmd.ExecuteNonQuery();  
                } 
            }
            return bestelling;
        }
    }
}
