using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Interfaces
{
    public interface IGebruikerSQLContext
    {
        int Login(string email, string wachtwoord);
        int BeheerderOphalen(int gebruikerID);
        bool Registreren(Gebruiker gebruiker);
    }
}
