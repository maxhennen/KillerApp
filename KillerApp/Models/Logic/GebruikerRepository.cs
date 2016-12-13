using KillerApp.Interfaces;
using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Logic
{
    public class GebruikerRepository
    {
        private IGebruikerSQLContext Context;

        public GebruikerRepository(IGebruikerSQLContext context)
        {
            Context = context;
        }

        public int Login(string email, string wachtwoord)
        {
            return Context.Login(email, wachtwoord);
        }

        public int BeheerderOphalen(int gebruikerID)
        {
            return Context.BeheerderOphalen(gebruikerID);
        }

        public bool Registreren(Gebruiker gebruiker)
        {
            return Context.Registreren(gebruiker);
        }
    }
}
