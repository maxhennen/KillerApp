using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;
using KillerApp.Models.Interfaces;

namespace KillerApp.Logic
{
    public class ProductenRepository
    {
        private IProductenSQLContext Context;
        private IUnitTest ContextTest;

        public ProductenRepository(IProductenSQLContext context)
        {
            Context = context;
        }

        public ProductenRepository(IUnitTest context)
        {
            ContextTest = context;
        }

        public List<Producten> AlleTelefoons()
        {
            return Context.AlleTelefoons();
        }

        public List<Producten> AlleAccessoires()
        {
            return Context.AlleAccessoires();
        }

        public List<Producten> ProductenHomepage()
        {
            return Context.ProductenHomepage();
        }

        public List<Producten> ProductBijNaam(string productNaam)
        {
            return Context.ProductBijNaam(productNaam);
        }

        public void ProductToevoegen(Producten product)
        {
            Context.ProductToevoegen(product);
        }

        public void UpdateVoorraad(string productNaam, int specificatieID,int aantal)
        {
            Context.UpdateVoorraad(productNaam, specificatieID, aantal);
        }

        public Producten ProductToevoegenWinkelmand(string productNaam, int specificatieID)
        {
            return Context.ProductToevoegenWinkelmand(productNaam, specificatieID);
        }

        public Producten ProductToevoegenWinkelmandUnitTest(string productNaam, int specificatieID)
        {
            return ContextTest.ProductenToevoegenWinkelmandUnitTest(productNaam, specificatieID);
        }
    }
}

