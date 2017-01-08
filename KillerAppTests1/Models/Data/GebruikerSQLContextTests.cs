using Microsoft.VisualStudio.TestTools.UnitTesting;
using KillerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Models;

namespace KillerApp.Data.Tests
{
    [TestClass()]
    public class GebruikerSQLContextTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            string email = "max.hennen@planet.nl";
            string ww = "max123";
            Gebruiker ge = null;
            Gebruiker g = new Gebruiker(email, ww);
            GebruikerSQLContext gc = new GebruikerSQLContext();
            Assert.AreEqual(ge.Gebruikerstype, gc.Login(g));
        }
    }
}