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
        private Bestelling bestelling = new Bestelling();
        private Producten product = new Producten();
        private Specificatie spec = new Specificatie();
        // GET: Product
        public ActionResult Product(int ProductID)
        {
            List<int> getallen = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                getallen.Add(i);
            }
            ViewBag.Aantal = getallen;
            ViewBag.Product = product.ProductBijID(ProductID);
            ViewBag.Specificaties = spec.SpecificatieBijProduct(ProductID);
            return View();
        }

        public ActionResult Toevoegen(int productID, int specificatieID, string AantalProduct)
        {
            Session["Producten"] = bestelling.ProductenWinkelmand(productID, specificatieID, Convert.ToInt32(AantalProduct));
            Session["ProductenAantal"] = bestelling.ProductenWinkelmand(productID, specificatieID, Convert.ToInt32(AantalProduct)).Count;
            return RedirectToAction("Product", "Product", new { ProductID = productID});
        }
    }
}