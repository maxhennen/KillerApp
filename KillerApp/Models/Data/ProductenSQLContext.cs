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
        private List<Producten> producten;

        public void ProductToevoegen(Producten product)
        {
            string[] queries = new string[4];
            queries[0] = "INSERT INTO Voorraad(Aantal)Values(@Aantal)";
            queries[1] = "INSERT INTO Producten(Naam,Merk,Soort,Telefoon_ProductID)Values(@Naam,@Merk,@Soort,@Telefoon_ProductID)";
            queries[2] = "INSERT INTO Specificaties(Kleur,Bluetooth,Geheugen,Wifi,DrieG,VierG,Draadloos,Prijs,Afbeeldingen)" +
                "Values(@Kleur,@Bluetooth,@Geheugen,@Wifi,@DrieG,@VierG,@Draadloos,@Prijs,@Afbeeldingen)";
            queries[3] = "INSERT INTO ProductSpecificatiesVoorraad(Specificaties_SpecificatieID,Producten_ProductID,Voorraad_VoorraadID)" +
                "Values((Select Max(SpecificatieID)From Specificaties),(Select Max(ProductID)From Producten),(Select Max(VoorraadID)From Voorraad))";
            using (SqlConnection conn = Database.Connection)
            {
                for (int i = 0; i < queries.Length; i++)
                {
                    using (SqlCommand cmd = new SqlCommand(queries[i], conn))
                    {
                        if (product.TelefoonID == 0)
                        {
                            cmd.Parameters.AddWithValue("@Naam", product.Naam);
                            cmd.Parameters.AddWithValue("@Merk", product.Merk);
                            cmd.Parameters.AddWithValue("@Soort", product.Soort);
                            cmd.Parameters.AddWithValue("@Telefoon_ProductID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Aantal", product.Aantal);
                            cmd.Parameters.AddWithValue("@Kleur", product.Kleur);
                            cmd.Parameters.AddWithValue("@Bluetooth", product.Bluetooth);
                            cmd.Parameters.AddWithValue("@Geheugen", product.Geheugen);
                            cmd.Parameters.AddWithValue("@Wifi", product.WiFi);
                            cmd.Parameters.AddWithValue("@DrieG", product.DrieG);
                            cmd.Parameters.AddWithValue("@VierG", product.VierG);
                            cmd.Parameters.AddWithValue("@Draadloos", product.Draadloos);
                            cmd.Parameters.AddWithValue("@Prijs", product.Prijs);
                            cmd.Parameters.AddWithValue("@Afbeeldingen", product.Afbeeldingen);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Naam", product.Naam);
                            cmd.Parameters.AddWithValue("@Merk", product.Merk);
                            cmd.Parameters.AddWithValue("@Soort", product.Soort);
                            cmd.Parameters.AddWithValue("@Telefoon_ProductID", product.TelefoonID);
                            cmd.Parameters.AddWithValue("@Aantal", product.Aantal);
                            cmd.Parameters.AddWithValue("@Kleur", product.Kleur);
                            cmd.Parameters.AddWithValue("@Bluetooth", product.Bluetooth);
                            cmd.Parameters.AddWithValue("@Geheugen", product.Geheugen);
                            cmd.Parameters.AddWithValue("@Wifi", product.WiFi);
                            cmd.Parameters.AddWithValue("@DrieG", product.DrieG);
                            cmd.Parameters.AddWithValue("@VierG", product.VierG);
                            cmd.Parameters.AddWithValue("@Draadloos", product.Draadloos);
                            cmd.Parameters.AddWithValue("@Prijs", product.Prijs);
                            cmd.Parameters.AddWithValue("@Afbeeldingen", product.Afbeeldingen);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public List<Producten> AlleAccessoires()
        {
            producten = new List<Producten>();
            string query = "select * from ( select s.*,p.*, v.Aantal, ROW_NUMBER() over (Partition by p.Naam Order By p.ProductID desc) rn from Producten p join ProductSpecificatiesVoorraad ps on ps.Producten_ProductID = p.ProductID join Specificaties s on s.SpecificatieID = ps.Specificaties_SpecificatieID join Voorraad v on v.VoorraadID = ps.Voorraad_VoorraadID where p.Soort like 'accessoire') a where rn = 1";
            using (SqlConnection conn = Database.Connection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
        public List<Producten> AlleTelefoons()
        {
            producten = new List<Producten>();
            string query = "select * from ( select s.*,p.*, v.Aantal, ROW_NUMBER() over (Partition by p.Naam Order By p.ProductID desc) rn from Producten p join ProductSpecificatiesVoorraad ps on ps.Producten_ProductID = p.ProductID join Specificaties s on s.SpecificatieID = ps.Specificaties_SpecificatieID join Voorraad v on v.VoorraadID = ps.Voorraad_VoorraadID where p.Soort like 'telefoon') a where rn = 1";
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

        public List<Producten> ProductBijNaam(string ProductNaam)
        {
            producten = new List<Producten>();
            string query = "select s.*,p.*, v.Aantal from Specificaties s join ProductSpecificatiesVoorraad ps on ps.Specificaties_SpecificatieID = s.SpecificatieID join Producten p on p.ProductID = ps.Producten_ProductID join Voorraad v on v.VoorraadID = ps.Voorraad_VoorraadID where p.Naam = @ProductNaam";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductNaam", ProductNaam);
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
            producten = new List<Producten>();
            string query = "select * from (select top 3 s.*,p.*, v.Aantal from Specificaties s join ProductSpecificatiesVoorraad ps on ps.Specificaties_SpecificatieID = s.SpecificatieID join Producten p on p.ProductID = ps.Producten_ProductID join Voorraad v on v.VoorraadID = ps.Voorraad_VoorraadID order by s.Prijs desc) x;";
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

        public void UpdateVoorraad(string productNaam, int specificatieID, int aantal)
        {
            string query = "update Voorraad set Aantal = @Aantal from Voorraad v join ProductSpecificatiesVoorraad ps on ps.Voorraad_VoorraadID =v.VoorraadID join Producten p on p.ProductID = ps.Producten_ProductID join Specificaties s on s.SpecificatieID = ps.Specificaties_SpecificatieID where p.Naam = @ProductNaam and s.SpecificatieID = @SpecificatieID;";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Aantal", aantal);
                    cmd.Parameters.AddWithValue("@ProductNaam", productNaam);
                    cmd.Parameters.AddWithValue("@SpecificatieID", specificatieID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Producten ProductToevoegenWinkelmand(string productNaam, int specificatieID)
        {
            Producten product = new Producten();
            string query = "Select p.*, s.*, v.Aantal From Producten p join ProductSpecificatiesVoorraad ps on ps.Producten_ProductID = p.ProductID join Specificaties s on s.SpecificatieID = ps.Specificaties_SpecificatieID join Voorraad v on v.VoorraadID = ps.Voorraad_VoorraadID where p.Naam = @ProductNaam and s.SpecificatieID = @SpecificatieID;";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductNaam", productNaam);
                    cmd.Parameters.AddWithValue("@SpecificatieID", specificatieID);
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

        public Producten CreateProductFromReader(SqlDataReader reader)
        {
                if (reader["Telefoon_ProductID"] != DBNull.Value)
            {
                return new Producten(
                Convert.ToInt32(reader["ProductID"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToString(reader["Merk"]),
                Convert.ToInt32(reader["Telefoon_ProductID"]),
                Convert.ToInt32(reader["Aantal"]),
                Convert.ToString(reader["Soort"]),
                Convert.ToInt32(reader["SpecificatieID"]),
                Convert.ToString(reader["Kleur"]),
                Convert.ToBoolean(reader["Bluetooth"]),
                Convert.ToInt32(reader["Geheugen"]),
                Convert.ToBoolean(reader["WiFi"]),
                Convert.ToBoolean(reader["DrieG"]),
                Convert.ToBoolean(reader["VierG"]),
                Convert.ToBoolean(reader["Draadloos"]),
                Convert.ToDecimal(reader["Prijs"]),
                Convert.ToString(reader["Afbeeldingen"])
                );
            }
                else
            {
                return new Producten(
                Convert.ToInt32(reader["ProductID"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToString(reader["Merk"]),
                0,
                Convert.ToInt32(reader["Aantal"]),
                Convert.ToString(reader["Soort"]),
                Convert.ToInt32(reader["SpecificatieID"]),
                Convert.ToString(reader["Kleur"]),
                Convert.ToBoolean(reader["Bluetooth"]),
                Convert.ToInt32(reader["Geheugen"]),
                Convert.ToBoolean(reader["WiFi"]),
                Convert.ToBoolean(reader["DrieG"]),
                Convert.ToBoolean(reader["VierG"]),
                Convert.ToBoolean(reader["Draadloos"]),
                Convert.ToDecimal(reader["Prijs"]),
                Convert.ToString(reader["Afbeeldingen"])
                );
            }
        }

        public Producten ProductToevoegenWinkelmandUnitTest(string productNaam, int specificatieID)
        {
            throw new NotImplementedException();
        }
    }
}
