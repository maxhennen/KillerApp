using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            try
            {
                Producten producten = new Producten();
                ViewBag.Telefoons = producten.ProductenHomepage();
                Session["ProductenAantal"] = 0;
                return View();
            }
            catch(SqlException e)
            {
                return RedirectToAction("Index", "Error", new { error = e.Message });
            }
        }

        public ActionResult Login(string EmailText, string WachtwoordText)
        {
            Gebruiker Gebruiker = new Gebruiker(EmailText,WachtwoordText);
            Gebruiker = Gebruiker.Login(Gebruiker);
            if (Gebruiker.GebruikerID == 0)
            {
                Session["Error"] = "Email en/of Wachtwoord komen niet overeen";
            }
            else
            {
                Session["Error"] = "";
                Session["Gebruiker"] = Gebruiker;
                Session["Header"] = Gebruiker.Gebruikerstype;
                Session["GebruikerNaam"] = Gebruiker.Voornaam + " " + Gebruiker.Achternaam;
                Session["GebruikerID"] = Gebruiker.GebruikerID;
            }
            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult Loguit()
        {
            Session["GebruikerID"] = null;
            Session["Header"] = null;
            Session["GebruikerNaam"] = null;
            return RedirectToAction("Homepage", "Home");
        }
    }
}