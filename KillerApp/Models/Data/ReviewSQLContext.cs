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
    class ReviewSQLContext:IReviewSQLContext
    {
        public void ReviewPlaatsen(Review review)
        {
            string query = "INSERT INTO Review(AantalSterren,ReviewTekst,DatumTijd,Gebruiker_GebruikerID,Producten_ProductID)" +
                "VALUES(@AantalSterren,@ReviewTekst,@DatumTijd,@GebruikerID,@ProductID)";
            using(SqlConnection conn = Database.Connection)
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AantalSterren", review.AantalSterren);
                    cmd.Parameters.AddWithValue("@ReviewTekst", review.ReviewTekst);
                    cmd.Parameters.AddWithValue("@DatumTijd", DateTime.Now);
                    cmd.Parameters.AddWithValue("@GebruikerID", review.KlantID);
                    cmd.Parameters.AddWithValue("@ProductID", review.ProductID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Review> ReviewBijProduct(string productNaam)
        {
            List<Review> reviews = new List<Review>();
            string query = "select datediff(DAY,r.DatumTijd,CURRENT_TIMESTAMP) as VerschilDagen,(select AVG(AantalSterren) from Review) as Gemiddelde,r.*, g.Voornaam + ' ' + g.Achternaam as Naam from Review r join Gebruiker g on g.GebruikerID = r.Gebruiker_GebruikerID join Producten p on p.ProductID = r.Producten_ProductID where p.Naam = @productNaam group by g.Achternaam, g.Voornaam, r.AantalSterren,r.Gebruiker_GebruikerID,r.Producten_ProductID,r.ReviewID,r.ReviewTekst, r.DatumTijd";
            using (SqlConnection conn = Database.Connection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productNaam", productNaam);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reviews.Add(CreateReviewFromReader(reader));
                        }
                    }
                }
            }
            return reviews;
        }

        private Review CreateReviewFromReader(SqlDataReader reader)
        {
            return new Review(
                Convert.ToInt32(reader["ReviewID"]),
                Convert.ToInt32(reader["AantalSterren"]),
                Convert.ToString(reader["ReviewTekst"]),
                Convert.ToString(reader["Naam"]),
                Convert.ToInt32(reader["Producten_ProductID"]),
                Convert.ToDateTime(reader["DatumTijd"]),
                Convert.ToInt32(reader["VerschilDagen"])
                );
        }
    }
}
