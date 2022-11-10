using System;
using TradingCompany.BL.Interfaces;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.BL.Concrete
{
    public class ReviewManager : IReviewManager
    {
        private readonly IReviewDAL _reviewDal;
        public ReviewManager(IReviewDAL reviewDal)
        {
            _reviewDal = reviewDal;
        }
        public bool CreateReview(ReviewDTO review)
        {
            var res = _reviewDal.CreateReview(review);

            return res.ReviewID != 0;
        }
    }
}
