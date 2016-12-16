using KillerApp.Models.Domain_Classes;
using KillerApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp.Models.Logic
{
    public class SpecificatieRepository
    {
        private ISpecificatieSQLContext Context;

        public SpecificatieRepository(ISpecificatieSQLContext context)
        {
            Context = context;
        }

        public List<Specificatie> SpecificatieBijProduct(int productID)
        {
            return Context.SpecificatieBijProduct(productID);
        }
    }
}