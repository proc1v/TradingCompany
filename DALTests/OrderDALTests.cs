using AutoMapper;
using NUnit.Framework;
using System;
using TradingCompany.DAL.Concrete;
using TradingCompany.DTO;

namespace DALTests
{
    [TestFixture]
    public class OrderDALTests
    {
        private IMapper _mapper;
        private OrderDAL _dal;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(OrderDAL).Assembly)
                );

            _mapper = config.CreateMapper();
            _dal = new OrderDAL(_mapper);
        }

        [Test]
        public void CreateTest()
        {
            var result = _dal.CreateOrder(new OrderDTO
            {
                UserID = 11,
                ProductID = 1,
                Quantity = 10
            });
            Assert.IsTrue(result.OrderID != 0, "order ID should not be 0!");
        }

        [Test]
        public void ReadAllTest()
        {
            var result = _dal.GetAllOrders();

            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void UpdateTest()
        {
            var random = new Random();

            var found = _dal.GetAllOrders().Find(x => x.OrderID == 1);
            int oldQuantity = found.Quantity;
            found.Quantity = random.Next(0, 100);

            _dal.UpdateOrder(found);
            found = _dal.GetAllOrders().Find(x => x.OrderID == 1);
            Assert.IsTrue(oldQuantity != found.Quantity);
        }

        [Test]
        public void DeleteTest()
        {
            var result = _dal.CreateOrder(new OrderDTO
            {
                UserID = 11,
                ProductID = 1,
                Quantity = 10
            });

            //int oldID = result.OrderID;

            _dal.DeleteOrder(result);

            var deleted = _dal.GetAllOrders().Find(x => x.OrderID == result.OrderID);
            Assert.IsNull(deleted);
        }
    }
}
