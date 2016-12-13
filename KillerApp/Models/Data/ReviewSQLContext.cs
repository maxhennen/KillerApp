using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerApp.Interfaces;
using KillerApp.Models;

namespace KillerApp.Data
{
    class ReviewSQLContext:IReviewSQLContext
    {
        public Review Invoeren(Review review)
        {
            return review;
        }

        public List<Review> GetReview()
        {
            List<Review> review = new List<Review>();
            return review;
        }
    }
}
