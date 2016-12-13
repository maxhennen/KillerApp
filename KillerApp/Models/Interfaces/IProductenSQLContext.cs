using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Interfaces
{
    public interface IProductenSQLContext
    {
        List<Producten> AlleTelefoons();
        List<Producten> ProductenHomepage();
        Producten ProductBijID(int productID);
    }
}
