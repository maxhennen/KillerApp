using KillerApp.Models.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models.Interfaces
{
    public interface ISpecificatieSQLContext
    {
        List<Specificatie> SpecificatieBijProduct(int productID);
        Specificatie SpecificatieBijID(int specificatieID);
    }
}
