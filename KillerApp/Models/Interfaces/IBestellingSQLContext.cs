using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Models;

namespace KillerApp.Interfaces
{
    public interface IBestellingSQLContext
    {
        List<Bestelling> BestellingenGebruiker(int gebruikerID);
        void Kopen(List<Producten> producten, int gebruikerID);
    }
}
