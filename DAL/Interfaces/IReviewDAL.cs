using System.Collections.Generic;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Interfaces
{
    public interface IReviewDAL
    {
        ReviewDTO CreateReview(ReviewDTO review);
        List<ReviewDTO> GetAllReviews();
        List<ReviewDTO> GetReviewsByUser(UserDTO user);
        ReviewDTO GetReview(int id);
        void UpdateReview(ReviewDTO review);
        void DeleteReview(ReviewDTO review);
    }
}
