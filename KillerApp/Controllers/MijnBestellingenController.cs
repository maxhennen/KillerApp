using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class MijnBestellingenController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            Bestelling bestelling = new Bestelling();
            ViewBag.Bestellingen = bestelling.BestellingenGebruiker((int)Session["GebruikerID"]);
            return View();
        }
    }
}