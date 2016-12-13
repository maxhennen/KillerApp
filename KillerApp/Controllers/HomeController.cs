using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Helpers;

namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            Producten telefoon = new Producten();
            ViewBag.Telefoons = telefoon.ProductenHomepage();
            return View();
        }
         public ActionResult Login(string EmailText, string WachtwoordText)
        {
            int Beheerder;
            Gebruiker gebruiker = new Gebruiker(EmailText, WachtwoordText);
            Beheerder = gebruiker.BeheerderOphalen(gebruiker.Login(EmailText,WachtwoordText));
            Session["Beheerder"] = Beheerder;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Loguit()
        {
            Session["Beheerder"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}