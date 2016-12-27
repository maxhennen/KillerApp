using KillerApp.Models.Domain_Classes;
using KillerApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerApp.Models.Data
{
    public class SpecificatieSQLContext:ISpecificatieSQLContext
    {
        public List<Specificatie> SpecificatieBijProduct(int productID)
        {
            List<Specificatie> specificaties = new List<Specificatie>();
            using(SqlConnection conn = Database.Connection)
            {
                string query = "SELECT s.*, p.Naam FROM Specificaties s JOIN ProductSpecificatiesVoorraad ps ON ps.Specificaties_SpecificatieID = s.SpecificatieID JOIN Producten p ON p.ProductID = ps.Producten_ProductID WHERE p.ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        specificaties.Add(CreateSpecificatieFromReader(reader));
                    }
                }
            }
            return specificaties;
        }
        private Specificatie CreateSpecificatieFromReader(SqlDataReader reader)
        {
            return new Specificatie(
            Convert.ToString(reader["Naam"]),
            Convert.ToString(reader["Kleur"]),
            Convert.ToBoolean(reader["Bluetooth"]),
            Convert.ToInt32(reader["Geheugen"]),
            Convert.ToBoolean(reader["WiFi"]),
            Convert.ToBoolean(reader["DrieG"]),
            Convert.ToBoolean(reader["VierG"]),
            Convert.ToBoolean(reader["Draadloos"]),
            Convert.ToDecimal(reader["Amphere"]),
            Convert.ToDecimal(reader["Prijs"])); 
        }
    }
}