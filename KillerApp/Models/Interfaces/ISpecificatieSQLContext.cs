using KillerApp.Models.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models.Interfaces
{
    interface ISpecificatieSQLContext
    {
        Specificatie SpecificatieBijID(int productID);
    }
}
