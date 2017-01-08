using KillerApp.Models;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class BeheerController : Controller
    {
        // GET: Beheer
        public ActionResult BeheerderToevoegen()
        {
            return View();
        }

        public ActionResult RegistrerenBeheerder(string Voornaam, string Achternaam, string Email, string Wachtwoord, DateTime Geboortedatum,
            string Straat, int Huisnummer, string Woonplaats, string Postcode, long Telefoonnummer, string gebruikerstype)
        {
            Gebruiker gebruiker = new Gebruiker(0,Voornaam, Achternaam, Geboortedatum, Straat, Huisnummer, Postcode,
                Woonplaats,"", Email, Telefoonnummer, Wachtwoord, "Beheerder");
            gebruiker.Registreren(gebruiker);
            return RedirectToAction("Homepage", "Home");
        }

        public ActionResult ToevoegenProduct()
        {
            ViewBag.AlleProducten = AlleTelefoons();
            return View();
        }

        public List<Producten> AlleTelefoons()
        {
            Producten product = new Producten();
            return product.AlleTelefoons();
        }

        [HttpPost]
        public ActionResult Toevoegen(HttpPostedFileBase file, string naam, string categorie, int aantal, string merk, string opvolger,
            string kleur, int bluetooth, int geheugen, int WiFi, int DrieG, int VierG, int draadloos, decimal prijs)
        {
            var filename = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/"),filename);
            file.SaveAs(path);
            int telefoonID = 0;

            foreach (var item in AlleTelefoons())
            {
                if (item.Naam == naam)
                {
                    telefoonID = item.ProductID;
                }
            }

            Producten product = new Producten(0, naam, merk, telefoonID, aantal, categorie, 0, kleur, Convert.ToBoolean(bluetooth), geheugen,
                Convert.ToBoolean(WiFi), Convert.ToBoolean(DrieG), Convert.ToBoolean(VierG), Convert.ToBoolean(draadloos), prijs, "/Images/"+filename);
            product.ProductToevoegen(product);
            return RedirectToAction("ToevoegenProduct", "Beheer");
        }
    }
}