using KillerApp.Data;
using KillerApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KillerApp.Models
{
    public class Bestelling
    {
        public int BestelregelID { get; private set; }
        public Producten Product { get; private set; }
        public Gebruiker Gebruiker { get; private set; }
        public DateTime DatumTijd { get; private set; }
        public List<Producten> ProductenWinkelmand { get; private set; }
        public BestellingRepository BestellingRepo { get; private set; }
        public Bestelling()
        {
            ProductenWinkelmand = new List<Producten>();
        }

        public Bestelling(int bestelregelID, Producten product, Gebruiker gebruiker, DateTime datumTijd)
        {
            BestelregelID = bestelregelID;
            Product = product;
            Gebruiker = gebruiker;
            DatumTijd = datumTijd;
        }

        public Bestelling(List<Producten> producten, int gebruikerID)
        {

        }

        public List<Bestelling> BestellingenGebruiker(int gebruikerID)
        {
            BestellingRepo = new BestellingRepository(new BestellingSQLContext());
            return BestellingRepo.BestellingenGebruiker(gebruikerID);
        }

        public void Kopen(List<Producten> producten, int gebruikerID)
        {
            BestellingRepo = new BestellingRepository(new BestellingSQLContext());
            BestellingRepo.Kopen(producten, gebruikerID);
        }
    }
}
