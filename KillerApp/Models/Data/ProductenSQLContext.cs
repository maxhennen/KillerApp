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
        public List<Producten> AlleTelefoons()
        {
            List<Producten> producten = new List<Producten>();
            string query = "SELECT * From Producten WHERE Soort Like 'Telefoon' ";
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

        public List<Producten> ProductenHomepage()
        {
            List<Producten> producten = new List<Producten>();
            string query = "select * from ( select top 3 * from Producten  ) x  order by Prijs desc; ";
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
        public Producten ProductBijID(int productID)
        {
            Producten product = new Producten();
            string query = "Select * From Producten WHERE ProductID = @ProductID";
            using (SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
        private Producten CreateProductFromReader(SqlDataReader reader)
        {
                if (reader["Telefoon_ProductID"] != DBNull.Value)
            {
                return new Producten(
                Convert.ToInt32(reader["ProductID"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToDecimal(reader["Prijs"]),
                Convert.ToString(reader["Merk"]),
                Convert.ToInt32(reader["Voorraad_VoorraadID"]),
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
                Convert.ToInt32(reader["Voorraad_VoorraadID"]),
                Convert.ToString(reader["Afbeeldingen"]),
                0);
            }
        }
    }
}
