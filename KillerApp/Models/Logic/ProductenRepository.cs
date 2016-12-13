using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;

namespace KillerApp.Logic
{
    public class ProductenRepository
    {
        private IProductenSQLContext Context;

        public ProductenRepository(IProductenSQLContext context)
        {
            Context = context;
        }

        public List<Producten> AlleTelefoons()
        {
            return Context.AlleTelefoons();
        }

        public List<Producten> ProductenHomepage()
        {
            return Context.ProductenHomepage();
        }

        public Producten ProductBijID(int productID)
        {
            return Context.ProductBijID(productID);
        }
}
    }

