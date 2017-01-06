using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        public Gebruiker Gebruiker { get; private set; }
        // GET: Home
        public ActionResult Homepage()
        {
            Producten producten = new Producten();
            ViewBag.Telefoons = producten.ProductenHomepage();
            Session["ProductenAantal"] = 0;
            return View();
        }

        public ActionResult Login(string EmailText, string WachtwoordText)
        {
            Gebruiker = new Gebruiker(EmailText,WachtwoordText);
            Gebruiker = Gebruiker.Login(Gebruiker);
            Session["Header"] = Gebruiker.Gebruikerstype;
            Session["GebruikerNaam"] = Gebruiker.Voornaam + " " + Gebruiker.Achternaam;
            Session["GebruikerID"] = Gebruiker.GebruikerID;
            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult Loguit()
        {
            Session["Gebruiker"] = null;
            Session["Header"] = null;
            Session["Producten"] = null;
            return RedirectToAction("Homepage", "Home");
        }
    }
}