﻿using KillerApp.Data;
using KillerApp.Logic;
using KillerApp.Models;
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
        public ActionResult Index()
        {
            Producten telefoon = new Producten();
            ViewBag.Telefoons = telefoon.AlleTelefoons();
            return View();
        }


    }
}