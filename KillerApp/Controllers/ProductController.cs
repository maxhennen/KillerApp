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
        public ActionResult Index(int product)
        {
            Producten producten = new Producten();
            ViewBag.Product = producten.ProductBijID(product);
            ViewBag.Specificatie = product.Specificatiee(product);
            return View();
        }
    }
}