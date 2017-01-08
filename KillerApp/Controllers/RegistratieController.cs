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

        public ActionResult RegistrerenKlant(string Voornaam, string Achternaam, string Email, string Wachtwoord, string WachtwoordBevestigen,
            DateTime Geboortedatum, string Straat, int Huisnummer, string Woonplaats, string Postcode, long Telefoonnummer,string gebruikerstype)
        {
            try
            {
                if (Wachtwoord != WachtwoordBevestigen)
                {
                    Session["Error"] = "Wachtwoordvelden komen niet overeen";
                }
                else
                {
                    Gebruiker gebruiker = new Gebruiker(0,Voornaam, Achternaam, Geboortedatum, Straat, Huisnummer, Postcode,
                    Woonplaats,"", Email, Telefoonnummer, Wachtwoord, "Klant");
                    gebruiker.Registreren(gebruiker);
                    Session["Error"] = "Uw account is aangemaakt";
                }
            }
            catch(SqlException)
            {
                Session["Error"] = "Het ingevoerde emailadres is al ingebruik";
            }
            return RedirectToAction("Registratie", "Registratie");
        }
    }
}