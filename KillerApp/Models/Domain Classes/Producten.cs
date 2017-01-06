using KillerApp.Data;
using KillerApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models
{
    public class Producten 
    {
        public int ProductID { get; private set; }
        public string Naam { get; private set; }
        public string Merk { get; private set; }
        public int TelefoonID { get; private set; }
        public string Soort { get; private set; }
        public int Aantal { get; private set; }
        public int SpecificatieID { get; private set; }
        public string Kleur { get; private set; }
        public bool Bluetooth { get; private set; }
        public int Geheugen { get; private set; }
        public bool WiFi { get; private set; }
        public bool DrieG { get; private set; }
        public bool VierG { get; private set; }
        public bool Draadloos { get; private set; }
        public decimal Prijs { get; private set; }
        public string Afbeeldingen { get; private set; }
        public Producten Product { get; private set; }
        private ProductenRepository productenRepo;

        public Producten()
        {

        }


        public Producten(Producten product)
        {
            Product = product;
        }
        public Producten (int productId, string naam, string merk, int telefoonId,int aantal, string soort, int specificatieID,
            string kleur, bool bluetooth, int geheugen,bool wifi, bool drieG, bool vierG,bool draadloos, decimal prijs, string afbeeldingen)
        {
            ProductID = productId;
            Naam = naam;
            Merk = merk;
            TelefoonID = telefoonId;
            Aantal = aantal;
            Soort = soort;
            SpecificatieID = specificatieID;
            Kleur = kleur;
            Bluetooth = bluetooth;
            Geheugen = geheugen;
            WiFi = wifi;
            DrieG = drieG;
            VierG = vierG;
            Draadloos = draadloos;
            Prijs = prijs;
            Afbeeldingen = afbeeldingen;
        }

        public List<Producten> ProductenHomepage()
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            return productenRepo.ProductenHomepage();
        }

        public List<Producten> AlleTelefoons()
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            return productenRepo.AlleTelefoons();
        }

        public List<Producten> AlleAccessoires()
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            return productenRepo.AlleAccessoires();
        }

        public List<Producten> ProductBijNaam(string productNaam)
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            return productenRepo.ProductBijNaam(productNaam);
        }

        public void ProductToevoegen(Producten product)
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            productenRepo.ProductToevoegen(product);
        }

        public void UpdateVoorraad(string productNaam, int specificatieID, int aantal)
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            productenRepo.UpdateVoorraad(productNaam, specificatieID, aantal);
        }

        public Producten ProductToevoegenWinkelmand(string productNaam, int specificatieID)
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            return productenRepo.ProductToevoegenWinkelmand(productNaam, specificatieID);
        }
    }
}