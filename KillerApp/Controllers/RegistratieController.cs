using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class RegistratieController : Controller
    {
        // GET: Registratie
        public ActionResult Registratie()
        {
            return View();
        }

        public ActionResult RegistrerenKlant(string Voornaam, string Achternaam, string Email, string Wachtwoord, DateTime Geboortedatum,
            string Straat, int Huisnummer, string Woonplaats, string Postcode, long Telefoonnummer,string gebruikerstype)
        {
                Gebruiker gebruiker = new Gebruiker(Voornaam, Achternaam, Geboortedatum, Straat, Huisnummer, Postcode,
                Woonplaats, Email, Telefoonnummer, Wachtwoord,"Klant");
                gebruiker.Registreren(gebruiker);
                return RedirectToAction("Homepage", "Home");
        }
    }
}