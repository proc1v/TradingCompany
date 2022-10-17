using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Concrete
{
    public class ReviewDAL : IReviewDAL
    {
        private readonly IMapper _mapper;

        public ReviewDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ReviewDTO CreateReview(ReviewDTO review)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var reviewInDB = _mapper.Map<Review>(review);
                reviewInDB.UserID = review.UserID;
                reviewInDB.ProductID = review.ProductID;
                reviewInDB.ReviewCreationDate = DateTime.UtcNow;
                reviewInDB.RowUpdateTime = DateTime.UtcNow;

                //entities.Users.Add(_mapper.Map<User>(review.User));
                //entities.Products.Add(_mapper.Map<Product>(review.Product));
                entities.Reviews.Add(reviewInDB);
                entities.SaveChanges();
                return _mapper.Map<ReviewDTO>(reviewInDB);
            }
        }

        public void DeleteReview(ReviewDTO review)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Reviews.SingleOrDefault(r => r.ReviewID == review.ReviewID);
                entities.Reviews.Remove(found);
                entities.SaveChanges();
            }
        }

        public List<ReviewDTO> GetAllReviews()
        {
            using (var entities = new CourseProject2022Entities())
            {
                var reviews = entities.Reviews.ToList();
                return _mapper.Map<List<ReviewDTO>>(reviews);
            }
        }

        public ReviewDTO GetReview(int id)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Reviews.SingleOrDefault(r => r.ReviewID == id);
                return _mapper.Map<ReviewDTO>(found);
            }
        }

        public List<ReviewDTO> GetReviewsByUser(UserDTO user)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Reviews.Where(r => r.UserID == user.UserID).ToList();
                return _mapper.Map<List<ReviewDTO>>(found);
            }
        }

        public void UpdateReview(ReviewDTO review)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Reviews.SingleOrDefault(r => r.ReviewID == review.ReviewID);
                if (found != null)
                {
                    found.UserID = review.UserID;
                    found.ProductID = review.ProductID;
                    found.Text = review.Text;
                    found.Rating = review.Rating;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
