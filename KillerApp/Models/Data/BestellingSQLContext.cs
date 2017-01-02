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
        public void Bestelling(List<Bestelling> bestelling)
        {
            using (SqlConnection conn = Database.Connection)
            {
                string[] query = new string[1];
                query[0] = "INSERT INTO Bestelling(KlantID,DatumTijd)"
                    + "Values(@KlantID,@DatumTijd)";
                query[1] = "INSERT INTO Bestelregel(Producten_ProductID,@Specificaties_SpecificatieID)"
                    + "Values(@ProductID,@SpecificatieID)";
                for (int i = 0; i < query.Length; i++)
                {
                    using (SqlCommand cmd = new SqlCommand(query[i], conn))
                    {
                        cmd.Parameters.AddWithValue("@KlantID",0);
                        cmd.Parameters.AddWithValue("@DatumTijd", DateTime.Now);
                        foreach (Bestelling b in bestelling)
                        {
                            cmd.Parameters.AddWithValue("@ProductID", b.ProductID);
                            cmd.Parameters.AddWithValue("@SpecificatieID", b.SpecificatieID);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
