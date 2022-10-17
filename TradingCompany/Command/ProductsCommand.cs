using AutoMapper;
using System;
using TradingCompany.DAL.Concrete;
using TradingCompany.DTO;

namespace TradingCompany.Command
{
    public static class ProductsCommand
    {
        private static IMapper _mapper = setupMapper();
        private static ProductDAL _dal = new ProductDAL(_mapper);
        private static IMapper setupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(ProductDAL).Assembly)
                );
            return config.CreateMapper();
        }

        public static void CreateProduct()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product description: ");
            string productDescription = Console.ReadLine();
            Console.Write("Enter product price: ");
            double productPrice = double.Parse(Console.ReadLine());

            var created = new ProductDTO
            {
                ProductName = productName,
                Description = productDescription,
                Price = productPrice,
            };
            created = _dal.CreateProduct(created);

            Console.WriteLine($"Successfully created product with ID {created.ProductID}");
        }
        public static void PrintAllProducts()
        {
            var products = _dal.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"ID:{prod.ProductID}    Name:{prod.ProductName.Trim()}    Price:{prod.Price}");
                Console.WriteLine($"Description: {prod.Description.Trim()}\n");
            }
        }
        public static void UpdateProduct()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            var found = _dal.GetProduct(id);

            if (found != null)
            {
                Console.Write("Enter new product name or press Enter to not change: ");
                string productName = Console.ReadLine();
                Console.Write("Enter product description or press Enter to not change: ");
                string productDescription = Console.ReadLine();
                Console.Write("Enter product price or press Enter to not change: ");
                bool priceChanged = double.TryParse(Console.ReadLine(), out double productPrice);

                var created = new ProductDTO
                {
                    ProductID = id,
                    ProductName = string.IsNullOrWhiteSpace(productName) ? found.ProductName : productName,
                    Description = string.IsNullOrWhiteSpace(productDescription) ? found.Description : productDescription,
                    Price = priceChanged ? productPrice : found.Price
                };

                _dal.UpdateProduct(created);

                Console.WriteLine($"Successfully created product with ID {created.ProductID}");
            }
            else
            {
                Console.WriteLine("Error! No product with such ID");
            }
        }
        public static void DeleteProduct()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            var found = _dal.GetProduct(id);

            if (found != null)
            {
                _dal.DeleteProduct(found);

                Console.WriteLine($"Successfully deleted product with ID {id}");
            }
            else
            {
                Console.WriteLine("Error! No product with such ID");
            }
        }
    }
}
