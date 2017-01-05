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
    class BestellingSQLContext : IBestellingSQLContext 
    {
        public List<Bestelling> BestellingenGebruiker(int gebruikerID)
        {
            List<Bestelling> bestellingen = new List<Bestelling>();
            string query = "select v.Aantal,s.*,p.*, g.*, b.DatumTijd,r.BestelregelID from Specificaties s join ProductSpecificatiesVoorraad ps on ps.Specificaties_SpecificatieID = s.SpecificatieID join Voorraad v on v.VoorraadID = ps.Voorraad_VoorraadID join Producten p on p.ProductID = ps.Producten_ProductID join Bestelregel r on r.Producten_ProductID = p.ProductID join Bestelling b on b.BestellingID = r.Bestelling_BestellingID join Gebruiker g on g.GebruikerID = b.Gebruiker_GebruikerID where g.GebruikerID = 1";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GebruikerID", gebruikerID);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bestellingen.Add(CreateBestellingFromReader(reader));
                        }
                    }
                }
            }
            return bestellingen;
        }

        public void Bestelling(List<Bestelling> producten)
        {

        }


        public Bestelling CreateBestellingFromReader(SqlDataReader reader)
        {
            ProductenSQLContext productSQL = new ProductenSQLContext();
            GebruikerSQLContext gebruikerSQL = new GebruikerSQLContext();

            return new Bestelling(
                Convert.ToInt32(reader["BestelregelID"]),
                productSQL.CreateProductFromReader(reader),
                gebruikerSQL.CreateUserFromReader(reader),
                Convert.ToDateTime(reader["DatumTijd"]));
        }
    }
}
