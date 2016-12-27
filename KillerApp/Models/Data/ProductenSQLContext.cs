using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;
using System.Data.SqlClient;

namespace KillerApp.Data
{
    class ProductenSQLContext : IProductenSQLContext
    {
        private Producten product;

        public List<Producten> AlleTelefoons()
        {
            List<Producten> producten = new List<Producten>();
            string query = "SELECT * FROM (SELECT  p.Afbeeldingen,p.Merk,p.Naam,p.ProductID,p.Soort,p.Telefoon_ProductID,s.Prijs,ROW_NUMBER() OVER(PARTITION BY p.Naam ORDER BY p.ProductID DESC) rn FROM Producten p join ProductSpecificatiesVoorraad ps on ps.Producten_ProductID = p.ProductID join Specificaties s on s.SpecificatieID = ps.Specificaties_SpecificatieID ) a WHERE rn = 1";
            using (SqlConnection conn = Database.Connection)
            {
              using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producten.Add(CreateProductFromReader(reader));
                        }
                    }
                }           
            }
            return producten;
        }

        public Producten ProductBijID(int productID)
        {
            string query = "SELECT s.Prijs, p.* FROM Specificaties s JOIN ProductSpecificatiesVoorraad ps ON ps.Specificaties_SpecificatieID = s.SpecificatieID JOIN Producten p ON p.ProductID = ps.Producten_ProductID WHERE p.ProductID = @ProductID";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product = CreateProductFromReader(reader);
                        }
                    }
                }
            }
            return product;
        }

        public List<Producten> ProductenHomepage()
        {
            List<Producten> producten = new List<Producten>();
            string query = "select * from ( select top 3 p.*, s.Prijs  from Producten p join ProductSpecificatiesVoorraad ps on ps.Producten_ProductID = p.ProductID join Specificaties s on s.SpecificatieID = ps.Specificaties_SpecificatieID order by s.Prijs desc) x;";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            producten.Add(CreateProductFromReader(reader));
                        }
                    }
                }
            }
            return producten;
        }
        
        private Producten CreateProductFromReader(SqlDataReader reader)
        {
                if (reader["Telefoon_ProductID"] != DBNull.Value)
            {
                return new Producten(
                Convert.ToInt32(reader["ProductID"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToDecimal(reader["Prijs"]),
                Convert.ToString(reader["Merk"]),
                Convert.ToString(reader["Afbeeldingen"]),
                Convert.ToInt32(reader["Telefoon_ProductID"]));
;
            }
                else
            {
                return new Producten(
                Convert.ToInt32(reader["ProductID"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToDecimal(reader["Prijs"]),
                Convert.ToString(reader["Merk"]),
                Convert.ToString(reader["Afbeeldingen"]),
                0);
            }
        }
    }
}
