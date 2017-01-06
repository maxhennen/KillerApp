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
        void ProductToevoegen(Producten product);
        List<Producten> AlleTelefoons();
        List<Producten> AlleAccessoires();
        List<Producten> ProductenHomepage();
        List<Producten> ProductBijNaam(string productNaam);
        void UpdateVoorraad(string productNaam, int specificatieID, int aantal);
        Producten ProductToevoegenWinkelmand(string productNaam, int specificatieID);
    }
}
