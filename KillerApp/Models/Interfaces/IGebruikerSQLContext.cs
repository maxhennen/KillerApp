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
        Gebruiker Login(Gebruiker gebruiker);
        void Registreren(Gebruiker gebruiker);
    }
}
