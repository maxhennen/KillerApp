using KillerApp.Interfaces;
using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Data
{
    class GebruikerSQLContext: IGebruikerSQLContext 
    {
        public void Registreren(Gebruiker gebruiker)
        {
                using (SqlConnection conn = Database.Connection)
                {
                    string query = "INSERT INTO Gebruiker(Voornaam,Achternaam,Geboortedatum,Straat,Huisnummer,Postcode,Woonplaats,Email,Telefoon,Wachtwoord,Gebruikerstype)"
                        + "Values(@Voornaam,@Achternaam,@Geboortedatum,@Straat,@Huisnummer,@Postcode,@Woonplaats,@Email,@Telefoon,@Wachtwoord,@Gebruikerstype)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Voornaam", gebruiker.Voornaam);
                        cmd.Parameters.AddWithValue("@Achternaam", gebruiker.Achternaam);
                        cmd.Parameters.AddWithValue("@Geboortedatum", gebruiker.Geboortedatum);
                        cmd.Parameters.AddWithValue("@Straat", gebruiker.Straat);
                        cmd.Parameters.AddWithValue("@Huisnummer", gebruiker.Huisnummer);
                        cmd.Parameters.AddWithValue("@Postcode", gebruiker.Postcode);
                        cmd.Parameters.AddWithValue("@Woonplaats", gebruiker.Woonplaats);
                        cmd.Parameters.AddWithValue("@Email", gebruiker.Mail);
                        cmd.Parameters.AddWithValue("@Telefoon", gebruiker.Telefoonnummer);
                        cmd.Parameters.AddWithValue("@Wachtwoord", gebruiker.Wachtwoord);
                        cmd.Parameters.AddWithValue("@Gebruikerstype", gebruiker.Gebruikerstype);

                        cmd.ExecuteNonQuery();
                    }
                }
        } 

        public Gebruiker Login(Gebruiker gebruiker)
        {
            using (SqlConnection conn = Database.Connection)
            {
                string query = "SELECT * FROM Gebruiker where Email = @email AND Wachtwoord = @ww";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", gebruiker.Mail);
                cmd.Parameters.AddWithValue("@ww", gebruiker.Wachtwoord);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gebruiker = CreateUserFromReader(reader);
                    }
                }
            }
            return gebruiker;
        }

        public Gebruiker CreateUserFromReader(SqlDataReader reader)
        {
            return new Gebruiker(
                Convert.ToInt32(reader["GebruikerID"]),
                Convert.ToString(reader["Voornaam"]),
                Convert.ToString(reader["Achternaam"]),
                Convert.ToDateTime(reader["Geboortedatum"]),
                Convert.ToString(reader["Straat"]),
                Convert.ToInt32(reader["Huisnummer"]),
                Convert.ToString(reader["Postcode"]),
                Convert.ToString(reader["Woonplaats"]),
                Convert.ToString(reader["Land"]),
                Convert.ToString(reader["EMail"]),
                Convert.ToInt64(reader["Telefoon"]),
                Convert.ToString(reader["Wachtwoord"]),
                Convert.ToString(reader["Gebruikerstype"])
                );
        }
    }
}
