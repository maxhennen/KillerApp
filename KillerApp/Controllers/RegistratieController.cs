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

        public ActionResult Registreren(string Voornaam, string Achternaam, string Email, string Wachtwoord, DateTime Geboortedatum,
            string Straat, int Huisnummer, string Woonplaats, string Postcode, long Telefoonnummer)
        {
                Gebruiker gebruiker = new Gebruiker(Voornaam, Achternaam, Geboortedatum, Straat, Huisnummer, Postcode,
                Woonplaats, Email, Telefoonnummer, Wachtwoord);
                gebruiker.Registreren(gebruiker);
                return RedirectToAction("Index", "Home");
        }
    }
}