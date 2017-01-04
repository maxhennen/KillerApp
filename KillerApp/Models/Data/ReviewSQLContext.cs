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
        public Review Invoeren(Review review)
        {
            return review;
        }

        public List<Review> ReviewBijProduct(int productID)
        {
            List<Review> reviews = new List<Review>();
            string query = "select datediff(DAY,r.DatumTijd,CURRENT_TIMESTAMP) as VerschilDagen,(select AVG(AantalSterren) from Review) as Gemiddelde,r.*, g.Voornaam + ' ' + g.Achternaam as Naam from Review r join Gebruiker g on g.GebruikerID = r.Gebruiker_GebruikerID where r.Producten_ProductID = @ProductID group by g.Achternaam, g.Voornaam, r.AantalSterren,r.Gebruiker_GebruikerID,r.Producten_ProductID,r.ReviewID,r.ReviewTekst, r.DatumTijd";
            using (SqlConnection conn = Database.Connection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
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
                Convert.ToInt32(reader["Gemiddelde"]),
                Convert.ToDateTime(reader["DatumTijd"]),
                Convert.ToInt32(reader["VerschilDagen"])
                );
        }
    }
}
