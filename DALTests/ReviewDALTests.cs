using AutoMapper;
using NUnit.Framework;
using System;
using TradingCompany.DAL.Concrete;
using TradingCompany.DTO;

namespace DALTests
{
    [TestFixture]
    public class ReviewDALTests
    {
        private IMapper _mapper;
        private ReviewDAL _dal;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(ReviewDAL).Assembly)
                );

            _mapper = config.CreateMapper();
            _dal = new ReviewDAL(_mapper);
        }

        [Test]
        public void CreateTest()
        {
            var result = _dal.CreateReview(new ReviewDTO
            {
                UserID = 2,
                ProductID = 1,
                Rating = 10,
                Text = "testCreateReview"
            });
            Assert.IsTrue(result.ReviewID != 0, "review ID should not be 0!");
        }

        [Test]
        public void ReadAllTest()
        {
            var result = _dal.GetAllReviews();

            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void UpdateTest()
        {
            var random = new Random();

            var found = _dal.GetAllReviews().Find(x => x.Text == "testUpdateReviewText");
            decimal oldRating = found.Rating;
            
            while (oldRating == found.Rating)
            {
                found.Rating = random.Next(0, 10);
            }

            _dal.UpdateReview(found);
            found = _dal.GetAllReviews().Find(x => x.Text == "testUpdateReviewText");
            Assert.IsTrue(oldRating != found.Rating);
        }

        [Test]
        public void DeleteTest()
        {
            var created = _dal.CreateReview(new ReviewDTO
            {
                UserID = 2,
                ProductID = 1,
                Rating = 10,
                Text = "testDeleteReviewText"
            });

            _dal.DeleteReview(created);

            var deleted = _dal.GetAllReviews().Find(x => x.Text == created.Text);
            Assert.IsNull(deleted);
        }
    }
}
