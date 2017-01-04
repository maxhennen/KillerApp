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
        public int Aantal { get; private set; }
        public List<Producten> ProductenWinkelmand { get; private set; } 
        public Bestelling()
        {
            ProductenWinkelmand = new List<Producten>();
        }
    }
}
