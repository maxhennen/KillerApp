using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;

namespace KillerApp.Logic
{
    public class BestellingRepository
    {
        private IBestellingSQLContext Context;

        public BestellingRepository(IBestellingSQLContext context)
        {
            Context = context;
        }

        public List<Bestelling> BestellingenGebruiker(int gebruikerID)
        {
            return Context.BestellingenGebruiker(gebruikerID);
        }

        public void Kopen(List<Producten> producten, int gebruikerID)
        {
            Context.Kopen(producten, gebruikerID);
        }



    }
}
