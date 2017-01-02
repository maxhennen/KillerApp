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

        public Gebruiker Login(Gebruiker gebruiker)
        {
            return Context.Login(gebruiker);
        }

        public void Registreren(Gebruiker gebruiker)
        {
            Context.Registreren(gebruiker);
        }
    }
}
