using KillerApp.Controllers;
using KillerApp.Data;
using KillerApp.Interfaces;
using KillerApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI;

namespace KillerApp.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        public string Voornaam { get; private set; }
        public string Achternaam { get; private set; }
        public DateTime Geboortedatum { get; private set; }
        public string Straat { get; private set; }
        public int Huisnummer { get; private set; }
        public string Postcode { get; private set; }
        public string Woonplaats { get; private set; }
        public string Land { get; private set; }
        public string Mail { get; private set; }
        public long Telefoonnummer { get; private set; }
        public string Wachtwoord { get; private set; }
        public string Gebruikerstype { get; private set; }

        public GebruikerRepository GebruikerRepo { get; private set; }

        public Gebruiker()
        {

        }

        public Gebruiker(string email, string wachtwoord)
        {
            Mail = email;
            Wachtwoord = wachtwoord;
        }
        public Gebruiker(int gebruikerID, string voornaam,string achternaam, DateTime geboortedatum,
            string straat, int huisnummer, string postcode, string woonplaats, string land, string mail
            , long telefoonnummer, string wachtwoord, string gebruikerstype)
        {
            GebruikerID = gebruikerID;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geboortedatum = geboortedatum;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Woonplaats = woonplaats;
            Land = land;
            Mail = mail;
            Telefoonnummer = telefoonnummer;
            Wachtwoord = wachtwoord;
            Gebruikerstype = gebruikerstype;
        }

        public Gebruiker Login(Gebruiker gebruiker)
        {
            GebruikerRepo = new GebruikerRepository(new GebruikerSQLContext());
            return GebruikerRepo.Login(gebruiker);
        }

        public void Registreren(Gebruiker gebruiker)
        {
            GebruikerRepo = new GebruikerRepository(new GebruikerSQLContext());
            GebruikerRepo.Registreren(gebruiker);
        }
    }
}
