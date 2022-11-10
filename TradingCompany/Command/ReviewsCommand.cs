using AutoMapper;
using DAL.Concrete;
using System;
using TradingCompany.DAL.Concrete;
using TradingCompany.DTO;

namespace TradingCompany.Command
{
    public static class ReviewsCommand
    {
        private static IMapper _mapper = setupMapper();
        private static ReviewDAL _dal = new ReviewDAL(_mapper);
        private static IMapper setupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(ReviewDAL).Assembly)
                );
            return config.CreateMapper();
        }

        public static void PrintAllReviews()
        {
            var reviews = _dal.GetAllReviews();

            foreach (var review in reviews)
            {
                Console.WriteLine($"ID:{review.ReviewID}  ProductName:{review.Product.ProductName.Trim()}\n" + 
                    $"Username:{review.User.Login.Trim()}  Rating:{review.Rating}\nText: {review.Text}\n");
            }
        }

        public static void CreateReview()
        {
            Console.Write("Enter product ID: ");
            int productID = int.Parse(Console.ReadLine());
            Console.Write("Enter rating (0 - 10): ");
            decimal rating = decimal.Parse(Console.ReadLine());
            Console.Write("Enter review text: ");
            string reviewText = Console.ReadLine();

            var created = new ReviewDTO
            {
                Rating = rating,
                Text = reviewText,
                UserID = 11,
                ProductID = productID
            };

            created = _dal.CreateReview(created);
            Console.WriteLine($"Successfully created product with ID {created.ReviewID}");
        }
        public static void DeleteReview()
        {
            Console.Write("Enter review ID: ");
            int id = int.Parse(Console.ReadLine());
            var found = _dal.GetReview(id);

            if (found != null)
            {
                _dal.DeleteReview(found);

                Console.WriteLine($"Successfully deleted product with ID {id}");
            }
            else
            {
                Console.WriteLine("Error! No product with such ID");
            }
        }
        public static void UpdateReview()
        {
            throw new NotImplementedException();
        }
    }
}
