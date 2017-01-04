using KillerApp.Models;
using KillerApp.Models.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class WinkelmandController : Controller
    {
        private List<Producten> ProductenWinkelmand;
        private decimal Prijs;
        // GET: Winkelmand
        public ActionResult Winkelmand()
        {
            ProductenWinkelmand = (List<Producten>)Session["ListProducten"];
            ViewBag.Bestelling = ProductenWinkelmand;
            
            return View();
        }
        [HttpPost]
        public ActionResult UpdateWinkelmand(List<Producten> bestelling)
        {
            foreach (var item in ProductenWinkelmand)
            {
                    Prijs = Prijs + item.Prijs * item.Aantal;
            }
            return RedirectToAction("Winkelmand", "Winkelmand");
        }

        public ActionResult VerwijderProduct(int productID)
        {
            foreach (var item in ProductenWinkelmand)
            {
                    if (item.Product.ProductID == productID)
                    {
                        ProductenWinkelmand.Remove(item);
                        break;
                    }
            }
            Session["ListProducten"] = ProductenWinkelmand;
            return RedirectToAction("Winkelmand", "Winkelmand");
        }
    }
}