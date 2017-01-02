using KillerApp.Models.Domain_Classes;
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
        public int KlantID { get; private set; }
        public int BestellingID { get; private set; }
        public int BestelregelID { get; private set; }
        public int ProductID { get; private set; }
        public int SpecificatieID { get; private set; }
        private List<Producten> productenWinkelmand = new List<Producten>();
        private Producten product = new Producten();
        private Specificatie specificatie = new Specificatie();

        public Bestelling()
        {

        }

        public List<Producten> ProductenWinkelmand(int productID, int specificatieID, int aantal)
        {
            Producten producten = new Producten(product.ProductBijID(productID), specificatie.SpecificatieBijID(specificatieID), aantal);
            productenWinkelmand.Add(producten);
            return productenWinkelmand;
        }
    }
}
