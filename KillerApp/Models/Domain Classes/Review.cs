using KillerApp.Data;
using KillerApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Models
{
    public class Review
    {
        public int ReviewID { get; private set; }
        public int AantalSterren { get; private set; }
        public string ReviewTekst { get; private set; }
        public string KlantNaam { get; private set; }
        public int ProductID { get; private set; }
        public int GemiddeldeScore { get; private set; }
        public int VerschilDagen { get; private set; }
        public DateTime DatumTijd { get; private set; }
        private ReviewRepository ReviewRepo;

        public Review()
        {

        }

        public Review(int reviewID, int aantalSterren, string reviewTekst, string klantNaam, int productID, int gemiddeldeScore, DateTime datumTijd, int verschilDagen)
        {
            AantalSterren = aantalSterren;
            ReviewTekst = reviewTekst;
            KlantNaam = klantNaam;
            ProductID = productID;
            GemiddeldeScore = gemiddeldeScore;
            DatumTijd = datumTijd;
            VerschilDagen = verschilDagen;
        }

        public List<Review> ReviewBijProduct(int productID)
        {
            ReviewRepo = new ReviewRepository(new ReviewSQLContext());
            return ReviewRepo.ReviewBijProduct(productID);
        }
    }
}
