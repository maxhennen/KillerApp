using KillerApp.Data;
using KillerApp.Logic;
using KillerApp.Models.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models
{
    public class Producten : IComparable<string>, IComparable<double>
    {
        public int ProductID { get; private set; }
        public string Naam { get; private set; }
        public decimal Prijs { get; private set; }
        public string Merk { get; private set; }
        public string  Afbeeldingen { get; private set; }
        public int TelefoonID { get; private set; }
        public int Aantal { get; private set; }
        public int SpecificatieID { get; private set; }
        public Producten Product { get; private set; }
        private Specificatie Specificatie = new Specificatie();
        private ProductenRepository productenRepo;
        private List<Producten> productenWinkelmand = new List<Producten>();

        public Producten()
        {

        }

        public Producten(Producten product, Specificatie specificatie, int aantal)
        {
            Product = product;
            Specificatie = specificatie;
            Aantal = aantal;
        }
        public Producten (int productId, string naam, decimal prijs, string merk, string afbeeldingen, int telefoonId)
        {
            ProductID = productId;
            Naam = naam;
            Prijs = prijs;
            Merk = merk;
            Afbeeldingen = afbeeldingen;
            TelefoonID = telefoonId;
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

        public Producten ProductBijID(int productID)
        {
            productenRepo = new ProductenRepository(new ProductenSQLContext());
            return productenRepo.ProductBijID(productID);
        }

        public int CompareTo(string naam)
        {
            return Naam.CompareTo(Naam);
        }

        public int CompareTo(double prijs)
        {
            return Prijs.CompareTo(prijs);
        }
    }
}