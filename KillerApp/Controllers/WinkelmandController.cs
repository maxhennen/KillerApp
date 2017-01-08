using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class WinkelmandController : Controller
    {
        // GET: Winkelmand
        public ActionResult Winkelmand()
        {

            decimal Prijs = 0;
            try
            {
                ViewBag.Bestelling = (List<Producten>)Session["ListProducten"];
                foreach (var item in (List<Producten>)Session["ListProducten"])
                {
                    Prijs = Prijs + item.Prijs;
                }
            }
            catch(NullReferenceException)
            {
                ViewBag.Error = "Er zijn geen producten toegevoegd aan de winkelmand";
            }
            ViewBag.TotaalPrijs = Prijs;
            return View();
        }

        public ActionResult Kopen()
        {
            Bestelling bestelling = new Bestelling();
            bestelling.Kopen((List<Producten>)Session["ListProducten"], (int)Session["GebruikerID"]);
            Session["Error"] = "Aankoop is bevestigd";
            return RedirectToAction("Homepage", "Home");
        }
        
        public ActionResult VerwijderProduct(int productID)
        {
            List<Producten> Verwijderen = new List<Producten>();
            Verwijderen = (List<Producten>)Session["ListProducten"];
            foreach (var item in Verwijderen)
            {
                    if (item.ProductID == productID)
                    {
                        Verwijderen.Remove(item);
                        break;
                    }
            }
            Session["ListProducten"] = Verwijderen;
            return RedirectToAction("Winkelmand", "Winkelmand");
        }
    }
}