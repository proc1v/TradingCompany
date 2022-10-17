using AutoMapper;
using NUnit.Framework;
using System;
using TradingCompany.DAL.Concrete;
using TradingCompany.DTO;


namespace DALTests
{
    [TestFixture]
    public class ProductDALTests
    {
        private IMapper _mapper;
        private ProductDAL _dal;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(ProductDAL).Assembly)
                );

            _mapper = config.CreateMapper();
            _dal = new ProductDAL(_mapper);
        }

        [Test]
        public void CreateTest()
        {
            var result = _dal.CreateProduct(new ProductDTO
            {
                ProductName = "testCreateProductName",
                Description = "testCreateDescription",
                Price = 10
            });
            Assert.IsTrue(result.ProductID != 0, "product ID should not be 0!");
        }

        [Test]
        public void ReadAllTest()
        {
            var result = _dal.GetAllProducts();

            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [Test]
        public void UpdateTest()
        {
            var found = _dal.GetAllProducts().Find(x => x.ProductName == "testUpdateProductName");
            string oldDescription = found.Description;
            found.Description = Guid.NewGuid().ToString();

            _dal.UpdateProduct(found);
            found = _dal.GetAllProducts().Find(x => x.ProductName == "testUpdateProductName");
            Assert.IsTrue(oldDescription != found.Description);
        }

        [Test]
        public void DeleteTest()
        {
            var created = _dal.CreateProduct(new ProductDTO
            {
                ProductName = "testDeleteProductName",
                Description = "testDeleteProductDescription",
                Price = 10
            });

            _dal.DeleteProduct(created);

            var deleted = _dal.GetAllProducts().Find(x => x.ProductName == created.ProductName);
            Assert.IsNull(deleted);
        }
    }
}
