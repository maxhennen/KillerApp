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

        public Review Invoeren(Review review)
        {
            return Context.Invoeren(review);
        }

        public List<Review> ReviewBijProduct(int productID)
        {
            return Context.ReviewBijProduct(productID);
        }
    }
}
