using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Interfaces
{
    interface IReviewSQLContext
    {
        void ReviewPlaatsen(Review review);
        List<Review> ReviewBijProduct(string productNaam);
    }
}
