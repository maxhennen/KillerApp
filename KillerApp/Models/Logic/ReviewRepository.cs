using KillerApp.Interfaces;
using KillerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.Logic
{
    class ReviewRepository
    {
        private IReviewSQLContext Context;

        public ReviewRepository(IReviewSQLContext context)
        {
            Context = context;
        }

        public void ReviewPlaatsen(Review review)
        {
            Context.ReviewPlaatsen(review);
        }

        public List<Review> ReviewBijProduct(string productNaam)
        {
            return Context.ReviewBijProduct(productNaam);
        }
    }
}
