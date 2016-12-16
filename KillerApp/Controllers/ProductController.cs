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
        // GET: Product
        public ActionResult Index(int productID)
        {
            Producten producten = new Producten();
            ViewBag.Product = producten.ProductBijID(productID);
            Specificatie specificatie = new Specificatie();
            ViewBag.Specificatie = specificatie.SpecificatieBijProduct(productID);
            return View();
        }
    }
}