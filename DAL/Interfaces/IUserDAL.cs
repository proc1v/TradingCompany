using System.Collections.Generic;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Interfaces
{
    public interface IUserDAL
    {
        UserDTO CreateUser(UserDTO user);
        List<UserDTO> GetAllUsers();
        UserDTO GetUser(string login);
        UserDTO GetUser(int id);
        void UpdateUser(UserDTO user);
        void DeleteUser(UserDTO user);
    }
}
