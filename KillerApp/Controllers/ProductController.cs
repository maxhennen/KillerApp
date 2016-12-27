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
            
            return View();
        }
    }
}