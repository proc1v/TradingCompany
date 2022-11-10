using System;
using TradingCompany.BL.Interfaces;
using TradingCompany.DAL.Interfaces;

namespace TradingCompany.BL.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserDAL _userDal;
        public AuthManager(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public int GetId(string login)
        {
            return _userDal.GetUser(login).UserID;
        }

        public bool Login(string username, string password)
        {
            return _userDal.Login(username, password);

        }
    }
}
