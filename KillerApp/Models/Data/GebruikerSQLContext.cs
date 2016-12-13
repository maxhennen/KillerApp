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
        int gebruikerID = 0;
        public bool Registreren(Gebruiker gebruiker)
        {
            bool Registratie = false;
            try
            {
                using (SqlConnection conn = Database.Connection)
                {
                    string query = "INSERT INTO Gebruiker(GebruikerID,Voornaam,Achternaam,Geboortedatum,Straat,Huisnummer,Postcode,Woonplaats,Email,Telefoon,Wachtwoord,Beheerder)"
                        + "Values((Select (Max(GebruikerID)+1) FROM Gebruiker),@Voornaam,@Achternaam,@Geboortedatum,@Straat,@Huisnummer,@Postcode,@Woonplaats,@Email,@Telefoon,@Wachtwoord,0)";
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
                        cmd.ExecuteNonQuery();
                    }
                }
                Registratie = true;
            }
            catch(SqlException)
            {
                Registratie = false;
            }
            return Registratie;
        } 

        public int Login(string email, string wachtwoord)
        {
            using (SqlConnection conn = Database.Connection)
            {
                string query = "SELECT GebruikerID FROM Gebruiker where Email = @email AND Wachtwoord = @ww";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@ww", wachtwoord);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gebruikerID = reader.GetInt32(0);
                    }
                }
            }
            return gebruikerID;
        }

        public int BeheerderOphalen(int gebruikerID)
        {
            bool beheerder = false;
            int beheerderReturn = 0;
            if(gebruikerID >= 1)
            {
                using (SqlConnection conn = Database.Connection)
                {
                    string query = "Select Beheerder From Gebruiker where GebruikerID = @GebruikerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GebruikerID", gebruikerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            beheerder = reader.GetBoolean(0);
                        }
                    }
                    if (beheerder == true)
                    {
                        beheerderReturn = 1;
                    }
                    else
                    {
                        beheerderReturn = 2;
                    }
                }
                }
            
            if(gebruikerID == 0)
            {
                beheerderReturn = 3;
            }
            return beheerderReturn;
        }

        private Gebruiker CreateUserFromReader(SqlDataReader reader)
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
                Convert.ToInt32(reader["Beheerder"])
                );
        }
    }
}
