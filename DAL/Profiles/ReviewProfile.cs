using AutoMapper;
using TradingCompany.DTO;

namespace DAL.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
