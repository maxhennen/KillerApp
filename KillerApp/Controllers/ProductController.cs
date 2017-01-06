using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(string productNaam)
        {
            Review review = new Review();
            ViewBag.Review = review.ReviewBijProduct(productNaam);
            ViewBag.Product = ProductBijNaam(productNaam);
            Session["ProductenWinkelmand"] = ProductBijNaam(productNaam);
            return View();
        }

        public ActionResult Toevoegen(string productNaam, int specificatieID)
        {
            Producten ProductWinkelmand = null;
            if(Session["Bestelling"] == null)
            {
                Session["Bestelling"] = new Bestelling();
            }
            Bestelling bestelling = (Bestelling)Session["Bestelling"];

            foreach(var item in (List<Producten>)Session["ProductenWinkelmand"])
            {
                if(item.SpecificatieID == specificatieID)
                {
                    ProductWinkelmand = new Producten();
                }
            }
            bestelling.ProductenWinkelmand.Add(ProductWinkelmand.ProductToevoegenWinkelmand(productNaam, specificatieID));
            Session["Bestelling"] = bestelling;
            Session["ProductenAantal"] = bestelling.ProductenWinkelmand.Count;
            Session["ListProducten"] = bestelling.ProductenWinkelmand;
            return RedirectToAction("Product","Product",new { productNaam = productNaam });
        }

        public ActionResult ReviewPlaatsen(string score, string ReviewTekst)
        {
            Review review = new Review(Convert.ToInt32(score),ReviewTekst,(int)Session["GebruikerID"],(int)Session["ProductID"]);
            review.ReviewPlaatsen(review);
            return RedirectToAction("Product", "Product", new { productID = (int)Session["ProductID"]});
        }

        public ActionResult Aanpassen(string productNaam, int specificatieID, int aantal)
        {
            Producten product = new Producten();
            product.UpdateVoorraad(productNaam, specificatieID, aantal);
            return RedirectToAction("Product", "Product", new { productNaam = productNaam });
        }

        public List<Producten> ProductBijNaam(string productNaam)
        {
            Producten product = new Producten();
            return product.ProductBijNaam(productNaam);
        }
    }
}