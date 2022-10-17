using AutoMapper;
using DAL.Concrete;
using NUnit.Framework;
using System;
using TradingCompany.DTO;

namespace DALTests
{

    [TestFixture]
    public class UserDALTests
    {
        private IMapper _mapper;
        private UserDAL _dal;

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(UserDAL).Assembly)
                );

            _mapper = config.CreateMapper();
            _dal = new UserDAL(_mapper);
        }

        [Test]
        public void CreateTest()
        {
            var result = _dal.CreateUser(new UserDTO
            {
                Login = "testCreate",
                Email = "test@test.org",
                Password = "password"
            });
            Assert.IsTrue(result.UserID != 0, "user ID should not be 0!");
        }

        [Test]
        public void ReadAllTest()
        {
            var result = _dal.GetAllUsers();

            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void UpdateTest()
        {
            var found = _dal.GetAllUsers().Find(x => x.Login == "testUpdate");
            string oldPass = found.Password;
            found.Password = Guid.NewGuid().ToString();

            _dal.UpdateUser(found);
            found = _dal.GetAllUsers().Find(x => x.Login == "testUpdate");
            Assert.IsTrue(oldPass != found.Password);
        }

        [Test]
        public void DeleteTest()
        {
            var created = _dal.CreateUser(new UserDTO
            {
                Login = "testDelete",
                Email = "testDelete@test.org",
                Password = "password"
            });

            _dal.DeleteUser(created);
            
            var deleted = _dal.GetAllUsers().Find(x => x.Login == created.Login);
            Assert.IsNull(deleted);
        }
    }

}
