using KillerApp.Models;
using KillerApp.Models.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class ProductController : Controller
    {
        private Producten Producten = new Producten();
        private Specificatie Specificatie = new Specificatie();
        private Review review = new Review();
        public List<Producten> ListWinkelmand { get; private set; }
        // GET: Product
        public ActionResult Product(int ProductID)
        {
            ViewBag.Review = review.ReviewBijProduct(ProductID);
            List<int> getallen = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                getallen.Add(i);
            }
            ViewBag.Aantal = getallen;
            ViewBag.Product = Producten.ProductBijID(ProductID);
            ViewBag.Specificaties = Specificatie.SpecificatieBijProduct(ProductID);
            return View();
        }

        public ActionResult Toevoegen(int productID, int specificatieID)
        {
            if(Session["Bestelling"] == null)
            {
                Session["Bestelling"] = new Bestelling();
            }

            Bestelling bestelling = (Bestelling)Session["Bestelling"];
            Producten product = new Producten(Producten.ProductBijID(productID), Specificatie.SpecificatieBijID(specificatieID));
            bestelling.ProductenWinkelmand.Add(product);
            Session["Bestelling"] = bestelling;
            Session["ProductenAantal"] = bestelling.ProductenWinkelmand.Count;
            Session["ListProducten"] = bestelling.ProductenWinkelmand;
            return RedirectToAction("Product", "Product", new { ProductID = productID});
        }

    }
}