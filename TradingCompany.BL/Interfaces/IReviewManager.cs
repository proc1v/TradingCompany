using TradingCompany.DTO;

namespace TradingCompany.BL.Interfaces
{
    public interface IReviewManager
    {
        bool CreateReview(ReviewDTO review);
    }
}
