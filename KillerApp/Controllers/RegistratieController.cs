using KillerApp.Data;
using KillerApp.Logic;
using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class RegistratieController : Controller
    {
        // GET: Registratie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registreren(string Voornaam,string Achternaam,string Email,string Wachtwoord,DateTime Geboortedatum, 
            string Straat, int Huisnummer, string Woonplaats, string Postcode,long Telefoonnummer)
        {
            Gebruiker gebruiker = new Gebruiker(Voornaam, Achternaam, Geboortedatum, Straat, Huisnummer, Postcode,
            Woonplaats, Email, Telefoonnummer, Wachtwoord);
            bool Geregistreerd = gebruiker.Registreren(gebruiker);
            string Alert;
            if(Geregistreerd == true)
            {
                Alert = "Account is aangemaakt u kunt nu inloggen";
                ViewBag.Alert = Alert;
                return RedirectToAction("Index", "Home");
            }

            else
            {
                Alert = "Email bestaat al";
                ViewBag.Alert = Alert;
                return RedirectToAction("Index", "Registratie");
            }
        }
    }
}