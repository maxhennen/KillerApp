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
        Review Invoeren(Review review);
        List<Review> GetReview();
    }
}
