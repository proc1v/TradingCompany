using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace DAL.Concrete
{
    public class UserDAL : IUserDAL
    {
        private readonly IMapper _mapper;

        public UserDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var userInDB = _mapper.Map<User>(user);
                userInDB.RowInsertTime = DateTime.UtcNow;
                userInDB.RowUpdateTime = DateTime.UtcNow;
                entities.Users.Add(userInDB);
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(userInDB);
            }
        }

        public void DeleteUser(UserDTO user)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Users.SingleOrDefault(d => d.UserID == user.UserID);
                entities.Users.Remove(found);
                entities.SaveChanges();
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            using (var entities = new CourseProject2022Entities())
            {
                var users = entities.Users.ToList();
                return _mapper.Map<List<UserDTO>>(users);
            }
        }

        public UserDTO GetUser(string login)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Users.SingleOrDefault(d => d.Login == login);
                return _mapper.Map<UserDTO>(found);
            }
        }

        public UserDTO GetUser(int id)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Users.SingleOrDefault(d => d.UserID == id);
                return _mapper.Map<UserDTO>(found);
            }
        }

        public bool Login(string username, string password)
        {
            using (var ent = new CourseProject2022Entities())
            {
                UserDTO user = _mapper.Map<UserDTO>(ent.Users.FirstOrDefault(u => u.Login == username));
                return user != null && user.Password.SequenceEqual(hash(password, user.Salt.ToString()));
            }
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }

        public void UpdateUser(UserDTO user)
        {
            using (var entities = new CourseProject2022Entities())
            {
                var found = entities.Users.SingleOrDefault(d => d.UserID == user.UserID);
                if (found != null)
                {
                    found.Login = user.Login;
                    found.Email = user.Email;
                    found.Password = user.Password;
                    found.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
