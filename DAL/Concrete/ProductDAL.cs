using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Concrete
{
    public class ProductDAL : IProductDAL
    {
        private readonly IMapper _mapper;

        public ProductDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var productInDB = _mapper.Map<Product>(productDTO);
                productInDB.RowInsertTime = DateTime.UtcNow;
                productInDB.RowUpdateTime = DateTime.UtcNow;
                entities.Products.Add(productInDB);
                entities.SaveChanges();
                return _mapper.Map<ProductDTO>(productInDB);
            }
        }

        public void DeleteProduct(ProductDTO product)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Products.SingleOrDefault(p => p.ProductID == product.ProductID);
                entities.Products.Remove(found);
                entities.SaveChanges();
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            using (var entities = new CourseProject2022Entities())
            {
                var products = entities.Products.ToList();
                return _mapper.Map<List<ProductDTO>>(products);
            }
        }

        public ProductDTO GetProduct(int id)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Products.SingleOrDefault(p => p.ProductID == id);
                return _mapper.Map<ProductDTO>(found);
            }
        }

        public void UpdateProduct(ProductDTO product)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Products.SingleOrDefault(p => p.ProductID == product.ProductID);
                if (found != null)
                {
                    found.ProductName = product.ProductName;
                    found.Description = product.Description;
                    found.Price = product.Price;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            };
        }
    }
}
