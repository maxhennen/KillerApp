using Microsoft.VisualStudio.TestTools.UnitTesting;
using KillerApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Logic;
using KillerApp.Models.Data;
using KillerApp.Data;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void ToevoegenTest()
        {
            ProductenRepository ProductenRepo = new ProductenRepository(new UnitTestContext());
            Producten ProductWinkelmand = null;
            Bestelling bestelling = null;
            if (bestelling  == null)
            {
                bestelling = new Bestelling();
            }

            foreach (var item in bestelling.ProductenWinkelmand)
            {
                if (item.SpecificatieID == 1)
                {
                    ProductWinkelmand = new Producten();
                }
            }
            bestelling.ProductenWinkelmand.Add(ProductenRepo.ProductToevoegenWinkelmandUnitTest("Iphone1",1));
            Assert.AreEqual(1, bestelling.ProductenWinkelmand.Count);  
        }
    }
}