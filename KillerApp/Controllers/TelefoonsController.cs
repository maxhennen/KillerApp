﻿using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class TelefoonsController : Controller
    {
        // GET: Telefoons
        public ActionResult Telefoons()
        {
            Producten Telefoons = new Producten();
            ViewBag.Telefoons = Telefoons.AlleTelefoons();
            return View();
        }
    }
}