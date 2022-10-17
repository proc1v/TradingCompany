using AutoMapper;
using DAL.Concrete;
using NUnit.Framework;
using System.EnterpriseServices;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using TradingCompany.DTO;

namespace DALTests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class UserDALTests : ServicedComponent
    {
        private IMapper _mapper;
        [Test]
        public void DummyTest()
        {
            Assert.IsTrue(1 == 1);
        }
        /*[OneTimeSetUp]
        public void SetupOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(UserDAL).Assembly)
                );
            _mapper = config.CreateMapper();
        }
        [Test]
        public void CreateTest()
        {
            UserDAL dal = new UserDAL(_mapper);
            var result = dal.CreateUser(new UserDTO
            {
                Login = "TestLogin",
                Email = "testmail@test.org",
                Password = Encoding.ASCII.GetBytes("qwerty01")
            });
            Assert.IsTrue(result.UserID != 0, "returned ID should be more than 0!");
        }*/

        /*[Test]
        public void CanReadFromDB()
        {

        }*/
        /*[TearDown]
        public void TearDown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }*/
    }
}
