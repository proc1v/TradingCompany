using AutoMapper;
using DAL.Concrete;
using System;
using System.Security.Cryptography;
using System.Text;
using TradingCompany.DTO;

namespace TradingCompany
{
    internal class Program
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(UserDAL).Assembly)
                );
            return config.CreateMapper();
        }

        static void Main(string[] args)
        {
            //Menu menu = new Menu();
            //menu.showMenu();
            AddNewUser();
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter login:");
            string login = Console.ReadLine();

            var dal = new UserDAL(Mapper);
            try
            {
                var found = dal.GetUser(login);
                dal.DeleteUser(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No such user");
            }
        }

        private static void AddNewUser()
        {
            Console.WriteLine("Enter login:");
            string login = Console.ReadLine();
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            var alg = SHA512.Create();
            var salt = Guid.NewGuid();

            var dal = new UserDAL(Mapper);
            var user = new UserDTO
            {
                Login = login,
                Email = email,
                Password = alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt)),
                Salt = salt
            };

            user = dal.CreateUser(user);
            Console.WriteLine($"New user ID: {user.UserID}");
        }
    }
}
