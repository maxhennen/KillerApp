using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models
{
    class Review
    {
        public int AantalSterren { get; private set; }
        public string ReviewTekst { get; private set; }
        public int KlantID { get; private set; }
        public int ProductID { get; private set; }

        public Review(int aantalSterren, string reviewTekst, int klantId, int productId)
        {
            AantalSterren = aantalSterren;
            ReviewTekst = reviewTekst;
            KlantID = klantId;
            ProductID = productId;
        }
    }
}
