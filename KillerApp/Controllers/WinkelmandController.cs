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
            ProductController pc = new ProductController();
            ViewBag.Winkelmand = Session["Producten"];
            return View();
        }
    }
}