using KillerApp.Interfaces;
using KillerApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp.Models.Data
{
    public class UnitTestContext:IUnitTest 
    {
        public Producten ProductenToevoegenWinkelmandUnitTest(string productNaam, int specificatieID)
        {
            List<Producten> ProductenWinkelmand = new List<Producten>();
            for(int i = 0; i <10; i++)
            {
                Producten product = new Producten(i,"Iphone" + i, "Apple", i -1, 10, "Telefoon", i, "Wit",true, i * 2, true, true, true, true, i * 100, "/Images/Iphone6");
                ProductenWinkelmand.Add(product);
            }

            foreach(var item in ProductenWinkelmand)
            {
                if (item.Naam == productNaam && item.SpecificatieID == specificatieID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}