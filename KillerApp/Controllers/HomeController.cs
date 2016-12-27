using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using KillerApp.Models.Domain_Classes;

namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Master()
        {
            return View();
        }

        public ActionResult Home()
        {
            Producten product = new Producten();
            ViewBag.Telefoons = product.ProductenHomepage();
            return View();
        }
         public ActionResult Login(string EmailText, string WachtwoordText)
        {
            int Beheerder;
            Gebruiker gebruiker = new Gebruiker(EmailText, WachtwoordText);
            Beheerder = gebruiker.BeheerderOphalen(gebruiker.Login(EmailText,WachtwoordText));
            Session["Header"] = Beheerder;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Loguit()
        {
            Session["Beheerder"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegistrerenButton()
        {
            Session["Content"] = "Registratie";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registreren(string Voornaam, string Achternaam, string Email, string Wachtwoord, DateTime Geboortedatum,
            string Straat, int Huisnummer, string Woonplaats, string Postcode, long Telefoonnummer)
        {
            Gebruiker gebruiker = new Gebruiker(Voornaam, Achternaam, Geboortedatum, Straat, Huisnummer, Postcode,
            Woonplaats, Email, Telefoonnummer, Wachtwoord);
            bool Geregistreerd = gebruiker.Registreren(gebruiker);
            string Alert;
            if (Geregistreerd == true)
            {
                Alert = "Account is aangemaakt u kunt nu inloggen";
                ViewBag.Alert = Alert;
                return RedirectToAction("Index", "Home");
            }

            else
            {
                Alert = "Email bestaat al";
                ViewBag.Alert = Alert;
                Session["Content"] = "Registratie";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Telefoons()
        {
            Producten telefoons = new Producten();
            ViewBag.Telefoons = telefoons.AlleTelefoons();
            Session["Content"] = "Telefoons";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Product(int productID)
        {
            Producten product = new Producten();
            Specificatie specificatie = new Specificatie();
            ViewBag.Specificaties = specificatie.SpecificatieBijProduct(productID);
            ViewBag.Product = product.ProductBijID(productID);
            Session["Content"] = "Product";
            return RedirectToAction("Index", "Home");
        }
    }
}